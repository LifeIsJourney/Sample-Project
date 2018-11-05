using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    public int moveSpeed;
    Vector3 scale;
    Rigidbody2D rgbd;
    public Transform checkPoint;
    // Use this for initialization
    void Start () {
        rgbd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Collider2D[] col = Physics2D.OverlapPointAll(checkPoint.position, 1);
        
        foreach (Collider2D item in col)
        {

            if (item.tag == "Obstacle")
            {
                
                FlipDirection();
            }
        }
    }
    private void FixedUpdate()
    {
        rgbd.velocity=new Vector2((transform.localScale.x * moveSpeed * Time.deltaTime),rgbd.velocity.y);
    }
    public void FlipDirection()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
