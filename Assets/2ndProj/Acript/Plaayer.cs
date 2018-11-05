using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaayer : MonoBehaviour {
    public int moveSpeed;
    float input;
    Animator animator;
    bool facingLeft;
    Rigidbody2D rgbd;
    public int maxVelocity;
    public int jumpVelocity = 5;
    public float addForce =1.1f;
    bool isJumping;
    //for better jump
   public float fallingMultiplier = 2.5f;
   public float lowJumpMultiplier = 2;
    public bool betterJump = false;
    //special
    public float jumpTimeCounter = 2;
    public float jumpTime=2;
    public Transform checkGround;
    bool isGrounded;
    public LayerMask ground;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rgbd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        input = Input.GetAxisRaw("Horizontal");
	}
    private void FixedUpdate()
    {
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(input));
        MOveLeftRight();
        FaceLeftRight();
        Jump();
        if (betterJump)
        {   
            ////this will make the player fall faster
            //if (rgbd.velocity.y < 0)
            //{   //that means we are falling
            //    rgbd.velocity += Vector2.up * Physics2D.gravity.y * (fallingMultiplier - 1) * Time.deltaTime;
            //}


            ///
            isGrounded = Physics2D.Linecast(transform.position, checkGround.position
                , ground);
            Debug.Log(isGrounded);
            if (Input.GetKeyDown(KeyCode.Space)& isGrounded)
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rgbd.AddForce(Vector2.up * jumpVelocity * Time.deltaTime, ForceMode2D.Impulse);
            }
            else
            {
                if (Input.GetKey(KeyCode.Space)&& isJumping)
                {
                    if (jumpTimeCounter > 0)
                    {
                        rgbd.AddForce(Vector2.up * jumpVelocity * Time.deltaTime, ForceMode2D.Impulse);
                        jumpTimeCounter -= Time.deltaTime;
                    }
                    else
                    {
                        isJumping = false;
                    }
                   
                }
            }
           

        }

    }

    private void Jump()
    {
        if (!betterJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rgbd.AddForce(Vector2.up * jumpVelocity * addForce * Time.deltaTime, ForceMode2D.Impulse);
            }
           }
    }

    private void FaceLeftRight()
    {
        if (input < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            facingLeft = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            facingLeft = false;
        }
    }

    private void MOveLeftRight()
    {
        if (input != 0)
        {
            if (facingLeft)
            {
                Debug.Log("AddingForce");
                rgbd.AddForce(Vector2.left * moveSpeed * Time.deltaTime);
            }
            else
            {
                rgbd.AddForce(Vector2.right * moveSpeed * Time.deltaTime);

            }
            Debug.Log(rgbd.velocity);
            rgbd.velocity = new Vector2(Mathf.Clamp(rgbd.velocity.x, -maxVelocity, maxVelocity), rgbd.velocity.y);
        }
    }
}
