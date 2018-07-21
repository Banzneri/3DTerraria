using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    private static T instance;
    private static Object objectLock = new Object();

    public static T Instance {
        get {
            lock(objectLock) {
                if(instance == null ) {
                    instance = (T) FindObjectOfType(typeof(T));
                    if(FindObjectsOfType(typeof(T)).Length > 1) {
                        Debug.LogError(typeof(T).ToString() +
                            " something went really wrong" +
                            "- There should never be more than 1 singleton");

                        return instance;
                    } else if (instance == null) {
                        GameObject singleton = new GameObject();
                        instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton) " + typeof(T).ToString();
                        DontDestroyOnLoad(singleton);
                        Debug.Log(typeof(T).ToString() + " was created.");
                    }
                }
            }
            return instance;
        }
    }
}
