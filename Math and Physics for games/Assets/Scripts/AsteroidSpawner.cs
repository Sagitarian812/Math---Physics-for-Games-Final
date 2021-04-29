using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;
    public int increaseEachWave = 4;
    public int startingAmount = 5;

    private void Start()
    {
        AsteroidManager._instance.waves = 1;
        AsteroidManager._instance.asteroidsRemaining = startingAmount;
        SpawnAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
      if(AsteroidManager._instance.asteroidsRemaining == 0)
        {
            AsteroidManager._instance.asteroidsRemaining =startingAmount += increaseEachWave;
            AsteroidManager._instance.waves++;
            SpawnAsteroid();
        }
    }

    public void SpawnAsteroid()
    {
        for (int i = 0; i < AsteroidManager._instance.asteroidsRemaining; i++)
        {
            Vector3 pos = new Vector3(this.transform.position.x + Random.Range(-4.0f, 4.0f),
                    this.transform.position.y,
                    this.transform.position.z + Random.Range(-4.0f, 4.0f));

            GameObject A = Instantiate(asteroid, pos, Quaternion.identity);
            A.GetComponent<Asteroid>().velocity = new Vector3(Random.Range(-4.0f, 4.0f), 0, +Random.Range(-4.0f, 4.0f));
        }
    }
}
