using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetoryUI: MonoBehaviour {

    [SerializeField]
    private ItemRowUI itemRowUI;
    [SerializeField]
    private Camera UICamera;
    private Camera mainCamera;
    private Player player;

    private void Start() {
        mainCamera = Camera.main;

        // Should probably create some sort of game manager
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
            Dictionary<System.Type, int> dictionary = new Dictionary<System.Type, int>();

            foreach(Item item in player.inventory.Items) {
                if(dictionary.ContainsKey(item.GetType())) {
                    dictionary[item.GetType()] += 1;
                } else {
                    dictionary.Add(item.GetType(), 1);
                }
            }
            
            foreach(System.Type key in dictionary.Keys) {
                ItemRowUI newRow = Instantiate(itemRowUI);
                newRow.SetItemName(key.ToString());
                newRow.SetItemCount(dictionary[key]);
                Debug.Log(key.ToString() + ", " + dictionary[key]);
            }
        }
    }
}
