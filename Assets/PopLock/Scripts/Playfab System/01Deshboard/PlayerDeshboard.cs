using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeshboard : MonoBehaviour
{
    [SerializeField] Text _displayName, _createdDate, _email, _playerID, _AsyncText;
    [SerializeField] GameObject _AsyncPanel;
    [SerializeField] RawImage _avatar;

    GetAccountInfoController _getAccountInfoController = new GetAccountInfoController();
    string _tempURL;


    void Awake()
    {
        _getAccountInfoController.AccountInfo();
    }
    private void Start()
    {
        StartCoroutine(AsyncDeshboard());
    }

    IEnumerator AsyncDeshboard()
    {
        _AsyncText.text = "Oyuncu bilgileri alınıyor...";
        yield return new WaitUntil(() => _getAccountInfoController.GetAccountInfoController_Async);
        PlayersInfos();
        _AsyncText.text = "Avatar indiriliyor...";
        yield return StartCoroutine(_getAccountInfoController.DownloadAvatar(_tempURL, _avatar));
        // _AsyncText.text = "Giriş yapılıyor...";
        // yield return new WaitUntil(() => _getAccountInfoController.GetDownloadAvatarTexture_Async);
        _AsyncPanel.SetActive(false);
    }

    void PlayersInfos()
    {
        _displayName.text = _getAccountInfoController.DisplayName;
        _email.text = _getAccountInfoController.Email;
        _createdDate.text = _getAccountInfoController.CreatedDate.ToShortDateString();
        _playerID.text = _getAccountInfoController.PlayerID;
        _tempURL = _getAccountInfoController.AvatarURL;
    }
}
