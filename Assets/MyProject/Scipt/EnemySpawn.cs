using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
   public Transform[] spawnpos;
    public GameObject[] enemies;
    bool canSpawn;
    GameObject spawnThis;
    private void Awake()
    {

        spawnpos = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount ; i++)
        {
            spawnpos[i] = transform.GetChild(i);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        foreach (GameObject obj in enemies)
        {
            if (IsTimeToSpawn(obj))
            {
                Spawn(obj);
            }
        }

    }

    bool IsTimeToSpawn(GameObject obj)
    {
       
            float frequency = 1 / obj.GetComponent<EnemyMovement>().spawnRate;
            float threasHold = frequency * Time.deltaTime/10;
            if (Random.value < threasHold)
            {

                canSpawn = true;
                spawnThis = obj;
                return true;
            }
            else
            {
                
                canSpawn = false;
                return false;
            }
       
    }
    void Spawn(GameObject obj)
    {   int spawnPosition = Random.Range(0, 3);
        for (int i =0;i< spawnpos.Length; i++)
        {
            if(i== spawnPosition)
            {
               GameObject enemyObj = Instantiate(obj);
                enemyObj.transform.position = spawnpos[i].position;
                enemyObj.transform.rotation = spawnpos[i].rotation;
                enemyObj.transform.parent = spawnpos[i].transform;
            }
        }
        
    }
}
