using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData Gamedata;

    private void Start()
    {
        Gamedata.ResetLevel();
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
        Gamedata.ResetLevel();
        Gamedata.FirstTap = true;
    }
}