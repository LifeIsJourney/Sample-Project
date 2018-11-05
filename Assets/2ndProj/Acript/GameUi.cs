using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUi : MonoBehaviour {
    public Texture2D cursor;
	// Use this for initialization
	void Start () {
        //Cursor.visible = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //  transform.position = new Vector3(pos.x, pos.y, 0);
        //change the cursor image
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
	}
}
