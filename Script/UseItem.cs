using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{

    /*  Controls use of items  */

    Inventory inventory;

    IDictionary<int, string> dict = new Dictionary<int, string>() {

        // keys are item ID's, values are object names that the items need to be used with
        // Example: 1 - Red Gemstone ID, "Red Slot" - where the gemstone needs to be placed
        // This technique allows you to add as many items as you wish

        {1, "Red Slot"},
        {2, "Blue Slot"},
        {3, "Yellow Slot"},
        {4, "Table Slot"},
        {5, "Table Slot"},
        {6, "Table Slot"},

    };

    public Image slot1, slot2, slot3, slot4, slot5;

    bool slot1_active, slot2_active, slot3_active, slot4_active, slot5_active;

    bool alpha1_pressed, alpha2_pressed, alpha3_pressed, alpha4_pressed, alpha5_pressed;

    Item item;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;

        slot1_active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.interactable != null) // if player is looking at an interactable object
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) // if button 1 is pressed
            {
                if (inventory.items[0] != null) // check if first inventory slot is not empty
                {
                    if (dict.ContainsKey(inventory.items[0].key)) // check if item key matches with the key in dictionary
                    {
                        if (dict[inventory.items[0].key] == PlayerController.interactable.name) // check if value name is the same as the object that the player is looking at
                        {
                            item = inventory.items[0]; // assign first item in list to 'item'
                            item.Use();                // use item
                            inventory.Remove(item);    // remove item from inventory
                            alpha1_pressed = false;
                            return;
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (inventory.items[1] != null)
                {
                    if (dict.ContainsKey(inventory.items[1].key))
                    {
                        if (dict[inventory.items[1].key] == PlayerController.interactable.name)
                        {
                            item = inventory.items[1];
                            item.Use();
                            inventory.Remove(item);
                            return;
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (inventory.items[2] != null)
                {
                    if (dict.ContainsKey(inventory.items[2].key))
                    {
                        if (dict[inventory.items[2].key] == PlayerController.interactable.name)
                        {
                            item = inventory.items[2];
                            item.Use();
                            inventory.Remove(item);
                            return;
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (inventory.items[3] != null)
                {
                    if (dict.ContainsKey(inventory.items[3].key))
                    {
                        if (dict[inventory.items[3].key] == PlayerController.interactable.name)
                        {
                            item = inventory.items[3];
                            item.Use();
                            inventory.Remove(item);
                            return;
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (inventory.items[4] != null)
                {
                    if (dict.ContainsKey(inventory.items[4].key))
                    {
                        if (dict[inventory.items[4].key] == PlayerController.interactable.name)
                        {
                            item = inventory.items[4];
                            item.Use();
                            inventory.Remove(item);
                            return;
                        }
                    }
                }
            }

        }

    }
}
