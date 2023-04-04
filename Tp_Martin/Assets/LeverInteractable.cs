using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteractable : MonoBehaviour, IInteract
{
    ActivateMovementElement elementToMove;

    private void Start()
    {
        elementToMove = GetComponent<ActivateMovementElement>();
    }

    public string GetInteractText()
    {
        return "Use Lever";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(Transform interactorTransform)
    {
        foreach (GameObject element in elementToMove.levelElements)
        {
            element.GetComponent<MoveLevelElement>().target = new Vector3(0, 100, 0);
            element.GetComponent<MoveLevelElement>().SetInPlaceBool();
        }
        Destroy(this, 1);
    }
}
