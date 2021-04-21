using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell : MonoBehaviour {
    private float ROTATION_SPEED = 100.0f;

    void Start() {
        
    }

    void Update() {
        transform.Rotate(new Vector3(ROTATION_SPEED * Time.deltaTime, 0, 0));        
    }

    void OnTriggerEnter(Collider collision) {
        GameObject collidedObject = collision.gameObject;
        bool isCollidedWithPlayer = collidedObject.tag == "player";

        if (isCollidedWithPlayer) {
            collidedObject.SendMessage("CellPickup");
            Destroy(gameObject);
        }
    }
}
