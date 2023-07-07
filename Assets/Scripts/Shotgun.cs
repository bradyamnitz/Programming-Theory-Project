using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon //INHERITANCE
{

	public Bullet bullet;
	public Transform bulletSpawn;
	private int pelletCount = 5;

	public override void Fire() //POLYMORPHISM
	{
		for (int i = 0; i < pelletCount; i++) {
			Instantiate(bullet, bulletSpawn.position, Quaternion.Euler(new Vector3(0f, 0f, Random.Range(-3f, 3f))));
		}
		
	}

}
