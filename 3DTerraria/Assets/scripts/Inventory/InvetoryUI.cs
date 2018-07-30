using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetoryUI: MonoBehaviour {

    [SerializeField]
    private Camera UICamera;
    private Camera mainCamera;
    private Player player;

    private void Start() {
        mainCamera = Camera.main;
        player = (Player) FindObjectOfType(typeof(Player));
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            ToggleInventory();
        }
    }

    private void ToggleInventory() {
        mainCamera.enabled = !mainCamera.enabled;
        UICamera.enabled = !UICamera.enabled;

        if(UICamera.enabled) {

            HashSet<Dictionary<string, int>> set = new HashSet<Dictionary<string, int>>();

            foreach(Item item in player.inventory.Items) {
                Debug.Log(item.GetType().ToString());
            }
        }
    }
}
