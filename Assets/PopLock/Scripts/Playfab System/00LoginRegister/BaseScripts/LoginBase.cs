using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class LoginBase
{
    public bool LoginBase_Async { get; set; }
    public void LoginUsername(string _username, string _password)
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest
        {
            Username = _username,
            Password = _password,
        },
        result =>
        {
            LoginBase_Async = true;
            Debug.Log("Giriş Başarılı");
        },
        error =>
        {
            LoginBase_Async = false;
            Debug.Log(error.ErrorMessage);
        });

    }
    public void LoginGuest()
    {
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest()
        {
            CreateAccount = true,
            CustomId = "Misafir Girisi",
            TitleId = PlayFabSettings.TitleId
        },
         result =>
         {
             Debug.Log("Misafir Girisi Basarili");
         },
         error =>
         {
             Debug.Log(error.ErrorMessage);
         });
    }
}
