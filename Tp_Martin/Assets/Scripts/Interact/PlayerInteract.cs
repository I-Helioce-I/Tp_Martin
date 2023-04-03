using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            IInteract interactable = GetInteractableOject();
            if (interactable != null)
            {
                interactable.Interact(transform);
            }
        }
    }

    public IInteract GetInteractableOject()
    {
        List<IInteract> interactables = new List<IInteract>();
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IInteract interactable))
            {
                interactables.Add(interactable);
            }

        }

        IInteract closestInteractable = null;
        foreach (IInteract interactable in interactables)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                {
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }
}
