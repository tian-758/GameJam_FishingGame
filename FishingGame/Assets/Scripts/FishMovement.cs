using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    AudioSource audioWalk;
    AudioSource audioJump;

    [SerializeField]
    public float horizontialTurnRate = 10f;
    [SerializeField]
    public float fishSpeed = 1f;
    [SerializeField]
    public float verticleBobRate = 1f;
    [SerializeField]
    public float riseSpeed = 1f;
    [SerializeField]
    public int pointWorth = 1;

    public float timerHorizontial;
    public float timerVerticle;
    public bool updatedVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        updatedVelocity = true;
        timerHorizontial = horizontialTurnRate;
        timerVerticle = verticleBobRate;
    }

    // Update is called once per frame
    void Update()
    {
        Collider c = this.GetComponent<Collider>();
        timerHorizontial-= Time.deltaTime;
        timerVerticle -= Time.deltaTime;

        if (timerHorizontial <= 0f) {
            timerHorizontial = horizontialTurnRate;
            fishSpeed*= -1f;
            updatedVelocity = true;
        }

        if (timerVerticle <= 0f) {
            timerVerticle =verticleBobRate;
            riseSpeed *= -1f;
            updatedVelocity = true;
        }

        if (updatedVelocity) {

            rb2d.velocity = new Vector2(fishSpeed, riseSpeed);

            updatedVelocity = false;
        }

        

    }

    void OnTriggerEnter2D(Collider2D d) {
        if (d.gameObject.tag == ("Hook")) {

            Destroy(gameObject);
            

        }
    }

}
