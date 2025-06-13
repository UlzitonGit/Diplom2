using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip onOverlap;
    [SerializeField] private AudioClip onClicled;

    private void OnMouseEnter()
    {
        audioSource.PlayOneShot(onOverlap);
        print("enter");
    }

    private void OnMouseDown()
    {
        audioSource.PlayOneShot(onClicled);
    }
}
