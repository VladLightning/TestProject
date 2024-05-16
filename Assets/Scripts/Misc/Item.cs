using UnityEngine;
using UnityEngine.Localization.Tables;

public class Item : MonoBehaviour
{
    public Sprite itemIcon;
    public string itemName;
    public string itemDescription;
    public int itemPrice;

    public TableReference localizationTable;
    public TableEntryReference nameEntry;
    public TableEntryReference descriptionEntry;

    public Sprite GetItemIcon()
    {
        return itemIcon;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public string GetItemDescription()
    {
        return itemDescription;
    }

    public int GetItemPrice()
    {
        return itemPrice;
    }

    public TableReference GetLocalizationTable()
    {
        return localizationTable;
    }

    public TableEntryReference GetNameEntry()
    {
        return nameEntry;
    }

    public TableEntryReference GetDescriptionEntry()
    {
        return descriptionEntry;
    }
}
