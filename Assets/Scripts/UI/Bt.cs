using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Menu());
    }

    IEnumerator Menu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
