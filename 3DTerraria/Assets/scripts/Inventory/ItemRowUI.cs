using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRowUI : MonoBehaviour {
    [SerializeField]
    private Text itemName;
    [SerializeField]
    private Text itemCount;

    public void SetItemName(string name) {
        itemName.text = name;
    }

    public void SetItemCount(int count) {
        itemCount.text = count.ToString();
    }

    public string GetItemName() {
        return itemName.text;
    }

    public int GetItemCount() {
        return Int32.Parse(itemCount.text);
    }
}
