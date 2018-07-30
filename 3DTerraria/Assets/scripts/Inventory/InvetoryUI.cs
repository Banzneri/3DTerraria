using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetoryUI: MonoBehaviour {

    [SerializeField]
    private Camera UICamera;
    private Camera mainCamera;
    private Inventory inventory;

    private void Start() {
        mainCamera = Camera.main;
        Player p = (Player) FindObjectOfType(typeof(Player));
        inventory = p.inventory;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            ToggleInventory();
        }
    }

    private void ToggleInventory() {
        mainCamera.enabled = !mainCamera.enabled;
        UICamera.enabled = !UICamera.enabled;
    }
}
