using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Creature {

    protected override void Move()
    {
        base.Move();
        thisTransform.position += Vector3.up * Mathf.Sin(Time.time); 
    }
}
