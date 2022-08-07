using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Rigidbody2D rigidBody;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Player character;
    float horizontal;
    float vertical;
    bool lookingLeft;
    static PlayerMove instance;

    void Awake()
    {
        //rigidBody = GetComponent<Rigidbody2D>();
        character = GetComponent<Player>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lookingLeft = false;
        instance = this;
    }

    void Update()
    {
        if (!Level.GetIsLevelUpTime())
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

        if (Mathf.Abs(horizontal) >= 0.7f && Mathf.Abs(vertical) >= 0.7f)
        {
            horizontal = Mathf.Clamp(horizontal, -0.7f, 0.7f);
            vertical = Mathf.Clamp(vertical, -0.7f, 0.7f);
        }

        if(horizontal != 0f || vertical != 0f)
        {
            animator.SetInteger("AnimState", 1);

            if (horizontal > 0f)
            {
                spriteRenderer.flipX = false;
                lookingLeft = false;
            }
            else if (horizontal < 0f)
            {
                spriteRenderer.flipX = true;
                lookingLeft = true;
            }
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }

        //rigidBody.MovePosition(rigidBody.position + new Vector2(horizontal, vertical) * character.GetSpeed() * Time.deltaTime);

        transform.Translate(Vector2.right * horizontal * character.GetSpeed()/10f * Time.deltaTime);
        transform.Translate(Vector2.up * vertical * character.GetSpeed()/10f * Time.deltaTime);
    }

    public static PlayerMove GetInstance()
    {
        return instance;
    }

    public bool GetLookingLeft()
    {
        return lookingLeft;
    }

    public float GetHorizontal()
    {
        return horizontal;
    }

    public float GetVertical()
    {
        return vertical;
    }
}