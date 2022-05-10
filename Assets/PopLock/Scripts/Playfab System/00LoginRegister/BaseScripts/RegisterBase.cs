using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

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
        },
        error =>
        {
            RegisterBase_Async = false;
            SceneManager.LoadScene(0);
            Debug.Log(error.ErrorMessage);
        });

    }
}
