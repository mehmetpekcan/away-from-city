using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour {    
    Transform target;
    NavMeshAgent navMeshAgent;

    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if (target != null) {
            MoveToPoint(target.position);
            FaceToTarget();
        }
    }

    public void MoveToPoint(Vector3 point) {
        navMeshAgent.SetDestination(point);
    }

    public void FollowTarget(Interactable willFollowTarget) {
        navMeshAgent.stoppingDistance = willFollowTarget.interactableDistance * .8f;
        navMeshAgent.updateRotation = false;
        target = willFollowTarget.transform;
    }

    public void StopFollowingTarget() {
        navMeshAgent.stoppingDistance = 0f;
        navMeshAgent.updateRotation = true;
        target = null;
    }

    void FaceToTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
