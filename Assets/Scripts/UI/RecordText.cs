using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordText : MonoBehaviour
{
    [SerializeField] private int _levelIndex = 0;
    private TextMeshProUGUI _textMeshPro;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        float pref = PlayerPrefs.GetFloat(_levelIndex.ToString());
        string prefStr = pref.ToString();
        if(pref == 0) _textMeshPro.text = "not complited";
        else _textMeshPro.text = prefStr[0].ToString() + prefStr[1].ToString() + prefStr[2].ToString();
    }
}
