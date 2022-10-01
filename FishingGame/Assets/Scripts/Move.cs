using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //reference to the animator component
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    AudioSource audioWalk;
    AudioSource audioJump;

    bool isGrounded;

    [SerializeField]
    Transform groundCheck = null;

    // Start is called before the first frame update
    void Start()
    {
        // get the animator component of the GameObject
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Water")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        // change the animator's AnimState variable if a key is pressed
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(2, rb2d.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-2, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if (Input.GetKey("up") && isGrounded || Input.GetKey("w") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 5);
        }
    }
}