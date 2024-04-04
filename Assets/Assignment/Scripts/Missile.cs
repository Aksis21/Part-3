using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //adds initial force to the missile so it moves in its spawned direction
        //speed is public so it can be adjusted for each missile type if necessary
        rb.AddForce(transform.up * speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
