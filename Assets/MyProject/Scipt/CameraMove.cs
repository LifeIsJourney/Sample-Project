using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    PlayerMovement player;
   public Vector3 offset;
   public Vector2 MaxMinSize;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x != transform.position.x+offset.x)
        {   Vector3 pos = player.transform.position ;
            transform.position =Vector3.Lerp(transform.position, new Vector3(pos.x,transform.position.y,transform.position.z),2*Time.deltaTime) ;
        }
        transform.position =new Vector3( Mathf.Clamp(transform.position.x, MaxMinSize.x, MaxMinSize.y), transform.position.y,transform.position.z);
	}
}
