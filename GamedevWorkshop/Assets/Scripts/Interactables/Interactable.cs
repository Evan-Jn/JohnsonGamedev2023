using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this is the base class for interactable objects

public abstract class Interactable : MonoBehaviour
{
    //generic variables for all interactables
    protected bool isLocked = false;



    //generic methods for all interactabes
    public void setLockState(bool state)
    {
        isLocked = state;
    }

    public abstract void Interact();

}
