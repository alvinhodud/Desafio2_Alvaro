using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isGrounded = false;
    public bool lookingRight = true;
    float HorizontalMove = 10f;
    
    void Update()
    {
        Jump();
        Right();
        Left();
    }
    
    void Right()
    {        
        if (Input.GetKey(KeyCode.D))
        {       
            if (lookingRight == false)
            {
                transform.Rotate(0f, 180f, 0f);
            }
            lookingRight = true;
            transform.position += transform.right * HorizontalMove * Time.deltaTime;
        }
    }
    
    void Left()
    {
        if (Input.GetKey(KeyCode.A))
        {        
           if (lookingRight == true)
           {
                transform.Rotate(0f, 180f, 0f);
           }
           lookingRight = false;
           transform.position += transform.right * HorizontalMove * Time.deltaTime;
        }
    }
    
    void Jump() 
    {
        float jumpForce = 5f;
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
