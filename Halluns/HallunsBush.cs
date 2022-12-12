using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallunsBush : MonoBehaviour
{

    public event Action OnFireBush;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip fireSound;
    [SerializeField]
    private Canvas hallunsCanvas;
    [SerializeField]
    private Animator animator;

    public bool isFire;

    public void FireBush()
    {
        if (isFire == false)
        {
            audioSource.PlayOneShot(fireSound);
            hallunsCanvas.enabled = true;
            animator.SetTrigger("FireBush");
            Halluns.fireCount++;
            isFire = true;

            if (OnFireBush != null)
            {
                OnFireBush.Invoke();
            }
        }
    }

}
