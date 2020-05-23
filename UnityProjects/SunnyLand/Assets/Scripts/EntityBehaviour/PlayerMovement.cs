using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
	
	public Rigidbody2D rb;
	public CharacterController2D controller;
	public Animator animator;
	public HealthBar healthBar;

	public int maxHealth = 5;
	public static float currentHealth;
	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	void Update () 
	{
		if (currentHealth == 0)
		{
			GameOver.GameIsOver = true;
		}

		if (GameOver.GameIsOver == false)
		{
			Move();
		}
	}

	private void Move()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

		if (Mathf.Abs(rb.velocity.x) < 0.1f)
		{
			animator.SetBool("IsHurt", false);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Enemy enemy = other.gameObject.GetComponent<Enemy>();
			if (animator.GetBool("IsJumping") && other.gameObject.transform.position.y < transform.position.y)
			{
				enemy.JumpedOn();
				rb.velocity = new Vector2(rb.velocity.x, 10f);
			}
			else
			{	
				animator.SetBool("IsHurt", true);
				OnHit();
				
				if (other.gameObject.transform.position.x > transform.position.x)
				{
					rb.velocity = new Vector2(-10f, rb.velocity.y);
				}
				else
				{
					rb.velocity = new Vector2(10f, rb.velocity.y);
				}
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "LevelBorder")
		{
			LevelLoader.LevelComplete = true;
		}
	}

	public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}
	
	public void OnHit()
	{
		TakeDamage(0.5f);
	}
	
	void TakeDamage(float damage)
	{
		currentHealth = currentHealth - damage;
		healthBar.SetHealth(currentHealth);
	}

	void FixedUpdate ()
	{
		if (animator.GetBool("IsHurt") == false)
		{
			controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		}
		jump = false;
	}
}