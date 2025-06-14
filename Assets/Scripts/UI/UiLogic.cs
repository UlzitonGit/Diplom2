using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiLogic : MonoBehaviour
{
    [SerializeField] private PlayerMovementAdvanced playerMovement;//
    [SerializeField] protected PlayerCam playerCam;//
    public GameObject RestartMenu;

    public Image[] images; // ���� ������ �����������, ��� ����� ���� ������
    public float fadeDuration = 2f; // ����� �� ������ ����������
    private Coroutine fadeCoroutine;
    private bool isFullyVisible = false;

    void Start()
    {
        playerCam = FindObjectOfType<PlayerCam>();
        playerMovement = FindObjectOfType<PlayerMovementAdvanced>();
        RestartMenu = FindObjectOfType<Restart>(true).gameObject;
        SetAlpha(0f);
    }

    void Update()
    {
        if (!isFullyVisible && Input.GetMouseButtonDown(0) && fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
            SetAlpha(1f);
            isFullyVisible = true;
        }
    }

    IEnumerator FadeIn()
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            float alpha = elapsed / fadeDuration;
            SetAlpha(alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Time.timeScale = 0;
        SetAlpha(1f);
        isFullyVisible = true;
    }

    public void Death()
    {
        playerMovement.enabled = false;//
        playerCam.enabled = false;//
        playerMovement.GetComponent<Rigidbody>().isKinematic = true;
        RestartMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fadeCoroutine = StartCoroutine(FadeIn());
    }
    void SetAlpha(float alpha)
    {
        foreach (Image img in images)
        {
            Color c = img.color;
            c.a = alpha;
            img.color = c;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

}
