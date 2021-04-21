using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public float interactableDistance = 3f;

    bool isFocus = false;
    bool hasInterracted = false;
    Transform player;

    public virtual void Interact() {
        // Tihs method will overwritten by interracted object class.
        Debug.Log("Interacted");
    }

    void Update() {
        if (isFocus && !hasInterracted) {
            float playerDistance = Vector3.Distance(player.position, transform.position);

            if (playerDistance <= interactableDistance) {
                Interact();
                hasInterracted = true;
            }
        }    
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactableDistance);
    }

    public void OnFocused(Transform playerTransform) {
        isFocus = true;
        player = playerTransform;
        hasInterracted = false;

    }

    public void OnDefocused() {
        isFocus = false;
        player = null;
        hasInterracted = false;
    }

}
