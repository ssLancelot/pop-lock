using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorMotor : MonoBehaviour
{
    public GameData Gamedata;
    public Direction Direction = Direction.Clockwise;
    public GameEvent OnPaddleReset;
    Vector3 _initialPosition;

    Transform _anchor;

    private void Start()
    {
        _anchor = GameObject.FindGameObjectWithTag("Anchor").transform;
        _initialPosition = GetComponent<Transform>().localPosition;
    }

    private void Update()
    {
        if (Gamedata.IsRunning)
        {
            transform.RotateAround(_anchor.position, Vector3.forward, Gamedata.currentMotorSpeed * Time.deltaTime * -(int)Direction);
        }

        if (_didTap && Gamedata.IsRunning)
        {
            ChangeDirection();
        }
    }

    bool _didTap
    {
        get
        {
            return Input.GetMouseButtonDown(0) || Input.touchCount > 0;
        }
    }

    void ChangeDirection()
    {
        switch (Direction)
        {
            case Direction.Clockwise:
                Direction = Direction.AntiClockwise;
                break;

            case Direction.AntiClockwise:
                Direction = Direction.Clockwise;
                break;
        }
    }

    public void ResetPosition()
    {
        transform.localPosition = new Vector3(0, _initialPosition.y, 0);
        transform.localRotation = Quaternion.identity;

        OnPaddleReset.Raise();
    }
}

public enum Direction
{
    Clockwise = 1,
    AntiClockwise = -1
}
