using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject merchantUI;
    public Merchant merchant;

    private void Awake()
    {
        merchant = GetComponent<Merchant>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            merchantUI.SetActive(!merchantUI.activeSelf);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            merchant.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            merchantUI.SetActive(false);
            merchant.enabled = false;
        }
    }
}
