using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory {
    private InventoyPool inventoyPool = InventoyPool.Instance;
    [SerializeField]
    private List<Item> items;
    [SerializeField]
    private float weightCapasity;
    
    public Inventory(float weightCapasity)
    {
        this.weightCapasity = weightCapasity;
        items = new List<Item>();
    }

    public void AddToInventoty(Item item)
    {
        if((this.CurrentWeight() + item.Weight) <= weightCapasity)
        {
            items.Add(item);
            item.gameObject.SetActive(false);

        } else
        {
            Debug.Log("Inventory is full!");
        }
    }

    public List<Item> Items
    {
        get
        {
            return items;
        }
    }

    public float CurrentWeight()
    {
        float weightTotal = 0;
        
        foreach(Item item in items)
        {
            weightTotal += item.Weight;
        }

        return weightTotal;
    }

    public float WeightCapasity
    {
        get
        {
            return weightCapasity;
        }

        set
        {
            if(value > 0)
                weightCapasity = value;
        }
    }
}
