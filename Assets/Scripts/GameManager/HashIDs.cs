using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour {

    public int locomotionState;
    public int playerInSightBool;

    private void Awake()
    {
        locomotionState = Animator.StringToHash("Base Layer.Locomotion");
        playerInSightBool = Animator.StringToHash("PlayerInSight");
    }
}
