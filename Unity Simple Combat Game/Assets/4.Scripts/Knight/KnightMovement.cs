using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 20f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	PlayerHealth _PlayerHealth;

	private void Start()
	{
		_PlayerHealth = gameObject.GetComponent<PlayerHealth>();
	}

	// Update is called once per frame
	void Update()
	{
		if (_PlayerHealth.health > 0)
		{
			if (animator.GetBool("Attack1") | animator.GetBool("Attack2"))
			{
				horizontalMove = 0.0f;
			} else
            {
				horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
			}

			animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

			if (Input.GetButtonDown("Jump"))
			{
				jump = true;
				Debug.Log("Jump");
				animator.SetBool("IsJumping", true);
			}

			if (Input.GetButtonDown("Fire1"))
            {
				animator.SetBool("Attack1", true);
			}

			if (Input.GetButtonDown("Fire2"))
			{
				animator.SetBool("Attack2", true);
			} 

			/*		if (Input.GetButtonDown("Crouch"))
					{
						crouch = true;
					} else if (Input.GetButtonUp("Crouch"))
					{
						crouch = false;
					}*/
		}
		else
		{
			horizontalMove = 0.0f;
		}
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
		animator.SetBool("Attack1", false);
		animator.SetBool("Attack2", false);
	}
}
