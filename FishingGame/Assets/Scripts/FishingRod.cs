using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    //reference to the animator component
    Animator animator;
    Rigidbody2D rb2d;
    DistanceJoint2D dj2d;
    SpriteRenderer spriteRenderer;
    AudioSource audioWalk;
    AudioSource audioJump;

    // Start is called before the first frame update
    void Start()
    {
        // get the animator component of the GameObject
        rb2d = GetComponent<Rigidbody2D>();
        dj2d = GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
}
