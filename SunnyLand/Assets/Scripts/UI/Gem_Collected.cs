using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem_Collected : MonoBehaviour
{
    public Animator animator;
	[SerializeField] private Collider2D m_Collider;
	public int Gem = 1;

	void Start()
	{
		m_Collider = GetComponent<Collider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			animator.SetBool("IsCollected", true);
			m_Collider.enabled = !m_Collider.enabled;
		}
	}

	void DestroyGems()
	{ 
		ScoreManagerGem.ScManagerGem.ChangeScore(Gem);
		Destroy(gameObject);
	}
}
