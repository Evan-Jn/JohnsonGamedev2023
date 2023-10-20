using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    private KeyManager km;
    [SerializeField]
    private int key;

    // Start is called before the first frame update
    void Start()
    {
        km = GameObject.FindGameObjectWithTag("KeyManager").GetComponent<KeyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if (!isLocked)
        {
            km.UnlockKey(key);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("This door is locked, sorry!");
            
        }

    }
}
