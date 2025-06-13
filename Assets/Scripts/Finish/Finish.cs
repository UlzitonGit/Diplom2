using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private float _time;
    [SerializeField] private Rigidbody _rb;
    private bool _stop = false;
    private void Update()
    {
        if(_stop) return;
        _time += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _stop = true;
            _rb.isKinematic = true;
            float pref = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString());
            if (_time < pref)
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(), _time);
            }
            _finishPanel.SetActive(true);
        }
    }
}
