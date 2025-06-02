using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public float speed = 5;

    private Vector2 inputVec;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.isLive) return;
        
        //rb.linearVelocityX = inputVec.x * speed * Time.fixedDeltaTime;
        rb.AddForceX(inputVec.x*speed,ForceMode2D.Force);
        
        animator.SetFloat("Speed", inputVec.magnitude);

    }

    private void LateUpdate()
    {
        if (!GameManager.instance.isLive) return;
        
        if (inputVec.x != 0)
        {
            // 이미지 플립x
            // a누를경우 -1
            spriteRenderer.flipX = inputVec.x < 0 ? true : false;
            
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    public void Dead()
    {
        animator.SetTrigger("Dead");
    }
}
