using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "VraKon/BulletConfig")]
public class BulletConfig : ScriptableObject
{
    [Header("Общие настройки снаряда")]
    public string bulletName = "DefaultBullet";
    public enum BulletType { Normal, Bouncing }
    public BulletType type = BulletType.Normal;
    public float speed = 10f; 
    public GameObject prefab;
    

    [Header("Визуальные эффекты")]
    public Color bulletColor = Color.white;
    public ParticleSystem hitEffect; 

    [Header("Аудио")]
    public AudioClip hitSound; 
}