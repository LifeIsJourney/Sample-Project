using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bGpROPsPAWN : MonoBehaviour {
    public Rigidbody2D backgroundProp;      // The prop to be instantiated.
    public float leftSpawnPosX;             // The x coordinate of position if it's instantiated on the left.
    public float rightSpawnPosX;            // The x coordinate of position if it's instantiated on the right.
    public float minSpawnPosY;              // The lowest possible y coordinate of position.
    public float maxSpawnPosY;              // The highest possible y coordinate of position.
    public float minTimeBetweenSpawns;      // The shortest possible time between spawns.
    public float maxTimeBetweenSpawns;      // The longest possible time between spawns.
    public float minSpeed;                  // The lowest possible speed of the prop.
    public float maxSpeed;                  // The highest possible speeed of the prop.

    // Use this for initialization
    void Start () {
        //random value
        Random.InitState(System.DateTime.Today.Millisecond);
        Debug.Log("init");
        StartCoroutine("startSpawn");
	}
	
	IEnumerator startSpawn()
    {
        float waitTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
        Debug.Log("waitTime");
        yield return new WaitForSeconds(waitTime);

        bool leftFacing = Random.Range(0,2) == 0;

        float posX = leftFacing ? rightSpawnPosX: leftSpawnPosX;
        float posY = Random.Range(minSpawnPosY, maxSpawnPosY);
        Vector3 propPos = new Vector3(posX, posY, transform.position.z);
        Debug.Log(propPos);
        Rigidbody2D rb = Instantiate(backgroundProp, propPos, Quaternion.identity) as Rigidbody2D;
        Debug.Log("Instantioated");
        if (!leftFacing)
        {
            Vector3 scale = rb.transform.localScale;
            scale.x *= -1;
            rb.transform.localScale = scale;
        }
        float speed = Random.Range(minSpeed, maxSpeed);

        speed *= leftFacing ? -1 : 1;
        rb.velocity = new Vector3(speed, 0, 0);
        StartCoroutine(startSpawn());

        while (rb != null)
        {
            if (leftFacing)
            {
                if (rb.transform.position.x < leftSpawnPosX - 0.5f)
                {
                      Destroy(rb.gameObject);
                }
            }
            else
            {
                if (rb.transform.position.x > rightSpawnPosX + 0.5f)
                {
                       Destroy(rb.gameObject);
                }
            }
            yield return null;
        }
        
    }
}
