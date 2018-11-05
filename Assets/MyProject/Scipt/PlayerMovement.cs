using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Animator animator;
    float input;
    public float moveSpeed = 10;
    public float jumpForce = 10;
    Rigidbody2D rgbd;
    bool isJumping;
    bool facingRight;
    bool isGrounded;
    Transform groundCheck;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        rgbd = GetComponent<Rigidbody2D>();
       
        groundCheck = transform.Find("GroundCheck");
	}
	
	// Update is called once per frame
	void Update () {
       
        input = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("horizontalSpeed", Mathf.Abs(input));
        if (input != 0)
        {
            transform.Translate(transform.right * input * moveSpeed * Time.deltaTime);

        }
        // rgbd.MovePosition(transform.position+ transform.right * input * moveSpeed *Time.deltaTime);
        flipUsingEuler(input);
        //1<<layer name or no. check which layer to check
        bool grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
       
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            isJumping = true;
            rgbd.AddForce(Vector2.up * jumpForce );
        }
       
    }
    #region flip The Player Direction

    void flipUsingEuler(float input)
    {
        if (input > 0)
        {
            facingRight = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (input < 0)
        {
            facingRight = false;
            transform.eulerAngles = new Vector3(0,180, 0);
        }
    }
    void flipUsingScale()
    {
        facingRight = !facingRight;
        float scale = -1;
        Vector3 localScale = transform.localScale;
        localScale.x *= scale;
        transform.localScale = localScale;
    }
    #endregion

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Enemy")
        {
            Debug.Log("hit enemy");
            Vector2 dir = transform.position - collision.transform.position;
            rgbd.AddForce(dir+Vector2.up* 20, ForceMode2D.Impulse);
        }
       
    }
}
