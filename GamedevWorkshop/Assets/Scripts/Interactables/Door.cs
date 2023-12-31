using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private AudioSource myAudioSource;
    private Animator myAnimator;

    private KeyManager km;
    [SerializeField]
    private int reqKey = 0;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        km = GameObject.FindGameObjectWithTag("KeyManager").GetComponent<KeyManager>();
        myAnimator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if (!isLocked || km.hasKey(reqKey))
        {
            myAudioSource.Play();
            myAnimator.SetBool("Open", true);
            gameObject.layer = 0;
        }
        else
        {
            Debug.Log("This door is locked, sorry!");
            
        }

    }
}
