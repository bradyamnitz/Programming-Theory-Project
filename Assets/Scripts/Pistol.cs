using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon //INHERITANCE
{

	public Bullet bullet;
	public Transform bulletSpawn;

    public override void Fire() //POLYMORPHISM
	{
		Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
	}

}
