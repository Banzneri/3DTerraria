using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Food : Item {
    [SerializeField]
    private float hunger;

    public float Hunger
    {
        get
        {
            return hunger;
        }

        set
        {
            hunger = value;
        }
    }
}
