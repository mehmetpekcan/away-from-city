using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    private int currentCharge;

    public Texture2D[] hudChargeGUIs;
    public UnityEngine.UI.RawImage activeHudCharge; 

    public AudioClip cellPickupSound;
    
    void Start() {
        currentCharge = 0;
        UpdateChargeGUI();
    }

    void Update() { }

    void CellPickup() {
        AudioSource.PlayClipAtPoint(cellPickupSound, transform.position);
        currentCharge++;
        UpdateChargeGUI();
    }

    void UpdateChargeGUI() {
        activeHudCharge.texture = hudChargeGUIs[currentCharge];
    }
}
