using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    //reference to the animator component
    Animator animator;
    public Rigidbody2D rb2d;
    public DistanceJoint2D dj2d;
    SpriteRenderer spriteRenderer;
    AudioSource audioWalk;
    AudioSource audioJump;

    [SerializeField] GameObject hook;
    [SerializeField] Move player;

    float animationDuration = .5f;
    bool deployed;

    // Start is called before the first frame update
    void Start()
    {
        // get the animator component of the GameObject
        rb2d = GetComponent<Rigidbody2D>();
        dj2d = GetComponent<DistanceJoint2D>();
        hook = gameObject;
        deployed = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }

    public void toggleDeploy() {

        if (deployed) {
                hook.SetActive(false);
                deployed = false;
            } else {
                hook.transform.localPosition = new Vector2(7f*player.isRight, -3f);
                hook.SetActive(true);
                deployed = true;
        }

    }
}
