using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howToPlay : MonoBehaviour
{
    public GameObject howToPlayButton , panel;
    Animator animator;
    

    public void howToPlayButtonOnClick(){
        animator = GetComponent<Animator>();
        animator.SetTrigger("open");
    }
    public void closeButtonOnClick(){
        animator.SetTrigger("close");
    }
}
