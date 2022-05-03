using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotDetector : MonoBehaviour
{
    GameObject _currentDot;
    GameObject _lastEnteredDot;
    public GameData Gamedata;
    public float LoseThreshold = .5f;
    public GameEvent OnDotMissed;
    public GameEvent OnDotScored;
    public GameEvent OnWinEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _currentDot = other.gameObject;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _lastEnteredDot = _currentDot;
        _currentDot = null;
    }
    void Update()
    {
        if (Gamedata.IsRunning)
        {
            if (_lastEnteredDot && GetDistanceFromLastDot() > LoseThreshold)
            {
                OnDotMissed.Raise();
            }

            if (_didTap && !Gamedata.FirstTap)
            {
                if (_currentDot != null)
                {
                    if (_currentDot.GetComponent<Star>())
                    {
                        Gamedata.Stars++;
                        PlayerPrefs.SetInt("_star", Gamedata.Stars);
                    }
                    Destroy(_currentDot);
                    Gamedata.DotsRemaining--;

                    if (Gamedata.DotsRemaining <= 0)
                    {
                        Gamedata.DotsRemaining = 0;
                        Gamedata.CurrentLevel++;
                        PlayerPrefs.SetInt("_curLevel", Gamedata.CurrentLevel);
                        OnWinEvent.Raise();
                    }
                    else
                    {
                        OnDotScored.Raise();
                    }
                }
                else
                {
                    OnDotMissed.Raise();
                }
            }
        }
    }

    float GetDistanceFromLastDot()
    {
        return (transform.position - _lastEnteredDot.transform.position).magnitude;
    }

    bool _didTap
    {
        get
        {
            return Input.GetMouseButtonDown(0);
        }
    }
}
