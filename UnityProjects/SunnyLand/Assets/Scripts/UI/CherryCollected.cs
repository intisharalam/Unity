using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryCollected : MonoBehaviour
{	
	public Animator animator;
	public int cherry = 1;
	[SerializeField] private Collider2D m_Collider;

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

	void DestroyCherry()
	{
		ScoreManagerCherry.ScManagerCherry.ChangeScore(cherry);
		Destroy(gameObject);
	}
}
