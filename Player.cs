using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public Slider HP_Bar;
	public Rigidbody Missile;

	public void Shoot()
	{
		var shot = Instantiate(Missile, transform.position + transform.forward * 2, transform.rotation);
		shot.AddForce(transform.forward * 1000);
		Destroy(shot.gameObject, 10f);
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	public void DoDamage(int amount)
	{
		HP_Bar.value -= amount;

		if (HP_Bar.value == 0)
		{
			UIManager.Instance.ShowEndGameMessage();
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
