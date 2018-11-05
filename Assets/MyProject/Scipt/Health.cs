using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int health;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }
	}
    public void TakeDamage(int value)
    {
        health -= value;
    }
}
