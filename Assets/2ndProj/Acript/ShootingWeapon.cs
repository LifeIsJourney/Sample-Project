using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeapon : MonoBehaviour {
    public float fireRate;
    float fireNow;
    public GameObject bullet;
    public Transform firePos;
     Transform weapon;
    Vector3 mousePos;
    public Transform pointToRotate;
    public float rotateSpeed=10;
	// Use this for initialization
	void Start () {
        weapon = transform.Find("Weapon");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RotatingWeapon();
            //TakeMousePosition and look at that
             Shoot();
        }
        fireNow -= Time.deltaTime;
    }
    void Shoot()
    {
        
        if (fireNow < 0)
        {
            GameObject obj = Instantiate(bullet, firePos.position, pointToRotate.rotation);
            fireNow = 1/fireRate;

        }

    }
    
    //lookung at the direction of mouse
    void RotatingWeapon()
    {
        //mouse pos
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //direction B-A
        Vector3 direction = (mousePos-pointToRotate.position);
        //angle
        float angle =Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        //rotation using angle
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        pointToRotate.rotation = rotation;


    }

}
