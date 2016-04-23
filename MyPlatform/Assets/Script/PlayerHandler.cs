using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour
{
    Rigidbody2D rigidBody2d;
    Collider2D collider2d;

    public int hp;
    public int direction;
    bool canJump;
    const float speed = 3f;
    const float jumpForce = 350f;

	// Use this for initialization
    void Start () 
    {
        
	}
	
	// Update is called once per frame
    public void HandlerUpdate () 
    {
        Movement();
	}

    public void PlayerStart ()
    {
        rigidBody2d = gameObject.GetComponent<Rigidbody2D>();
        collider2d = gameObject.GetComponent<Collider2D>();
    }

    public void SetDirection(int dir)
    {
        if (canJump)
        {
            direction = dir;
        }
    }

    public void TryJump()
    {
        if (canJump)
        {
            canJump = false;
            rigidBody2d.AddForce(Vector3.up * jumpForce);
        }
    }

    void Movement()
    {
        
        //movmento destra e sinistra
        if(Input.GetKey(KeyCode.D) && canJump)
        {
            direction = 1;
        }
        if(Input.GetKey(KeyCode.A) && canJump)
        {
            direction = -1;
        }
        if (direction != 0)
        {
            if (direction == 1)
            {
                rigidBody2d.velocity = Vector2.right *speed;
            }
            if (direction == -1)
            {
                rigidBody2d.velocity = Vector2.left *speed;
            }
        }
        //jump
        if (Input.GetKey(KeyCode.W) && canJump)
        {
            canJump = false;
            rigidBody2d.AddForce(Vector3.up * jumpForce);
        }
        //
        direction = 0;
    }

    void OnCollisionEnter2D()
    {
        canJump = true;
    }
}
