using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour {

	public float movementSpeed;
	public float lifeTime;

	private float currentTime;

	void Update()
	{
		currentTime += Time.deltaTime;

		if (currentTime >= lifeTime)
		{
			BulletsSpawner.Instance.ReturnBulletToPool(this);
		}

		else
		{
			transform.position += transform.forward * movementSpeed * Time.deltaTime;
		}
	}

	public void Initialize()
	{
		currentTime = 0;

		transform.position = BulletsSpawner.Instance.transform.position;
		transform.rotation = BulletsSpawner.Instance.transform.rotation;
	}

	public static void InitializeBullet(Bullet bulletObj)
	{
		bulletObj.gameObject.SetActive(true);
		bulletObj.Initialize();
	}

	public static void DisposeBullet(Bullet bulletObj)
	{
		bulletObj.gameObject.SetActive(false);
	}
	void OnCollisionEnter(Collision collision)
	{
		print("in");
	}
}
