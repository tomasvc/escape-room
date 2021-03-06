using System;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite Icon;
    public bool showInInventory = true;
    public int key;

    public GameObject prefab;

    public virtual void Use()
    {
        if (ItemName == "Red Gemstone")
        {
            Instantiate(prefab, new Vector3(-354.1571f, 76.8136f, -41.363f), Quaternion.Euler(90f, 0f, 0f));
            ColorPuzzle.redSlot = true;
        }

        if (ItemName == "Blue Gemstone")
        {
            Instantiate(prefab, new Vector3(-362.57f, 76.81f, -41.363f), Quaternion.Euler(90f, 0f, 0f));
            ColorPuzzle.blueSlot = true;
        }

        if (ItemName == "Yellow Gemstone")
        {
            Instantiate(prefab, new Vector3(-358.364f, 72.603f, -41.363f), Quaternion.Euler(90f, 0f, 0f));
            ColorPuzzle.yellowSlot = true;
        }

        if (ItemName == "Sphere 1")
        {
            Instantiate(prefab, new Vector3(-403.725f, 74.067f, -6.839f), Quaternion.identity);
            prefab.transform.localScale = new Vector3(25.29466f, 25.29467f, 25.29466f);
            PlayerController.mouseClicked = false;
        }

        if (ItemName == "Sphere 2")
        {
            Instantiate(prefab, new Vector3(-404.768f, 73.887f, -6.147f), Quaternion.identity);
            prefab.transform.localScale = new Vector3(25.29466f, 25.29467f, 25.29466f);
            PlayerController.mouseClicked = false;
        }

        if (ItemName == "Sphere 3")
        {
            Instantiate(prefab, new Vector3(-404.768f, 73.887f, -7.563f), Quaternion.identity);
            prefab.transform.localScale = new Vector3(25.29466f, 25.29467f, 25.29466f);
            PlayerController.mouseClicked = false;
        }
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

    internal bool Contains(Item item)
    {
        throw new NotImplementedException();
    }
}
