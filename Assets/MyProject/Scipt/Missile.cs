using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {
   public bool facingRight;
    public int moveSpeed = 10;
    Rigidbody2D rgbd;
    PlayerMovement player;
    Vector2 moveTo;
    public int damage =10;
    public GameObject hitParticleEffect;
	// Use this for initialization
	void Start () {
        rgbd = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        rgbd.velocity = transform.right * moveSpeed;
     }
	
	// Update is called once per frame
	void Update () {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Health health = collision.GetComponent<Health>();
            EnemySprite sp = collision.GetComponentInChildren<EnemySprite>();
            sp.HitNoOfTime++;
            health.TakeDamage(damage);
            Instantiate(hitParticleEffect, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
