using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour {
    public int destroyInSec;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyInSec);
	}
	
	
}
