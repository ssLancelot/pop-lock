using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData Gamedata;
    [SerializeField] GameObject _asyncPanel;

    private void Start()
    {
        StartCoroutine(GetClientData());
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {

            if (Input.touches[0].phase == TouchPhase.Ended && !Gamedata.IsRunning && Gamedata.FirstTap)
            {
                Gamedata.IsRunning = true;
                Gamedata.FirstTap = false;
            }
            return;
        }
        if (Input.GetMouseButtonUp(0) && !Gamedata.IsRunning && Gamedata.FirstTap)
        {
            Gamedata.IsRunning = true;
            Gamedata.FirstTap = false;
        }
    }

    public void LoadLevel()
    {
        StartCoroutine(GetClientData());
        Gamedata.FirstTap = true;
    }

    IEnumerator GetClientData()
    {
        Gamedata.ResetLevel();
        yield return new WaitUntil(() => ClientData.Async);
        Gamedata.DotsRemaining = Gamedata.CurrentLevel;
        ClientData.Async = false;
        _asyncPanel.SetActive(false);
    }
}