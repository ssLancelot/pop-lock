using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    #region ReferanceClass
    RegisterBase _registerBase = new RegisterBase();
    [SerializeField] GameData gameData;
    GetDefaultAvatarImage _getDefaultAvatarImage = new GetDefaultAvatarImage();
    InputController _inputController = new InputController();
    #endregion

    [SerializeField] TMP_InputField _username, _email, _password, _repeatPassword;
    [SerializeField] GameObject _aSencPanel;
    [SerializeField] TextMeshProUGUI _asncText;
    [SerializeField] Button _registerButton;

    [Header("Default Avatar Settings")]
    public string _imagesize = "250", _avatarURL;

    public void RegisterOnClick()
    {
        StartCoroutine(ASencRegister());
    }

    public void RegisterInputControl() => _inputController.RegisterInputControl(_email, _username, _password, _repeatPassword, _registerButton);
    IEnumerator ASencRegister()
    {
        _aSencPanel.SetActive(true);
        _registerBase.RegisterEmail(_username.text, _email.text, _password.text);
        yield return new WaitUntil(() => _registerBase.RegisterBase_Async);
        _asncText.text = "Avatar Oluşturuluyor";
        _getDefaultAvatarImage.GetDefaultAvatar(_avatarURL, _imagesize);
        yield return new WaitUntil(() => _getDefaultAvatarImage.GetDefaultAvatarImage_Async);
        _asncText.text = "Giriş Yapılıyor";
        gameData.GetLevel();
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(1);
        while (!sceneLoad.isDone)
        {
            yield return null;
        }
    }
}