using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerItemCollector : MonoBehaviour
{
    private InventoryController inventoryController;

    private void Start()
    {
        inventoryController = FindObjectOfType<InventoryController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Item item = other.GetComponent<Item>();
            if (item != null)
            {
                //add to inventory
                bool itemAdded = inventoryController.AddItem(other.gameObject);
                if (itemAdded)
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }


}
