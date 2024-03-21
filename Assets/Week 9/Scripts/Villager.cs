using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Villager : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    bool clickingOnSelf;
    bool isSelected;
    public GameObject highlight;

    protected Vector2 destination;
    Vector2 movement;
    protected float speed = 3;

    //This float is public so that it can receive the slider's value from CharacterControl.
    public float scaler = 1;

    //This boolean exists solely to allow us to scale the character before and after a destination
    //has been set. You'll see later in the code.
    bool isDestSet = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        destination = transform.position;
        Selected(false);
    }
    public void Selected(bool value)
    {
        isSelected = value;
        highlight.SetActive(isSelected);
    }

    //private void OnMouseDown()
    //{
    //    CharacterControl.SetSelectedVillager(this);
    //    clickingOnSelf = true;
    //}

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    private void FixedUpdate()
    {
        //While this boolean is active - signifying that no destination has been set - the scale
        //of the character is set based off of a Vector2.one using the scaler float set earlier.
        //Using a Vector2.one allows us to update the localScale properly.
        if (isDestSet == false)
        {
            transform.localScale = Vector2.one * scaler;
        }

        movement = destination - (Vector2)transform.position;

        //Once the isDestSet boolean has been switched, the scaler float is now being multipled onto
        //these two localScale functions. This is necessary to prevent massive amounts of glitching and
        //tearing that would otherwise be caused, since this function is constantly trying to adjust
        //the scale itself.

        //flip the x direction of the game object & children to face the direction we're walking
        if(movement.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1) * scaler;
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1) * scaler;
        }

        //stop moving if we're close enough to the target
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
            speed = 3;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    protected virtual void Update()
    {
        //Here, I added in an extra condition that prevents the mouse from setting a new destination while over any
        //UI elements. This largely felt like a worthwhile change, preventing the characters from constantly moving
        //over to the drop-down menu or the slider, but does admittedly come at the minor cost of preventing the
        //mouse from setting a destination where the individual character names are slightly over their heads.

        //left click: move to the click location
        if (Input.GetMouseButtonDown(0) && isSelected && !clickingOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            //This flips the "is destination set" variable to true.
            isDestSet = true;
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        animator.SetFloat("Movement", movement.magnitude);

        //right click to attack
        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public virtual ChestType CanOpen()
    {
        return ChestType.Villager;
    }
}
