using System.Collections;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public GameObject boxReceiver;

    public GameObject projectileEmitter;
    public Transform target;
    public Animator animator;
    public bool animationLocked;

    public enum MageStates 
    { 
        Idle = 0,
        Walk = 1,
        Attack = 2,
    }
    public MageStates mageState;
    public MageStates currentState;

    public SpecialSpawn spawner;
    public FollowTarget followTarget;
    public EnemyHealth bossHealth;
    public ObstaclesSpawn obstaclesSpawn;

    public float fightDuration;
    public float followDuration;
    public float abilityCooldown;
    public bool abilityReady;

    public float minPlayerDistance;

    private void Start()
    {
        followTarget = GetComponent<FollowTarget>();
        target = followTarget.GetTarget();
        minPlayerDistance = followTarget.GetStoppingDistance();

        animator = GetComponent<Animator>();
        bossHealth = GetComponent<EnemyHealth>();
        obstaclesSpawn = GetComponent<ObstaclesSpawn>();

        projectileEmitter = transform.GetChild(0).gameObject;

        mageState = MageStates.Walk;

        abilityReady = true;
    }

    private void Update()
    {
        if(currentState != mageState && !animationLocked)
        {
            CheckMageState(mageState.ToString());
        }
        if(abilityReady)
        {
            StartCoroutine(Attack());
        }
        if (Vector2.Distance(transform.position, target.position) > minPlayerDistance && mageState != MageStates.Walk)
        {
            mageState = MageStates.Walk;
        }
        else if(Vector2.Distance(transform.position, target.position) <= minPlayerDistance && mageState != MageStates.Idle)
        {
            mageState = MageStates.Idle;
        }
    }

    public IEnumerator Attack()
    {
        abilityReady = false;

        mageState = MageStates.Attack;
        CheckMageState(mageState.ToString());

        followTarget.SetSpeed(followTarget.GetCurrentSpeed()/2);
        followTarget.SetStoppingDistance(0);

        yield return new WaitForSeconds(0.2f);

        projectileEmitter.SetActive(true);

        yield return new WaitForSeconds(followDuration);

        projectileEmitter.SetActive(false);

        followTarget.SetSpeedToDefault();
        followTarget.SetStoppingDistanceToDefault();
        animationLocked = false;

        yield return new WaitForSeconds(abilityCooldown);
        abilityReady = true;
    }

    public void StartCountdown()
    {
        StartCoroutine(Countdown());
    }

    public IEnumerator Countdown()
    {
        yield return new WaitForSeconds(fightDuration);

        animator.Play("Idle");

        followTarget.enabled = false;
        enabled = false;

        obstaclesSpawn.SetIsActive(true);
        obstaclesSpawn.StartSpawnObstacles();

        bossHealth.SetIsInvincible(true);

        spawner.SetIsActive(true);
        spawner.StartExecuteSpawn();

        boxReceiver.SetActive(true);
    }

    public void CheckMageState(string animationName)
    {
        currentState = mageState;
        if(animationName == "Attack")
        {
            animationLocked = true;
        }
        animator.Play(animationName);
    }
}
