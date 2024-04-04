using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : Tank
{
    public float thisSpeed;
    public float rotationSpeed;
    public override void Start()
    {
        //Takes all the base tank functionality but sets the speed and rotation speed
        //to custom variables that can be set in the main Unity editor.
        base.Start();
        speed = thisSpeed;
        rotateSpeed = rotationSpeed;
    }
}
