using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : Interactable
{
    private AudioSource myAudioSource;
    [SerializeField]
    private Animator myAnimator, myOtherAnimator;
    private float cooldown = 3f;


    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if(cooldown > 3f)
        {
            gameObject.layer = 7;
        } else
        {
            gameObject.layer = 0;
        }
    }

    public override void Interact()
    {
        if (!isLocked && cooldown > 3f)
        {
            cooldown = 0f;
            myAudioSource.Play();
            myAnimator.SetBool("Open", !myAnimator.GetBool("Open"));
            myOtherAnimator.SetTrigger("close");

        }
        else
        {
            Debug.Log("This door is locked, sorry!");
            
        }

    }
}
