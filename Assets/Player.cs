using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

	private Vector2 movement;
	[SerializeField] private float speed;
	[SerializeField] private float jumpForce;
	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		rb.AddForce(movement * speed);
	}

	public void OnMove(InputValue input)
	{
		Vector2 inputMovement = input.Get<Vector2>();
		movement = new Vector2(inputMovement.x, 0);
	}

	public void OnJump()
	{
		rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
	}

}
