using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool> {
    public void Add (GameObject gameObject) {
        gameObject.transform.SetParent(this.transform);
        gameObject.SetActive(false);
    }
}
