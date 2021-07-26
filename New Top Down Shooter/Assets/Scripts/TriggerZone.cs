using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public bool playerHere = false;

    private void Update()
    {
        OnTriggerEnter2D(gameObject.GetComponent<Collider2D>());
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") { playerHere = true; };
    }
}
