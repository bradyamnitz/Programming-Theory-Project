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
	[SerializeField] private List<Weapon> weaponList;
	[SerializeField] private Transform weaponAnchor;
	private Weapon equippedWeapon;
	private int currentWeaponIndex = 0;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		Equip();
	}

	private void FixedUpdate()
	{
		rb.AddForce(movement * speed);
		equippedWeapon.transform.position = weaponAnchor.position;
	}

	public void OnMove(InputValue input) //ABSTRACTION
	{
		Vector2 inputMovement = input.Get<Vector2>();
		movement = new Vector2(inputMovement.x, 0);
	}

	public void OnJump() //ABSTRACTION
	{
		rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
	}

	public void OnFire() //ABSTRACTION
	{
		if(equippedWeapon != null)
		{		
			equippedWeapon.Fire();
		}
	}

	public void OnNextWeapon() //ABSTRACTION
	{
		//equip next weapon if there is one
		if (currentWeaponIndex + 1 < weaponList.Count)
		{
			currentWeaponIndex++;
		}
		else
		//if there isn't, go back to the first weapon in the list
		{
			currentWeaponIndex = 0;
		}

		Equip();
	}

	private void Equip() //ABSTRACTION
	{
		if (equippedWeapon != null)
		{
			Destroy(equippedWeapon.gameObject);
		}
		equippedWeapon = Instantiate(weaponList[currentWeaponIndex], weaponAnchor.position, Quaternion.identity);
	}

	private void Equip(int index) //POLYMORPHISM
	{
		if (index < weaponList.Count)
		{
			currentWeaponIndex = index;
		}
		Equip();
	}

}
