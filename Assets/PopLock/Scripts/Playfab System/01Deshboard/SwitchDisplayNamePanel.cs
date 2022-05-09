using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDisplayNamePanel : MonoBehaviour
{
    [SerializeField] GameObject _displayNamePanel;

    public void SwitchPanel()
    {
        switch (_displayNamePanel.activeInHierarchy)
        {
            case true:
                _displayNamePanel.SetActive(false);
                break;
            case false:
                _displayNamePanel.SetActive(true);
                break;
        }
    }
}
