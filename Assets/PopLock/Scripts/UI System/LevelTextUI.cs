using UnityEngine;

public class LevelTextUI : MonoBehaviour
{
    public GameData Gamedata;
    TMPro.TextMeshProUGUI _text;

    void Start()
    {
        _text = GetComponent<TMPro.TextMeshProUGUI>();
        _text.text = "Level: " + Gamedata.CurrentLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "Level: " + Gamedata.CurrentLevel.ToString();
    }
}
