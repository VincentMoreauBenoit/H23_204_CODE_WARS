using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitch : MonoBehaviour
{
    
    Animator Animator;

    private void Start()
    {
        Animator = gameObject.GetComponent<Animator>();
    }

    public void AnimateIDLE() 
    {
        ResetBools();
        Animator.GetComponent<Animator>().SetBool("idle", true);
    }

    public void AnimateAttack()
    {
        ResetBools();
        Animator.GetComponent<Animator>().SetBool("attack", true);
        Invoke("Addidle",0.1f);
    }
    public void AnimateDeath()
    {
        ResetBools();
        Animator.GetComponent<Animator>().SetBool("death", true);
    }
    public void AnimateJump()
    {
        ResetBools();
        Animator.GetComponent<Animator>().SetBool("jump", true);
        Invoke("Addidle", 0.1f);
    }
    public void AnimateRun()
    {
        ResetBools();
        Animator.GetComponent<Animator>().SetBool("run", true);
    }
    public void AnimateWalk()
    {
        ResetBools();
        Animator.GetComponent<Animator>().SetBool("walk", true);
    }

    private void ResetBools() 
    {
        Animator.GetComponent<Animator>().SetBool("idle", false);
        Animator.GetComponent<Animator>().SetBool("attack", false);
        Animator.GetComponent<Animator>().SetBool("death", false);
        Animator.GetComponent<Animator>().SetBool("jump", false);
        Animator.GetComponent<Animator>().SetBool("run", false);
        Animator.GetComponent<Animator>().SetBool("walk", false);
    }
    private void Addidle() 
    {
       Animator.GetComponent<Animator>().SetBool("idle", true);
    }
}
