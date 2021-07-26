using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    
    public float moveSpeed = 2f;

    //wanted ranges from player for actions
    public float detectionRange = 2f;
    public float attackingRange = 1f;

    //enemy health and power against player
    public float enemyHealth = 100f;
    public float enemyPower = 50f;

    //wanted times between attacks
    public float nextTimeAttack = 1f;
    public float attackRate = 2f;

    public KillsCounter killsCounter;

    //static variables
    Rigidbody2D rb;
    Vector2 movement;
    public float distanceFromPlayer = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>().transform;
        killsCounter = FindObjectOfType<KillsCounter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //impliment the direction
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        if (PlayerInRange(distanceFromPlayer, detectionRange))
            rb.rotation = -angle;

        direction.Normalize();
        movement = direction;


        
        distanceFromPlayer = Vector2.Distance(player.position, transform.position);  //get the distance between player and enemy

        
        
    }


    private void FixedUpdate()
    {
        if (PlayerInRange(distanceFromPlayer, detectionRange) && !PlayerInRange(distanceFromPlayer, attackingRange))  //if player in detection range, move towards him
        {
            MoveEnemy(movement);
        }
        if (PlayerInRange(distanceFromPlayer, detectionRange) && PlayerInRange(distanceFromPlayer, attackingRange) && Time.time > nextTimeAttack) //if player in attack range, attack him every 1 second
        {
            player.GetComponent<Player>().PlayerHit(enemyPower); //enemy attack player
            nextTimeAttack = Time.time + 1 / attackRate;


           // Debug.Log("enemy number" + GameObject.FindGameObjectsWithTag("Enemy").Length + "hit you  |   distance from player and attack range (" + distanceFromPlayer + "|| " +attackingRange );
        }
    }
    
    
    void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }


    bool PlayerInRange(float distance, float range)  //check if enemy is in wanted range
    {
        if (distance <= range)
        {
            return true;
        }
        else return false;
    }  

    private void OnDrawGizmos()
    {
        if (transform.position == null)
            return;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.DrawWireSphere(transform.position, attackingRange);
    }



    public void EnemyHit(float damage)
    {
        enemyHealth -= damage;
        //play Hit animation 

        if(enemyHealth <= 0)
        {
            EnemyDie();
        }
    }

    void EnemyDie()
    {

        killsCounter.AddKill();
        //play die animation
        Destroy(gameObject);
    }

    

}
