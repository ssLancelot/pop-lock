using UnityEngine;

public class HintTextUI : MonoBehaviour
{
    public GameData Gamedata;
    private void Update()
    {
        if (Gamedata.CurrentLevel != 1) { gameObject.SetActive(false); }
    }
}
