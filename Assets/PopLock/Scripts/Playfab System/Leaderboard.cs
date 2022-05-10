using UnityEngine;
using System.Collections;
public class Leaderboard : MonoBehaviour
{
    [SerializeField] GameObject _leaderboardPanel;
    [SerializeField] TMPro.TextMeshProUGUI _text;
    public void ShowLeaderBoard()
    {
        StartCoroutine(LeaderBoard());
    }

    public void CloseLeaderBoard()
    {
        if (_leaderboardPanel.activeInHierarchy)
            _leaderboardPanel.SetActive(false);
    }

    IEnumerator LeaderBoard()
    {
        ClientData.GetLeaderboard();
        yield return new WaitUntil(() => ClientData.Async);
        _text.text = ClientData.LeaderboardText;
        ClientData.Async = false;
        _leaderboardPanel.SetActive(true);
    }
}
