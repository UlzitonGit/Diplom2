using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private float _time;
    [SerializeField] private Rigidbody _rb;
    private bool _stop = false;
    private void Update()
    {
        if(_stop) return;
        _time += Time.deltaTime;
        _textMeshPro.text = _time.ToString();
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
