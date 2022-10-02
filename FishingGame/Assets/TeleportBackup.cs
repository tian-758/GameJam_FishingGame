using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBackup : MonoBehaviour // Another set of teleporters
{
    private Transform destination;
    public Transform player;

    public bool isForward;
    public float distance = 0.2f;

    void Start() {
        if (isForward == false) {
            destination = GameObject.FindGameObjectWithTag("Wall1").GetComponent<Transform>();
        }
        else {
            destination = GameObject.FindGameObjectWithTag("Wall2").GetComponent<Transform>();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (Vector2.Distance(transform.position, player.position) > distance) {
            player.position = new Vector2(destination.position.x, destination.position.y);
        }
    }

}