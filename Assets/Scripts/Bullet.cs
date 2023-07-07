using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed { private get; set; } //ENCAPSULATION
	private Rigidbody2D rb;

	private void Start()
	{
		Speed = 10;
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		rb.velocity = transform.right * Speed;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "bullet") return;
		if(collision.gameObject.tag == "target")
		{
			Destroy(collision.gameObject);
		}
		Destroy(gameObject);
	}
}
