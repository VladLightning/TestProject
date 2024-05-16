using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class ItemsRandomizer : MonoBehaviour
{
    public Item[] items;
    public BuyButton[] buttons;

    public void GetItems()
    {
        items = GetComponentsInChildren<Item>();
    }

    public void Randomize()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int randomItem = Random.Range(0, items.Length);
            if (items[randomItem] != null)
            {
                buttons[i].SetItem(items[randomItem]);
                items[randomItem] = null;
                continue;
            }
            i--;
        }
    }

    public void ButtonReset()
    {
        for(int i = 0;i < buttons.Length;i++)
        {
            buttons[i].GetComponent<Button>().interactable = true;
            buttons[i].GetComponentInChildren<LocalizeStringEvent>().StringReference.SetReference("Localization", "Merchant Buy");
        }
    }

    public void SetupShop()
    {
        ButtonReset();
        GetItems();
        Randomize();
    }
}
