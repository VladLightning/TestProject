using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    public GameObject player;
    public Camera mainCamera;
    public Image icon;

    public bool abilityReady;
    public float abilityCooldown;

    private void Awake()
    {
        icon = GetComponent<Image>();
    }

    public void StartAbilityCooldown()
    {
        StartCoroutine(AbilityCooldown());
    }

    public IEnumerator AbilityCooldown()
    {
        icon.fillAmount = 0;

        abilityReady = false;
        while (icon.fillAmount < 1) 
        {
            icon.fillAmount += 0.001f;
            yield return new WaitForSeconds(abilityCooldown/1200);
        }
        abilityReady = true;
    }

    public void ResetAbilityAmount()
    {
        Destroy(transform.GetChild(0).gameObject);
    }

    public void SetAbility(float cooldown)
    {
        if (transform.childCount > 1)
        {
            ResetAbilityAmount();
        }    
        abilityCooldown = cooldown;
    }

    public bool GetAbilityReady()
    {
        return abilityReady;
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public Camera GetCamera()
    {
        return mainCamera;
    }
}
