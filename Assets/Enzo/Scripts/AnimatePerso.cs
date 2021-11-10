using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePerso : MonoBehaviour
{
    public Animator Animator;

    // Update is called once per frame
    void Update()
    {
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

    public void BadAnimation()
    {
        Animator.SetTrigger("Bad");
    }
}
