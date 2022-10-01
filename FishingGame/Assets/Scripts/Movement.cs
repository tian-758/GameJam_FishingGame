using System.Collections;
using System.Collections.Generic;
using UnityEngine;

const int LEFT = -1;
const int RIGHT = 1;
const float MAPSIZE = 70;

public class Movement : MonoBehaviour
{
    public FishingRod fishrod;

    int direction = 0;

    public float speed = 5.0;
    public float position = 0;
    public bool canMove = true;

    void Update()
    {
        direction = Input.GetAxisRaw("Horizontial");
    }

    void FixedUpdate()
    {
        if (canMove){

            switch (direction) {
                case RIGHT:
                    position += speed;
                    break;
                case LEFT:
                    position -= speed;
                    break;
                default:
                    break;
            }
        }

        if (position < 0.0) {
            position = MAPSIZE;
        } else if (position > MAPSIZE) {
            position = MAPSIZE;
        }
    }
}
