using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact(Transform handTransform);
    public void Interact(HandInteractor hand);
    //public void Interact();
}
