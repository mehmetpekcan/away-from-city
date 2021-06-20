using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
    public float attackRange = 10f;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    
    void Start() {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    void Update() {
        float attackDistance = Vector3.Distance(target.position, transform.position);

        if (attackDistance <= attackRange) {
            agent.SetDestination(target.position);

            if (attackDistance <= agent.stoppingDistance) {
                FaceTarget();


                CharacterStats targetStats = target.GetComponent<CharacterStats>();

                if (targetStats != null) {
                    combat.Attack(targetStats);
                }
            }
        }
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);    
    }
}
