using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public Item item;

    void Update()
    {
        if (PlayerController.mouseClicked == true && PlayerController.interactable != null && PlayerController.interactable.name == item.name)
        {
            Inventory.instance.Add(item);
            Destroy(PlayerController.interactable);

            PlayerController.mouseClicked = false;
        }
        
    }

}
