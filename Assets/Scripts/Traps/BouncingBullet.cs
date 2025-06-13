using UnityEngine;

public class BouncingBullet : Bullet
{
    
    protected override void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
         
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
           
            Vector3 knockbackDirection = (collision.transform.position - transform.position).normalized;
            rb.AddForce(knockbackDirection * 50, ForceMode.Impulse);
            Destroy(gameObject);
            return;
        }
        
        PlayHitEffect(collision.contacts[0].point);

       
    }
}