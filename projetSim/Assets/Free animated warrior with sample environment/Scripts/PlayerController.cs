using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] AnimationSwitch animSwitch;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float jumpDuration = 0.5f;
    public float jumpAnimationDuration = 0.7f;

    public bool jumpAnimation = false;
    public bool isJumping = false;
    public float jumpTimer = 0f;
    public float jumpAnimTimer = 0f;


    public bool isAttacking = false;
    public float attackTimer = 0f;
    public float attackDuration = 0.7f;

    public float DeathTimer = 0f;
    public float DeathTime = 15f;
    public bool isDead = false;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DeathTimer += Time.deltaTime;
        if (DeathTimer > DeathTime) 
        {
            isDead = true;
            animSwitch.AnimateDeath();
        }


        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetMouseButtonDown(0) && !isDead && !jumpAnimation)
        {
            isAttacking = true;
            animSwitch.AnimateAttack();
            attackTimer = 0;
        }
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > attackDuration) isAttacking = false;
        }

        if (horizontalInput > 0)
        {
            Vector2 movement = new Vector2(horizontalInput, 0);
            rb.velocity = movement * moveSpeed;
            gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 1);
            if (!jumpAnimation && !isAttacking && !isDead) animSwitch.AnimateRun();


        }
        else if (horizontalInput < 0)
        {
            Vector2 movement = new Vector2(horizontalInput, 0);
            rb.velocity = movement * (moveSpeed/2);
            gameObject.transform.localScale = new Vector3(-0.4f, 0.4f, 1);
            if (!jumpAnimation && !isAttacking && !isDead) animSwitch.AnimateWalk();


        }
        else
        {
            if (!jumpAnimation && !isAttacking && !isDead) animSwitch.AnimateIDLE();
        }

        if (Input.GetButtonDown("Jump") && !isJumping && !isDead)
        {
            
            isJumping = true;
            jumpAnimation = true;
            animSwitch.AnimateJump();
            jumpTimer = 0f;
            jumpAnimTimer = 0f;


        }

        if (jumpAnimation) 
        {
            jumpAnimTimer += Time.deltaTime;
            if (jumpAnimTimer > jumpAnimationDuration) jumpAnimation = false;
        }

        if (isJumping)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer < jumpDuration)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else
            {
                isJumping = false;
            }
        }
    }

}

