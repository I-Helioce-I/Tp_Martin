using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField]
    GameObject containerGO;
    [SerializeField]
    PlayerInteract playerInteract;
    [SerializeField]
    TextMeshProUGUI interactTextMeshPro;

    private void Update()
    {
        if (playerInteract.GetInteractableOject() != null)
        {
            Show(playerInteract.GetInteractableOject());
        }
        else
        {
            Hide();
        }
    }

    private void Show(IInteract interact)
    {
        containerGO.SetActive(true);
        interactTextMeshPro.text = interact.GetInteractText();
    }

    private void Hide()
    {
        containerGO.SetActive(false);
    }
}
