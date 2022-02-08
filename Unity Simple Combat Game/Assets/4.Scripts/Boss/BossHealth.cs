using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

	public int health = 500;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	[SerializeField] GameObject healthBarUI;
	[SerializeField] GameObject endgameUI;

    public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			StartCoroutine(Die());
		}
	}

	IEnumerator Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		transform.Translate(1000, 1000, 0);
		healthBarUI.SetActive(false);
		endgameUI.GetComponent<Text>().text = "You Win";
		endgameUI.SetActive(true);
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Debug.Log("Load Scence");
	}

}
