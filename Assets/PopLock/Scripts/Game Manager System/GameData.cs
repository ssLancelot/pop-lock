using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public int CurrentLevel;
    public int DotsRemaining;
    public int Stars;
    public bool FirstTap = true;
    public bool IsRunning = false;
    public int MinSpawnAngle = 30;
    public int MaxSpawnAngle = 90;
    public int currentMotorSpeed = 60;
    public int minMotorSpeed = 50;
    public int maxMotorSpeed = 120;

    public void ResetLevel()
    {
        IsRunning = false;
        GetLevel();
        FirstTap = true;
    }

    public void ResetData()
    {
        CurrentLevel = 1;
        Stars = 0;
        DotsRemaining = CurrentLevel;
        currentMotorSpeed = minMotorSpeed;
    }


    public void StopGame()
    {
        IsRunning = false;
    }

    public void IncreseMotorSpeed(int value)
    {
        if (value > 0)
            currentMotorSpeed = Mathf.Min(currentMotorSpeed + value, maxMotorSpeed);
    }

    public void ReduceMotorSpeed(int value)
    {
        if (value > 0)
            currentMotorSpeed = Mathf.Max(currentMotorSpeed - value, minMotorSpeed);
    }

    public void GetLevel() => ClientData.GetLevel(this);
    public void SetLevel() => ClientData.SetLevel(this);
    public void SetStar() => ClientData.SetStar(this);
    public void SendLeaderboard() => ClientData.SendLeaderboard(CurrentLevel);
}
