using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour {
    Animator animator;
    NavMeshAgent navMeshAgent;

    const float ANIMATION_SMOOTH_TIME = .1f;

    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update() {
        float speedPercent = navMeshAgent.velocity.magnitude / navMeshAgent.speed;
        animator.SetFloat("speedPercent", speedPercent, ANIMATION_SMOOTH_TIME, Time.deltaTime);
    }
}
