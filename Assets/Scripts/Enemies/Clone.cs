using UnityEngine;

public class Clone : MonoBehaviour
{
    public BossAbility bossAbility;

    public void SetBossAbility(BossAbility setBossAbility)
    {
        bossAbility = setBossAbility;
    }

    public void CallDecreaseClonesAmount()
    {
        bossAbility.DecreaseClonesAmount();
    }
}
