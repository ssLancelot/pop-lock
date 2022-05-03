using UnityEngine;

public class RemainingDotTextUI : MonoBehaviour
{
    public GameData Gamedata;
    TMPro.TextMeshProUGUI _text;

    void Start()
    {
        _text = GetComponent<TMPro.TextMeshProUGUI>();
        _text.text = Gamedata.DotsRemaining.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = Gamedata.DotsRemaining.ToString();
    }
}
