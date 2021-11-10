using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePerso : MonoBehaviour
{
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // for (int i = 1; i < 10; i++)
        // {
        //     Animator.ResetTrigger(i.ToString());
        // }
        if (Input.GetButtonDown("Down Left"))
        {
            Animator.SetTrigger("1");
        }
        if (Input.GetButtonDown("Down"))
        {
            Animator.SetTrigger("2");
        }
        if (Input.GetButtonDown("Down Right"))
        {
            Animator.SetTrigger("3");
        }
        if (Input.GetButtonDown("Left"))
        {
            Animator.SetTrigger("4");
        }
        if (Input.GetButtonDown("Central"))
        {
            Animator.SetTrigger("5");
        }
        if (Input.GetButtonDown("Right"))
        {
            Animator.SetTrigger("6");
        }
        if (Input.GetButtonDown("Up Left"))
        {
            Animator.SetTrigger("7");
        }
        if (Input.GetButtonDown("Up"))
        {
            Animator.SetTrigger("8");
        }
        if (Input.GetButtonDown("Up Right"))
        {
            Animator.SetTrigger("9");
        }
    }
}
