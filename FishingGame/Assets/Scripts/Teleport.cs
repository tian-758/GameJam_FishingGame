using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform destination;
    public Transform player;

    public bool isForward;
    public bool isWall2;
    public float distance = 0.2f;

    void Start() {
        if (isForward == false) {
            destination = GameObject.FindGameObjectWithTag("Forward Wall").GetComponent<Transform>();
        }
        else {
            destination = GameObject.FindGameObjectWithTag("Backward Wall").GetComponent<Transform>();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (Vector2.Distance(transform.position, player.position) > distance) {
            player.position = new Vector2(destination.position.x, destination.position.y);
        }
    }

}