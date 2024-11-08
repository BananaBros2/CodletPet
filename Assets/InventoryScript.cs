using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject emptySlot;

    // Start is called before the first frame update
    void Start()
    {
        AddItem("gagag", null);
    }

    public void AddItem(string name, Sprite icon)
    {
        GameObject newItem = Instantiate(emptySlot, transform.GetChild(1));
        newItem.name = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
