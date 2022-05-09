using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class RegisterBase
{
    public bool RegisterBase_Async { get; set; }
    public void RegisterEmail(string _username, string _email, string _password)
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
        {
            Username = _username,
            Email = _email,
            Password = _password,
            DisplayName = _username
        },
        result =>
        {
            RegisterBase_Async = true;
            Debug.Log("Kayit Tamamlandi");
        },
        error =>
        {
            RegisterBase_Async = false;
            Debug.Log(error.ErrorMessage);
        });

    }
}
