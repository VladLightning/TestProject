using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float defaultSpeed;
    public float acceleration;
    public float speedModifier;

    public Rigidbody2D playerPhysics;

    public void Start()
    {
        speedModifier = 1;
        defaultSpeed = speed;
        playerPhysics = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(-speed * speedModifier, playerPhysics.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(speed * speedModifier, playerPhysics.velocity.y);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Move(playerPhysics.velocity.x, speed * speedModifier);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(playerPhysics.velocity.x, -speed * speedModifier);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= acceleration;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = defaultSpeed;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            speed /= acceleration;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            speed = defaultSpeed;
        }
    }

    public void Move(float speedX, float speedY)
    {
        playerPhysics.velocity = new Vector2(speedX,speedY);
    }

    public void SetSpeedModifier(float newSpeedModifier)
    {
        speedModifier = newSpeedModifier;
    }

    public void SetSpeed(float speedIncrease)
    {
        defaultSpeed += speedIncrease;
        speed = defaultSpeed;
    }
}
