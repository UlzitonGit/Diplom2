using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource _walkAudioSource;
    [SerializeField] private AudioSource _onetimeAudioSource;
    [SerializeField] private AudioClip _walkClip;
    [SerializeField] private AudioClip _wallrunClip;
    [SerializeField] private AudioClip _slideClip;
    [SerializeField] private AudioClip _climbClip;
    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private AudioClip _dashClip;

    public void StopWalking()
    {
        _walkAudioSource.mute=true;
    }

    public void StopSounds(bool state)
    {
        _walkAudioSource.enabled=state;
    }
    public void Walking()
    {
        _walkAudioSource.pitch=1;
        _walkAudioSource.mute=false;
        print("walking");
    }
    public void Running()
    {
        _walkAudioSource.pitch=1.5f;
        _walkAudioSource.mute=false;
    }
    public void PlayJumpSound()
    {
        _onetimeAudioSource.PlayOneShot(_jumpClip);
    }
    public void PlaySlideSound()
    {
        _onetimeAudioSource.PlayOneShot(_slideClip);
    }
    public void PlayDashSound()
    {
        _onetimeAudioSource.PlayOneShot(_dashClip);
    }

 
    
}
