using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    #region ReferanceClass
    LoginBase _loginBase = new LoginBase();
    InputController _inputController = new InputController();
    #endregion

    [SerializeField] TMP_InputField _username, _password;
    [SerializeField] GameObject _aSencPanel;
    [SerializeField] TextMeshProUGUI _asncText;
    [SerializeField] Button _loginButton;

    public void LoginOnClick()
    {
        StartCoroutine(ASencLogin());
    }

    public void LoginGuestOnclick()
    {
        _loginBase.LoginGuest();
    }

    public void LoginInputController() => _inputController.LoginInputControl(_username, _password, _loginButton);
    IEnumerator ASencLogin()
    {
        _aSencPanel.SetActive(true);
        _asncText.text = "Giriş yapılıyor";
        _loginBase.LoginUsername(_username.text, _password.text);
        yield return new WaitUntil(() => _loginBase.LoginBase_Async);
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(1);
        while (!sceneLoad.isDone)
        {
            yield return null;
        }
    }
}