using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Rigidbody2D rgbd;
    bool flipDirection;
    bool isGrounded;
    Vector3 localScale;
    public float spawnRate;
    public int moveSpeed=20;
    public Transform frontCheck;
	// Use this for initialization
	void Start () {
        rgbd = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

        //if (isGrounded)
        //{
        //    rgbd.gravityScale = 3;
        //    if (flipDirection)
        //    {
        //        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        //        rgbd.MovePosition(transform.position + Vector3.right * moveSpeed * Time.deltaTime);

        //    }
        //    else
        //    {
        //        transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

        //        rgbd.MovePosition(transform.position + Vector3.left * moveSpeed * Time.deltaTime);
        //    }
        //    isGrounded = false;
        //}
        //else
        //{

        //    rgbd.gravityScale = 5;
        //}
       Collider2D[] col = Physics2D.OverlapPointAll(frontCheck.position, 1);
        foreach (Collider2D item in col)
        {
            if(item.tag == "wall")
            {
                FlipDirection();
                break;
            }
        }

        if (isGrounded)
        {
            rgbd.velocity = new Vector2(transform.localScale.x * moveSpeed, rgbd.velocity.y);
        }
    }

    void FlipDirection() {
        Vector3 scale = transform.localScale;
        scale *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   if(collision.collider.tag == "wall")
        {

            flipDirection = !flipDirection;
        }
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {   
        isGrounded = true;
    }
}
