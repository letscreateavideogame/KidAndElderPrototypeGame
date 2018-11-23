using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// source https://www.youtube.com/watch?v=mBGUY7EUxXQ



public class PlayerAnimator : MonoBehaviour {
    const float locomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    Animator animator;
    float speedPercent=0;
    float Horizontal=0;
    float Vertical=0;
    public float speedAnimation = 40f;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedAnimation = 10000;
        } else
        {
            speedAnimation = 40;
        }

        if (Input.GetAxisRaw("Horizontal") >= 0) {
            Horizontal = Input.GetAxisRaw("Horizontal");
        }
        else Horizontal = Input.GetAxisRaw("Horizontal") * -1f;

        if (Input.GetAxisRaw("Vertical") >= 0)
        {
            Vertical = Input.GetAxisRaw("Vertical");
        }
        else Vertical = Input.GetAxisRaw("Vertical") * -1f;


        speedPercent = Horizontal * speedAnimation * Time.deltaTime + Vertical * speedAnimation * Time.deltaTime;

        animator.SetFloat("speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);
	}
}

