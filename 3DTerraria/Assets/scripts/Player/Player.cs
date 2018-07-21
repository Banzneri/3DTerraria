using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Inventory inventory;

    private void Start() {
        inventory = new Inventory(10);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null) {
                    interactable.Interact(this);
                }
            }
        }
    }
}
