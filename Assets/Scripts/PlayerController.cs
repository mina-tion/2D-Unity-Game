using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 direction;//направление движения
    public Vector2 playerPosition;
    public Vector2 velocity;

    public float speed = 0.6f;
    public float maxVelocity = 10f;//максимальная скорость
    public float acceleration = 0.5f;//ускорение
    public float deceleration = 0.3f;//торможение

    public int maxHealth = 5;
    public int currentHealth { get; private set; }

    Rigidbody2D rigidbody2d;
    Animator animator;


    //инициализация объекта
    void Start()
    {
   
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = 2;
        animator = GetComponent<Animator>();
    }

    //покадровое обновление
    void Update()
    {
        updatePosition();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }


    public void updatePosition()
    {
        playerPosition = rigidbody2d.position;

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        if (direction.x != 0)//по горизонтали
        {
            CheckDeceleration(ref velocity.x);
            velocity.x += acceleration * direction.x;
            playerPosition.x += speed * velocity.x * Time.deltaTime;

            animator.SetFloat("moveX", direction.x);
            animator.SetFloat("moveY", 0);
        }

        else if (direction.y != 0)//по вертикали
        {
            CheckDeceleration(ref velocity.y);
            velocity.y += acceleration * direction.y;
            playerPosition.y += speed * velocity.y * Time.deltaTime;

            animator.SetFloat("moveX", 0);
            animator.SetFloat("moveY", direction.y);
        }

        else
        {
            animator.SetFloat("moveX", 0);
            animator.SetFloat("moveY", 0);
        }


        rigidbody2d.MovePosition(playerPosition);
    }

    void CheckDeceleration(ref float velocityValue)//торможение (актуально для обоих осей)
    {
        if (velocityValue > 0f)//проверка положительного
        {
            //проверка макс. скорости
            if (velocityValue > maxVelocity)
                velocityValue = maxVelocity;

            //торможение
            velocityValue -= deceleration;
            if (velocityValue < 0f)
                velocityValue = 0f;
        }

        else if (velocityValue < 0f)//проверка отр.
        {
            //проверка макс. скорости
            if (velocityValue < -maxVelocity)
                velocityValue = -maxVelocity;

            //торможение
            velocityValue += deceleration;
            if (velocityValue > 0f)
                velocityValue = 0f;
        }
    }

    void MoveCharacter()
    {

    }
}


