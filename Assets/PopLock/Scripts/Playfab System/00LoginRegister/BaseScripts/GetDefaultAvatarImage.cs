using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class GetDefaultAvatarImage
{
    public bool GetDefaultAvatarImage_Async { get; set; }
    public void GetDefaultAvatar(string _currentAvatarURL, string _imagesize)
    {
        //sunucuya kucuk gelmesin diye 250 cektik
        _currentAvatarURL = _currentAvatarURL + _imagesize;

        PlayFabClientAPI.UpdateAvatarUrl(new UpdateAvatarUrlRequest() { ImageUrl = _currentAvatarURL }, result => { GetDefaultAvatarImage_Async = true; }, error => { Debug.Log(error.ErrorMessage); GetDefaultAvatarImage_Async = false; });
    }
}
