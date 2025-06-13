using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spiketrap : MonoBehaviour
{
    UiLogic uiLogic;
    public LayerMask Player;
    private void Start()
    {
        uiLogic = FindObjectOfType<UiLogic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & Player.value) != 0)
        {
            uiLogic.Death();
        }
    }
}
