using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject knifePrefab;
    public Transform spawnPoint;
    public float delay1 = 0.1f;
    public float delay2 = 0.2f;
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    protected override void Attack()
    {
        base.Attack();
        Invoke("SpawnDagger", delay1);
        Invoke("SpawnDagger", delay2);
        Invoke("SpeedIncrease", delay1);
        Invoke("SpeedDecrease", delay2);
    }

    void SpawnDagger()
    {
        Instantiate(knifePrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void SpeedIncrease()
    {
        speed = 30;
    }

    void SpeedDecrease()
    {
        speed = 3;
    }
}
