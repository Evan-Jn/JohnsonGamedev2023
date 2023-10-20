using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    private int interactablesLayer;
    private Transform source;
    private Transform storedObject;
    [SerializeField]
    private Image indicator;
    [SerializeField]
    private Sprite none, something;
    void Start()
    {
        source = Camera.main.transform;
        interactablesLayer = 1 << LayerMask.NameToLayer("Interactable");
    }

    // Update is called once per frame
    void Update()
    {
        InteractScan();
    }

    public void InteractScan()
    {
        //look for colliders within 1m that are part of the interactable layer
        RaycastHit hit;
        if(Physics.Raycast(source.position, source.forward, out hit, 2f, interactablesLayer))
        {
            storedObject = hit.transform;
            indicator.sprite = something;
        } else
        {
            storedObject = null;
            indicator.sprite = none;
        }
    }

    public void InteractInput(InputAction.CallbackContext context)
    {
        if (context.performed && storedObject != null)
        {
            storedObject.GetComponent<Interactable>().Interact();
        }
    }


}
