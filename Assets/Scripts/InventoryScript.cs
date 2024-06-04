using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    // Start is called before the first frame update

    private string actualItem;
    private bool itemStored = false;
    public Image img;


    public bool SaveInventory(string spriteName)
    {
        if (!itemStored)
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/" + spriteName);
            actualItem = spriteName;
            itemStored = true;
            img.enabled = true;
            return true;
        }
        else
        {
            return false;
        }
    }
    public string useItem()
    {
        itemStored = false;
        img.enabled = false;
        return actualItem;
    }
    void Start()
    {
        itemStored = false;
        img.enabled = false;

        //Inventory("CoffeeShot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
