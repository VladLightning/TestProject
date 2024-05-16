using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public GameObject player;
    public Item item;

    public Image icon;
    public TMP_Text priceDisplay;

    public LocalizeStringEvent localizationTarget;

    public string itemName;
    public int price;

    public void SetItem(Item setItem)
    {
        item = setItem;

        icon.sprite = item.GetItemIcon();
        price = item.GetItemPrice();
        localizationTarget.StringReference.SetReference(item.GetLocalizationTable(), item.GetNameEntry());
        itemName = item.GetItemName();
        priceDisplay.text = price.ToString();
    }

    public void Purchase()
    {
        var coinPickUp = player.GetComponent<CoinPickUp>();
        if (price > coinPickUp.GetCoinsCount())
        {
            Debug.Log("Not enough money");
            return;
        }
        coinPickUp.Buy(price, itemName);
        GetComponentInChildren<LocalizeStringEvent>().StringReference.SetReference("Localization","Buy Button Sold");
        GetComponent<Button>().interactable = false;
    }

    public Item GetItem()
    {
        return item;
    }
}
