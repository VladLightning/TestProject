using TMPro;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public TMP_Text coinsDisplay;
    public Upgrade upgrade;

    public float multiplyChance;
    public int coinMultiplier;
    public int coinsCount;

    private void Start()
    {
        upgrade = GetComponent<Upgrade>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            IncreaseCoinsAmount(collision.GetComponent<Coin>().GetCoinValue());
            Destroy(collision.gameObject);
        }
    }

    public void IncreaseCoinsAmount(int increaseAmount)
    {
        if(coinMultiplier > 1 && Random.value <= multiplyChance)
        {
            coinsCount += increaseAmount * coinMultiplier;
        }
        else
        {
            coinsCount += increaseAmount;
        }
        coinsDisplay.text = coinsCount.ToString();
    }

    public void SetCoinMultiplier(int increaseMultiplier)
    {
        coinMultiplier += increaseMultiplier;
    }

    public int GetCoinsCount()
    {
        return coinsCount;
    }

    public void Buy(int price, string item)
    {
        coinsCount -= price;
        coinsDisplay.text = coinsCount.ToString();
        upgrade.ReceiveItem(item);
    }
}
