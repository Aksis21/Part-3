using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : Tank
{
    Vector2 target;
    float rotAngle;
    public float rotSpeed;

    public override void Update()
    {
        base.Update();
        speed = 20f;

        target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (isActive)
        {
            transform.up = target;
        }
    }

    public override void FixedUpdate()
    {
        rotation = 0;
        base.FixedUpdate();
    }
}