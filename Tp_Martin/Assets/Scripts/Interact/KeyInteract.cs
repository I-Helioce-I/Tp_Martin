using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteract : MonoBehaviour, IInteract
{
    [SerializeField]
    GameObject doorToOpen;

    [SerializeField]
    ActivateMovementElement nextZone;

    public string GetInteractText()
    {
        return "Get Key";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(Transform interactorTransform)
    {
        doorToOpen.GetComponent<Animator>().SetBool("OpenDoor", true);

        if(nextZone != null)
        {
            nextZone.gameObject.SetActive(true);
            nextZone.enabled = true;
        }

        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
