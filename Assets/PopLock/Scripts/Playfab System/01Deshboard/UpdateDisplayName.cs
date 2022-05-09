using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class UpdateDisplayName : MonoBehaviour
{
    [SerializeField] InputField _newDisplayName;
    [SerializeField] Text _asyncText;
    public void UpdateDisplayNameOnClick()
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest() { DisplayName = _newDisplayName.text },
         result =>
          {
              _asyncText.text = "İsim güncelleniyor";
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          }, error => { });
    }
}
