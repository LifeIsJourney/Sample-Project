using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour {
    protected Transform thisTransform;
    protected Vector3 startPos;
    protected float verticalVelocity;

    private void Start()
    {
        thisTransform = transform;
        startPos = transform.position;
    }
    private void Update()
    {
        Move();
    }

    //virtual means it will look in the child class for this method
    //protected keyword.  only accessible to the child class
    protected virtual void Move()
    {
        Vector3 pos = startPos + Vector3.right * Mathf.Sin(Time.time);
        //theis will bring the obj down
        verticalVelocity -= 14 *Time.deltaTime;
        if(verticalVelocity < 0)
        {
            verticalVelocity = 0;
        }
        pos.y = verticalVelocity+startPos.y;

        transform.position = pos;
    }
    protected virtual void Talk()
    {
        Debug.Log("I am talking");
    }
    protected virtual void Jump()
    {
        verticalVelocity = 2;
    }
}
