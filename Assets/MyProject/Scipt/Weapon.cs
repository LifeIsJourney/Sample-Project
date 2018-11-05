using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public float fireRate = 1;
    float fireNow = 0;
    public GameObject missilePrefab;
    public GameObject firePos;
    Animator animator;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Z))
        {
            if (fireNow <= 0)
            {
                animator.SetTrigger("shoot");
                Fire();

                fireNow = fireRate;
            }

        }
        fireNow -= Time.deltaTime;
    }
    void Fire()
    {

        GameObject obj = Instantiate(missilePrefab) as GameObject;
        obj.transform.position = firePos.transform.position;
        obj.transform.rotation = firePos.transform.rotation;
    }
}
