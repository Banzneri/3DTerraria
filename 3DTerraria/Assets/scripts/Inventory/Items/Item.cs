using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item {
    private float weight;

    public float Weight
    {
        get
        {
            return weight;
        }

        set
        {
            if(value > 0)
                weight = value;
        }
    }
}
