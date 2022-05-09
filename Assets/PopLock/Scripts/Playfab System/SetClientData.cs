using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

public class SetClientData
{
    GameData gameData = new GameData();
    public void SetLevel()
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>() { { "level", gameData.CurrentLevel.ToString() } }
        }, result =>
            { }, error => { });
    }
}
