using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb;
    protected Collider2D coll;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    public void playerDeath()
    {
        if (PlayerMovement.currentHealth == 0)
        {
            GameOver.GameIsOver = true;
        }
    }

    public void JumpedOn()
    {
        rb.bodyType = RigidbodyType2D.Static;
        coll.enabled = !coll.enabled;
        animator.SetTrigger("Death");
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
