using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteract 
{
    void Interact(Transform interactorTransform);
    string GetInteractText();
    Transform GetTransform();
}
