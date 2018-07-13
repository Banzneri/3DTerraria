using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item {
    private float damage;

    public float Damage
    {
        get
        {
            return damage;
        }

        set
        {
            if(value > 0)
                damage = value;
        }
    }
}
