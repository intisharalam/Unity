using UnityEngine;

public class Frog : Enemy
{
    public float LeftCap;
    public float RightCap;
    public float JumpLength;
    public float JumpHeight;

    public LayerMask Ground;

    private bool FacingLeft = true;

    private void Update()
    {
        playerDeath();

        if (animator.GetBool("Jumping"))
        {
            if (rb.velocity.y <.1)
            {
                animator.SetBool("Falling", true);
                animator.SetBool("Jumping", false);
            }
        }

        if (coll.IsTouchingLayers(Ground))
        {
            animator.SetBool("Falling", false);
        }
    }

    private void Move()
    {
        if (FacingLeft)
        {
            if (transform.position.x > LeftCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }

                if (coll.IsTouchingLayers(Ground))
                {
                    rb.velocity = new Vector2(-JumpLength, JumpHeight);
                    animator.SetBool("Jumping", true);
                }
            }
            else
            {
                FacingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < RightCap)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }

                if (coll.IsTouchingLayers(Ground))
                {
                    rb.velocity = new Vector2(JumpLength, JumpHeight);
                    animator.SetBool("Jumping", true);
                }
            }
            else
            {
                FacingLeft = true;
            }
        }
    }

}
