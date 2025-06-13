using UnityEngine;

[CreateAssetMenu(fileName = "VraKonTurretConfig", menuName = "VraKon/TurretConfig")]
public class VraKonTurretConfig : ScriptableObject
{
    [Header("Общие настройки")]
    public string turretName = "VraKon";
    public enum TurretType { Normal, Bouncing }
    [Tooltip("Тип Турели")]
    public TurretType type = TurretType.Normal;
    [Tooltip("Цвет Турели")]
    public Color color = Color.red; // Для красной или оранжевой турели

    [Header("Активация")]
    public bool isActive = true;
    [Tooltip("Время активации")]
    public float activationTime = 1f; 
    [Tooltip("Время деактивации")]
    public float deactivationTime = 1f;
 

    [Header("Движение")]
    [Tooltip(" Радиус круга для движения")]
    public float movementRadius = 5f;
    [Tooltip("Скорость движения")]
    public float movementSpeed = 2f;
    [Tooltip("Скорость поворота")]
    public float rotationSpeed = 90f;

    [Header("Стрельба")]
    [Tooltip("Скорость стрельбы")]
    public float fireRate = 1f;
    [Tooltip("Радиус обнаружения")]
    public float detectionRadius = 10f;
    public BulletConfig bulletConfig;


    [Header("Аудио")]
    public AudioClip fireSound;
    
    [Header("Снаряд")]
    public GameObject projectilePrefab;
}