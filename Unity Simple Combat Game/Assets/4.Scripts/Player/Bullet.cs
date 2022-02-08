using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 10;
	public Rigidbody2D rb;
	public GameObject impactEffect;
	public AudioSource impactSound;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
	}

    private void Update()
    {
		Destroy(gameObject, 6f);
	}

    void OnTriggerEnter2D (Collider2D hitInfo)
	{
		BossHealth enemy = hitInfo.GetComponent<BossHealth>();

		if (enemy != null)
		{
			impactSound.Play();
			enemy.TakeDamage(damage);

			gameObject.GetComponent<CircleCollider2D>().enabled = false;
			GameObject cloneEffect = Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(cloneEffect, 1.2f);
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			Destroy(gameObject, 1f);
		}
	}
}
