using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Large : Tank
{
    public override void Update()
    {
        base.Update();
        speed = 10f;
        if (rotation > 0.5 || rotation < -0.5)
        {
            speed = 0f;
        }
    }
}
