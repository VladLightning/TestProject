using UnityEngine;
using UnityEngine.UI;

public class VinesAbility : MonoBehaviour
{
    public GameObject player;
    public GameObject vines;
    public Camera mainCamera;
    public Transform pivot;
    public Sprite icon;

    public Ability ability;

    public float cooldown;

    private void Start()
    {
        ability = GetComponentInParent<Ability>();
        mainCamera = ability.GetCamera();
        player = ability.GetPlayer();
        pivot = player.GetComponentInChildren<LookAtMouse>().transform;

        GetComponentInParent<Image>().sprite = icon;
        ability.SetAbility(cooldown);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && ability.GetAbilityReady())
        {
            Vector2 spawnPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(vines, spawnPosition , pivot.rotation);
            ability.StartAbilityCooldown();
        }
    }
}
