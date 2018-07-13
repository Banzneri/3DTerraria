using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Food : Item {
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
