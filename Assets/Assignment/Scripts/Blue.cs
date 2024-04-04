using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : Tank
{
    Vector2 target;
    float rotAngle;
    public float thisSpeed;

    public override void Start()
    {
        base.Start();

        //Sets the speed of this tank to its own custom speed.
        //Placed in start rather than update since it will not need to be reset.
        speed = thisSpeed;
    }

    public override void Update()
    {
        base.Update();

        //This tank uses the mouse position instead of A and D to rotate towards a target.
        //The following function determines the mouse's position and sets the tank to face
        //towards it.
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
        //Detects if the tank is currently selected or not and only allows the tank to lock
        //onto the mouse's position if it is currently selected.
        if (isActive)
        {
            transform.up = target;
        }
    }

    public override void FixedUpdate()
    {
        //By updating rotation to 0, this disables the A and D keys from having any input
        //on the tank's rotation.
        rotation = 0;
        base.FixedUpdate();
    }
}