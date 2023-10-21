using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    private AudioSource myAudioSource;
    [SerializeField]
    private Animator myAnimator, myOtherAnimator;



    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact()
    {
        if (!isLocked)
        {
            myAudioSource.Play();
            myAnimator.SetBool("Open", true);
            myOtherAnimator.SetBool("Open", true);


        }
        else
        {
            Debug.Log("This door is locked, sorry!");
            
        }

    }
}
