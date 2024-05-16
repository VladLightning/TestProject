using UnityEngine;
using UnityEngine.UI;

public class GrenadeAbility : MonoBehaviour
{
    public GameObject player;
    public GameObject grenade;
    public Transform pivot;
    public Sprite icon;

    public Ability ability;

    public float cooldown;

    private void Start()
    {
        ability = GetComponentInParent<Ability>();

        player = ability.GetPlayer();
        pivot = player.GetComponentInChildren<LookAtMouse>().transform;

        GetComponentInParent<Image>().sprite = icon;
        ability.SetAbility(cooldown);
    }

    private void Update()
    {     
        if (Input.GetKeyDown(KeyCode.Alpha1) && ability.GetAbilityReady())
        {
            Instantiate(grenade, pivot.position, pivot.rotation);
            ability.StartAbilityCooldown();
        }
    }
}
