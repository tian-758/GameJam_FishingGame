using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform destination;
    public Transform player;

    public bool isForward;
    public float distance = 0.2f;

    void Start() {
        destination = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            if (isForward == false) {
                destination = GameObject.FindGameObjectWithTag("Forward Wall").GetComponent<Transform>();
                Debug.Log("Teleport to: forward");
                if (Vector2.Distance(transform.position, player.position) > distance) {
                    player.position = new Vector2(destination.position.x, destination.position.y);
                    Debug.Log("Teleported");
                }
            }
            else {
                destination = GameObject.FindGameObjectWithTag("Backward Wall").GetComponent<Transform>();
                Debug.Log("Teleport to: back");
                if (Vector2.Distance(transform.position, player.position) > distance) {
                    player.position = new Vector2(destination.position.x, destination.position.y);
                    Debug.Log("Teleported");
                }
            }
        }
    }

}