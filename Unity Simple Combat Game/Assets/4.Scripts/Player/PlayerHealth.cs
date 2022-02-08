using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

	public int health = 100;

	public GameObject deathEffect;

	[SerializeField] GameObject healthBarUI;
	[SerializeField] GameObject endgameUI;

	public void TakeDamage(int damage)
	{
		health -= damage;

		StartCoroutine(DamageAnimation());

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()

	{
		StartCoroutine(EndGameEffect());
	}

	IEnumerator EndGameEffect()
    {
		Animator playerAnimator = GameObject.Find("Player/GFX").GetComponent<Animator>();
		Animator bossAnimator = GameObject.Find("Boss").GetComponent<Animator>();

		playerAnimator.SetBool("IsDeath", true);
		yield return new WaitForSeconds(0.5f);
		playerAnimator.enabled = false;

		yield return new WaitForSeconds(0.5f);
		bossAnimator.enabled = false;

		healthBarUI.SetActive(false);
		endgameUI.GetComponent<Text>().text = "You Lose";
		endgameUI.SetActive(true);

		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		// playerAnimator.enabled = true;
		// bossAnimator.enabled = true;
	}

	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}

}
