using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if (!isLocked)
        {
            Debug.Log("I am a door! One day I will take you somewhere!");
        }
        else
        {
            Debug.Log("This door is locked, sorry!");
        }

    }
}
