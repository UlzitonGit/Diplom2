using UnityEngine;

public class VraKonTurret : MonoBehaviour
{
    [SerializeField] private VraKonTurretConfig config;
    [SerializeField] private Transform firepoint;
    private Transform player;
    private float nextFireTime;
    private Vector3 movementCenter;
    private Vector3 targetPoint;
    private bool isActive;
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        isActive = config.isActive;
        movementCenter = transform.position;
        PickNewTargetPoint();
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null) renderer.material.color = config.color;

       
    }

    void Update()
    {
        if (!isActive) return;
        MoveTurret();
        if (IsPlayerInRange())
        {
            AimAtPlayer();
            TryFire();
        }
    }

    bool IsPlayerInRange()
    {
        if (player == null) return false;
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= config.detectionRadius)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.position - transform.position, out hit, config.detectionRadius))
            {
                return hit.transform == player;
            }
        }
        return false;
    }

    void AimAtPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, config.rotationSpeed * Time.deltaTime);
    }

    void TryFire()
    {
        if (Time.time >= nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + 1f / config.fireRate;
            
            if (config.fireSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(config.fireSound);
            }

        }
    }

    void FireProjectile()
    {
        if (config.bulletConfig == null || config.bulletConfig.prefab == null) return;

        GameObject projectile = Instantiate(config.bulletConfig.prefab, transform.position, transform.rotation);
        Bullet bullet = projectile.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Initialize(config.bulletConfig);
        }
    }

    void MoveTurret()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, config.movementSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            PickNewTargetPoint();
        }
    }

    void PickNewTargetPoint()
    {
        float randomAngle = Random.Range(0f, 360f);
        float randomRadius = Random.Range(0f, config.movementRadius);
        targetPoint = movementCenter + new Vector3(
            Mathf.Cos(randomAngle) * randomRadius,
            0,
            Mathf.Sin(randomAngle) * randomRadius
        );
    }
    
}