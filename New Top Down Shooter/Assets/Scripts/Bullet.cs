using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float bulletDamage = 50f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.tag == "Enemy")
        {
            
            collision.GetComponent<Enemy>().EnemyHit(bulletDamage);
        }

        //Debug.Log(collision.gameObject.name);
        
        Destroy(gameObject);
    }
}
