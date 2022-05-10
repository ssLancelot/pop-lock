using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;

public static class ClientData

{

    public static bool Async = false;
    public static string LeaderboardText;
    public static void GetLevel(GameData gameData)
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), result =>
        {
            if (result.Data == null || result.Data.Count < 1)
            {
                SetLevel(gameData);
                SetStar(gameData);
                Async = true;
            }
            else
            {
                gameData.CurrentLevel = System.Convert.ToInt32(result.Data["level"].Value);
                gameData.Stars = System.Convert.ToInt32(result.Data["star"].Value);
                Async = true;
            }
        }, error => { Debug.Log(error.ErrorMessage); });
    }
    public static void SetLevel(GameData gameData)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string> { { "level", gameData.CurrentLevel.ToString() } }
        }, result =>
            { }, error => { Debug.Log(error.ErrorMessage); });
    }

    public static void SetStar(GameData gameData)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string> { { "star", gameData.Stars.ToString() } }
        }, result =>
            { }, error => { Debug.Log(error.ErrorMessage); });
    }

    public static void SendLeaderboard(int level)
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> { new StatisticUpdate { StatisticName = "LevelScore", Value = level } }
        }, result => { }, error => { });
    }

    public static void GetLeaderboard()
    {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest { StatisticName = "LevelScore", StartPosition = 0, MaxResultsCount = 10 }, result =>
        {
            LeaderboardText = $"# Name Level\n\n";
            foreach (var item in result.Leaderboard)
            {
                LeaderboardText += item.Position + " " + item.Profile.DisplayName + " " + item.StatValue + "\n";
            }
            Async = true;
        }, error => { });
    }
}
