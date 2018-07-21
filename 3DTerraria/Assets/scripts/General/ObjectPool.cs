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

    public GameObject GetObject(GameObject gameObject) {
        int index = gameObjects.IndexOf(gameObject);
        return gameObjects[index];
    }
}
