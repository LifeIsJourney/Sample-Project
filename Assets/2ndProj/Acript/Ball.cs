using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    Rigidbody2D rgbd;
    public int moveSpeed=10;
    public GameObject deathParticle;
    public GameObject stains;
	// Use this for initialization
	void Start () {
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.velocity =transform.right * moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.tag == "Enemy")
        {
            //destroying enemy
            Instantiate(deathParticle, collision.transform.transform.position,
                Quaternion.identity);
            Instantiate(stains, collision.transform.position, Quaternion.identity);

        }
    }
}
