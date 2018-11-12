using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour {

    int times = 3;
    public PlayerController movement;
	void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Object")
        {
           times = times - 1;
        }
        if (times == 0)
        {
            movement.enabled = false;
        }
	}
}
