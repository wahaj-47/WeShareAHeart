using UnityEngine;
using TMPro;

public interface IInteractable
{
    GameObject UI { get; }

    void Interact(PlayerStateManager interactor);
    
    void DisplayPrompt(int playerId)
    {
        if(this.UI != null)
        {
            TextMeshProUGUI Key = this.UI.transform.Find("Key").GetComponent<TextMeshProUGUI>();
            if (playerId == 1) Key.text = "E";
            else Key.text = "U";
            this.UI.SetActive(true);
        }
    }

    void HidePrompt()
    {
        if (this.UI != null)
            this.UI.SetActive(false);
    }
}
