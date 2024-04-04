using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    float move;
    protected float rotation;
    protected float speed;
    protected float rotateSpeed = 1f;
    bool hasFired = false;
    protected bool isActive;
    public GameObject missile;
    public Transform spawn;
    protected Rigidbody2D rb;
    public float fireDelay;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //ensures that no tank is incorrectly selected to begin the game
        selected(false);
    }

    public void selected(bool active)
    {
        //This bool will be used later on to ensure the tank only operates when selected.
        isActive = active;
    }

    public virtual void Update()
    {
        //If the tank is disabled, rotation value (not speed, but direction) is automatically
        //set to 0 and then the entire update function is ended early.
        if (!isActive)
        {
            rotation = 0f;
            return;
        }

        //Takes forwards/backwards input from W/S or UP/DOWN arrow keys.
        move = Input.GetAxis("Vertical");
        
        //Set to -1 because left/right inputs were inverted from intended direction.
        rotation = -1 * Input.GetAxis("Horizontal");

        //HasFired is a bool set within the coroutine itself. This is used to prevent the player
        //from firing more than once within the intended timeframe.
        if (hasFired == false && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(fire());
        }
    }

    IEnumerator fire()
    {
        //Starts by preventing firing again.
        hasFired = true;

        //Fires a missile prefab.
        Instantiate(missile, spawn.position, spawn.rotation);
        
        //Waits for a certain period of time to fire.
        yield return new WaitForSeconds(fireDelay);

        //Once the timer has elapsed, enables firing again and terminates the coroutine.
        hasFired = false;
        yield return null;
    }

    public virtual void FixedUpdate()
    {
        //Adds forwards/backwards force for movement.
        rb.AddForce(transform.up * move * speed);

        //Rotates tank according to directional input.
        rb.rotation += rotation * rotateSpeed;
    }
}
