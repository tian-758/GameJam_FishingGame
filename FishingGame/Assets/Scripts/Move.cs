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
    [SerializeField]public GameObject hook; 
    
    bool lineOut;
    public float isRight;
    public float CooldownTime = 0f;

    
    public float animationReelDuration = 1f;
    public float animationCastDuration = 1f;

    [SerializeField]
    int speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        // get the animator component of the GameObject
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        isRight = -1f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        lineOut = false;
        animator.Play("reelInAnimation");
        StartCoroutine(waitForAnimation(animationReelDuration));

        Debug.Log("reel duration:" + animationReelDuration);
        Debug.Log("cast duration:" + animationCastDuration);

    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        
        // change the animator's AnimState variable if a key is pressed
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            animator.SetInteger("AnimState", 3);
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            isRight = 1f;
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            animator.SetInteger("AnimState", 3);
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            isRight = -1f;
            spriteRenderer.flipX = false;
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            if(lineOut){
                animator.SetInteger("AnimState", 2);
            }
            else{
                animator.SetInteger("AnimState", 0);
            }
        }

        CooldownTime -= Time.deltaTime;
        if (Input.GetKey("space") && CooldownTime <= 0f) {
            CooldownTime = 2.0f;
            
            
            if(lineOut){
                lineOut = false;
                animator.Play("reelInAnimation");
                StartCoroutine(waitForAnimation(animationReelDuration));
            }
            else{
                lineOut = true;
                animator.Play("CastLineAnimation");
                StartCoroutine(waitForAnimation(animationCastDuration));
            }
        }
    }

    public void transformToSuper() {
        hook.transform.localScale *= 2f;
        hook.GetComponent<FishingRod>().dj2d.distance += 2;
        hook.GetComponent<FishingRod>().rb2d.gravityScale = .6f;
        hook.GetComponent<FishingRod>().rb2d.drag = 0f;
    }

    public void transformToNormal() {
        hook.transform.localScale /= 2f;
        hook.GetComponent<FishingRod>().dj2d.distance -= 2;
        hook.GetComponent<FishingRod>().rb2d.gravityScale = .2f;
        hook.GetComponent<FishingRod>().rb2d.drag =.33f;
    }

    IEnumerator waitForAnimation(float duration) {
        yield return new WaitForSeconds(duration);
        hook.GetComponent<FishingRod>().toggleDeploy();
    }
}