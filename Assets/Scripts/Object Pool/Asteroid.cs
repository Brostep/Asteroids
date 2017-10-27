using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float movementSpeed;

    void Update()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    public void Initialize()
    {
        transform.position = AsteroidsSpawner.Instance.transform.position;
        transform.rotation = AsteroidsSpawner.Instance.transform.rotation;
    }

    public static void InitializeAsteroid(Asteroid asteroidObj)
    {
        asteroidObj.gameObject.SetActive(true);
        asteroidObj.Initialize();
    }

    public static void DisposeAsteroid(Asteroid asteroidObj)
    {
        asteroidObj.gameObject.SetActive(false);
    }
}
