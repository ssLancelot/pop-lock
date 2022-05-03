using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInvoker : MonoBehaviour
{
    public GameEvent Event;
    public void RaiseLoadGameEvent()
    {
        Event.Raise();
    }
}
