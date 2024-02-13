using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    //Variables
    private bool isFacingRight = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform headCheck;
    public LayerMask brickLayer;
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && isGround() && currentState != jumpingState)
        {
            currentState = jumpingState;
            currentState.EnterState(this);
        }

        flip();
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }
    private bool isGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer) ||
        Physics2D.OverlapCircle(groundCheck.position, 0.2f, brickLayer);
    }

    private void flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter(this);
    }
}
