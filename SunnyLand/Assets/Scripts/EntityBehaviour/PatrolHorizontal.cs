using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolHorizontal : Enemy
{
    public float LeftCap;
    public float RightCap;
    public float PatrolSpeed;

    private bool FacingLeft = true;
   
    private void Update()
    {
        patrolHorizontal();
    }
    private void patrolHorizontal()
    {
        if (FacingLeft)
        {
            if (transform.position.x > LeftCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                    
                rb.velocity = new Vector2(-PatrolSpeed, rb.velocity.y);
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

                rb.velocity = new Vector2(PatrolSpeed, rb.velocity.y);
            }
            else
            {
                FacingLeft = true;
            }
        }
    }
}
