using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolVertical : Enemy
{
    public float MaxHeight = 10;
    public float MinHeight = 2;
    public float PatrolSpeed = 2;

    void Update()
    {
        patrolVertical();
    }

    void patrolVertical()
    {
        if (transform.position.y > MaxHeight)
        {
            rb.velocity = new Vector2(rb.velocity.x , -PatrolSpeed);
        }
        else if (transform.position.y < MinHeight)
        {
            rb.velocity = new Vector2(rb.velocity.x, PatrolSpeed);
        }
    }

}
