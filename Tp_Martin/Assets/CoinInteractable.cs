using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteractable : MonoBehaviour
{
    [SerializeField]
    int value;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.TryGetComponent(out Inventory inventory))
        {
            transform.Translate(inventory.transform.position);
            inventory.SetCoin(value);
            Destroy(gameObject);
        }
    }
}
