using UnityEngine;
using UnityEngine.Localization.Components;

public class ItemDescription : MonoBehaviour
{
    public GameObject descriptionPanel;
    public BuyButton buyButton;

    public void CreatePanel()
    {
        Instantiate(descriptionPanel, transform.position, transform.rotation, transform);
        GetComponentInChildren<LocalizeStringEvent>().StringReference.SetReference(buyButton.GetItem().GetLocalizationTable(), buyButton.GetItem().GetDescriptionEntry()) ;
    }

    public void DestroyPanel()
    {
        Destroy(transform.GetChild(0).gameObject);
    }
}
