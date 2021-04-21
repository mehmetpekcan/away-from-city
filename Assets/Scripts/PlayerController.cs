using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Camera mainCamera;
    PlayerMotor playerMotor;
    
    public Interactable focusedObject;
    public LayerMask movementMask;

    void Start() {
        playerMotor = GetComponent<PlayerMotor>();
        mainCamera = Camera.main;
    }

    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask)) {
                playerMotor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        } 
        
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null) {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocused) {
        if (newFocused != focusedObject) {
            if (focusedObject != null) focusedObject.OnDefocused();
    
            focusedObject = newFocused;
            playerMotor.FollowTarget(newFocused);
        }

        newFocused.OnFocused(transform);
    } 

    void RemoveFocus() {
        if (focusedObject != null) focusedObject.OnDefocused();
        
        focusedObject = null;
        playerMotor.StopFollowingTarget();
    }
}
