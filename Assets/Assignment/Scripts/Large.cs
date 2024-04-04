using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Large : Tank
{
    public float thisSpeed;
    public override void Update()
    {
        //The large tank takes the base functionality
        base.Update();

        //Sets the custom speed of this tank.
        speed = thisSpeed;

        //Sets the custom movement system for the large tank.
        //Still operates with standard WASD or Arrow keys, but this prevents
        //the large tank from turning and moving forwards/backwards at the same
        //time to convey its "size". The parameters are set to 0.5 instead of
        //just 0 so it feels more natural.
        if (rotation > 0.5 || rotation < -0.5)
        {
            speed = 0f;
        }
    }
}
