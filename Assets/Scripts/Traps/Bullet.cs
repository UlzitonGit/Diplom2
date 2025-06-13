using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected BulletConfig config;
    protected Rigidbody rb;
    protected AudioSource audioSource;
    private PlayerMovementAdvanced playerMovement;
    private PlayerCam playerCam;
    public GameObject RestartMenu;
    private float lifetime = 2f; 
    private float spawnTime;
    
    private bool isFullyVisible = false;

    public virtual void Initialize(BulletConfig bulletConfig)
    {
        config = bulletConfig;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        playerMovement = FindObjectOfType<PlayerMovementAdvanced>();
        playerCam = FindObjectOfType<PlayerCam>();
        spawnTime = Time.time;
        if (rb != null)
        {
            rb.velocity = transform.forward * config.speed;
        }

        // Установка цвета
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = config.bulletColor;
        }
    }

    private void Update()
    {
        if (Time.time >= spawnTime + lifetime)
        {
            Debug.Log("Bullet destroyed");
            Destroy(gameObject);
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.enabled = false;
            playerCam.enabled = false;
            RestartMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
            
        PlayHitEffect(collision.contacts[0].point);
        Destroy(gameObject);
        return;
        
    }

    protected void PlayHitEffect(Vector3 position)
    {
        // Воспроизведение эффекта попадания
        if (config.hitEffect != null)
        {
            Instantiate(config.hitEffect, position, Quaternion.identity);
        }

        // Воспроизведение звука попадания
        if (config.hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(config.hitSound);
        }
    }
}