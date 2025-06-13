using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObject : MonoBehaviour
{
    [SerializeField] private float delay = 5;
    [SerializeField] private AudioClip tutorialClip;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private AudioSource tutorialAudioSource;
    [SerializeField] private bool moveTutorial;
    [SerializeField] private bool dashTutorial;
    [SerializeField] private bool slideTutorial;
    [SerializeField] private bool climbTutorial;
    [SerializeField] private bool wallrunTutorial;
    private bool started;
    private PlayerMovementAdvanced player;
    private Tutorial tutorial;
    
    private bool isPlayed;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovementAdvanced>(true);
        if (moveTutorial) tutorial = FindObjectOfType<PlayerMovementAdvanced>(true);
        if (dashTutorial) tutorial = FindObjectOfType<Dashing>(true);
        if (slideTutorial) tutorial = FindObjectOfType<Sliding>(true);
        if (climbTutorial) tutorial = FindObjectOfType<ClimbingDone>(true);
        if (wallrunTutorial) tutorial = FindObjectOfType<WallRunningAdvanced>(true);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !started)
        {
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        started = true;
        tutorialAudioSource.PlayOneShot(tutorialClip);
        tutorialPanel.SetActive(true);
        player.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(delay);
        player.GetComponent<Rigidbody>().isKinematic = false;
        tutorialPanel.SetActive(false);
        tutorial.enabled = true;
    }
}
