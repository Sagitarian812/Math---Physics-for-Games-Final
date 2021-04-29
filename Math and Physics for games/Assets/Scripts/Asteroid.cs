using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Actor
{
    public List<GameObject> splitPrefabList;
    public AsteroidManager manager;
    
    //Sets how many Asteroids from Prefab list get spawned
    //set splitCount to 0 to not spawn asteroids
    public int splitCount;

    public override bool CheckCollisionWith(Actor other)
    {
        if (this == other)
        { return false; }

        if (splitCount == 0)
        {
            Destroy(gameObject);
            return false; }

        Vector3 distanceVector = other.Location - this.Location;

        if (distanceVector.magnitude <= (other.CollisionRadius + this.CollisionRadius))
        {
           if(other.tag == "Projectile")
           {
                if (splitCount > 0)
                {
                    if (this.tag == "Large Asteroid")
                    {
                        Vector3 pos = new Vector3(this.transform.position.x + Random.Range(-4.0f, 4.0f),
            this.transform.position.y,
            this.transform.position.z);

                        for(int i = 0; i<splitCount; i++)
                        { 
                        GameObject A = Instantiate(splitPrefabList[0], pos, Quaternion.identity);
                        A.GetComponent<Asteroid>().velocity = new Vector3(Random.Range(-4.0f, 4.0f), 0, Random.Range(-4.0f, 4.0f));
                            AsteroidManager._instance.asteroidsRemaining += 1;
                        }
                        AsteroidManager._instance.asteroidsRemaining -= 1;
                        AsteroidManager._instance.ScoreChange(1000);
                        AsteroidManager._instance.PlaySound();
                        //AsteroidManager._instance.asteroidsRemaining += 1;
                    }
                    if (this.tag == "Medium Asteroid")
                    {
                        Vector3 pos = new Vector3(this.transform.position.x + Random.Range(-4.0f, 4.0f),
             this.transform.position.y,
             this.transform.position.z);

                        for (int i = 0; i < splitCount; i++)
                        {
                            GameObject A = Instantiate(splitPrefabList[0], pos, Quaternion.identity);
                            A.GetComponent<Asteroid>().velocity = new Vector3(Random.Range(-4.0f, 4.0f), 0, Random.Range(-4.0f, 4.0f));
                            AsteroidManager._instance.asteroidsRemaining += 1;
                        }
                        AsteroidManager._instance.asteroidsRemaining -= 1;
                        AsteroidManager._instance.ScoreChange(500);
                        AsteroidManager._instance.PlaySound();
                        //other.ScoreChange(5);
                    }
                    if (this.tag == "Small Asteroid")
                    {
                        AsteroidManager._instance.asteroidsRemaining -= 1;
                        AsteroidManager._instance.ScoreChange(100);
                        AsteroidManager._instance.PlaySound();
                        //other.ScoreChange(1);
                    }
                }
                Destroy(other.gameObject);
                Destroy(gameObject);
                
            }

            if (other.tag == "Player")
            {
                if (splitCount > 0)
                {
                    if (this.tag == "Large Asteroid")
                    {
                        Vector3 pos = new Vector3(this.transform.position.x + Random.Range(-4.0f, 4.0f),
            this.transform.position.y,
            this.transform.position.z);

                        for (int i = 0; i < splitCount; i++)
                        {
                            GameObject A = Instantiate(splitPrefabList[0], pos, Quaternion.identity);
                            A.GetComponent<Asteroid>().velocity = new Vector3(Random.Range(-4.0f, 4.0f), 0, Random.Range(-4.0f, 4.0f));
                            AsteroidManager._instance.asteroidsRemaining += 1;
                        }
                        AsteroidManager._instance.asteroidsRemaining -= 1;
                        other.HealthChange(10);
                        //AsteroidManager._instance.asteroidsRemaining += 1;
                    }
                    if (this.tag == "Medium Asteroid")
                    {
                        Vector3 pos = new Vector3(this.transform.position.x + Random.Range(-4.0f, 4.0f),
             this.transform.position.y,
             this.transform.position.z);

                        for (int i = 0; i < splitCount; i++)
                        {
                            GameObject A = Instantiate(splitPrefabList[0], pos, Quaternion.identity);
                            A.GetComponent<Asteroid>().velocity = new Vector3(Random.Range(-4.0f, 4.0f), 0, Random.Range(-4.0f, 4.0f));
                            AsteroidManager._instance.asteroidsRemaining += 1;
                        }
                        AsteroidManager._instance.asteroidsRemaining -= 1;
                        other.HealthChange(5);
                    }
                    if (this.tag == "Small Asteroid")
                    {
                        AsteroidManager._instance.asteroidsRemaining -= 1;
                        other.HealthChange(1);
                    }
                }
                //Destroy(other.gameObject);
                Destroy(gameObject);
            }
            return true;

        }
        return false;
    }
}
