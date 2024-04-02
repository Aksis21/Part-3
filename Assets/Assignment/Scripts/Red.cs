using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : Tank
{
    public override void Start()
    {
        base.Start();
        speed = 20f;
        rotateSpeed = 3;
    }
}
