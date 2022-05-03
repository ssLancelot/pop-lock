using UnityEngine;

public class StarsTextUI : MonoBehaviour
{
    public GameData Gamedata;
    TMPro.TextMeshProUGUI _text;

    void Start()
    {
        _text = GetComponent<TMPro.TextMeshProUGUI>();
        _text.text = "Star: " + Gamedata.Stars.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "Star: " + Gamedata.Stars.ToString();
    }
}
