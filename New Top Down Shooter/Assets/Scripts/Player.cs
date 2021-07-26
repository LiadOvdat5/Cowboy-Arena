using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //player info 
    public float runSpeed = 3f;
    public float rotationSpeed = 6f;
    public float playerHealth = 100f;
    public float playerMaxLife = 100f;

    //joysticks refernces
    public Joystick movementJoystick;
    public Joystick directionJoystick;


    public HealthBar healthBar;

    //static variables
    Rigidbody2D rb;
    Vector2 movement;
    Vector2 direction;
    float heading;
    SceneLoader SceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth(playerMaxLife);
        SceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        

        //Horizontal and Vertical Movement
        
            movement.x = movementJoystick.Horizontal;
            movement.y = movementJoystick.Vertical;

        //Horizontal and Vertical Direction
        direction.x = directionJoystick.Horizontal;
        direction.y = directionJoystick.Vertical;
        
    }

    private void FixedUpdate()
    {
        //Impliment Movement
        rb.MovePosition(rb.position + movement * runSpeed * Time.fixedDeltaTime);

        //Impliment Direction
        heading = Mathf.Atan2( direction.y, direction.x) * Mathf.Rad2Deg;
        if(heading != 0)
        {

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, heading - 90)), Time.deltaTime * rotationSpeed);
         
        }
    }


    public void PlayerHit(float damage)
    {
        playerHealth -= damage;
        
        // Debug.Log("hit");    //for checking when hit operates
        
        healthBar.SetHealth(playerHealth);

        if (playerHealth <= 0)
        {
            PlayerDie();
        }
    }

    void PlayerDie()
    {
        //play Die animation
        Destroy(gameObject);
        SceneLoader.LoadDeadScene();
    }

}
