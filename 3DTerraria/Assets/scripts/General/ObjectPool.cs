using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool> {

    private List<GameObject> gameObjects = new List<GameObject>();

    public void Add (GameObject gameObject) {
        gameObject.transform.SetParent(this.transform);
        gameObject.SetActive(false);
        gameObjects.Add(gameObject);
    }

    // TODO: If the object pool doesn't have the item it should be instantiated
    // GameObjects should never be destroyed by using the Destroy method. Instead
    // of destroy, they should be saved to object pool for possible later use.
    public GameObject GetObject(GameObject gameObject) {
        int index = gameObjects.IndexOf(gameObject);
        return gameObjects[index];
    }
}
