using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetAccountInfoController
{
    public string DisplayName { get; set; }
    public DateTime CreatedDate { get; set; }
    public string PlayerID { get; set; }
    public string Email { get; set; }
    public string AvatarURL { get; set; }
    public bool _isBaned { get; set; }
    public bool GetAccountInfoController_Async { get; set; }
    // public bool GetDownloadAvatarTexture_Async { get; set; }

    public void AccountInfo()
    {
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(),
         result =>
          {
              DisplayName = result.AccountInfo.TitleInfo.DisplayName;
              CreatedDate = result.AccountInfo.TitleInfo.Created.Date;
              PlayerID = result.AccountInfo.PlayFabId;
              Email = result.AccountInfo.PrivateInfo.Email;
              AvatarURL = result.AccountInfo.TitleInfo.AvatarUrl;
              _isBaned = result.AccountInfo.TitleInfo.isBanned.Value;

              GetAccountInfoController_Async = true;

          },
          error =>
          {
              Debug.Log(error.ErrorMessage);
              GetAccountInfoController_Async = false;
          });
    }

    public IEnumerator DownloadAvatar(string _avatarURL, RawImage _avatar)
    {
        UnityWebRequest _request = UnityWebRequestTexture.GetTexture(_avatarURL);
        yield return _request.SendWebRequest();

        if (_request.result == UnityWebRequest.Result.ProtocolError || _request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError("Görsel indirilerken, bağlantı problemi yaşandır. ==> " + _request.error);
        }
        else
        {
            _avatar.texture = ((DownloadHandlerTexture)_request.downloadHandler).texture;
            // GetDownloadAvatarTexture_Async = true;
        }
    }

}
