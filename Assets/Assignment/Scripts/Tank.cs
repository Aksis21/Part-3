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
    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        selected(false);
    }

    public void selected(bool active)
    {
        isActive = active;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (!isActive)
        {
            rotation = 0f;
            return;
        }

        move = Input.GetAxis("Vertical");
        
        //Set to -1 because left/right were inverted.
        rotation = -1 * Input.GetAxis("Horizontal");

        if (hasFired == false && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(fire());
        }
    }

    IEnumerator fire()
    {
        hasFired = true;
        Instantiate(missile, spawn.position, spawn.rotation);
        yield return new WaitForSeconds(2);
        hasFired = false;
        yield return null;
    }

    public virtual void FixedUpdate()
    {
        rb.AddForce(transform.up * move * speed);
        rb.rotation += rotation * rotateSpeed;
    }
}
