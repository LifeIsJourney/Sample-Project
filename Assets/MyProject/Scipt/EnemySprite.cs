using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// change the sprite of the enemy based on the HitNoOfTime.
/// which is provided by missile when hit.
/// </summary>
public class EnemySprite : MonoBehaviour {
    public Sprite[] enemyImage;

    Health health;
    public int HitNoOfTime=0;
    SpriteRenderer sr;
    float val;
    public bool weakEnemy;
    Animator animator;
    // Use this for initialization
    void Start () {
        health = GetComponentInParent<Health>();
      
        sr = GetComponent<SpriteRenderer>();
        
    }
	
	// Update is called once per frame
	void Update () {
    
       if (HitNoOfTime == 0)
        {
            sr.sprite = enemyImage[0];
        }
        else if (HitNoOfTime == 1)
        {

            sr.sprite = enemyImage[1];
        }
        else 
        {
            sr.sprite = enemyImage[2];
        }
    }
}
