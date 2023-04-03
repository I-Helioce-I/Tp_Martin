using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    string textToDisplay;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.TryGetComponent(out PlayerController playerController))
        {
            UIManager.Instance.SetTutoText(textToDisplay);
            Destroy(gameObject);
        }
    }
}
