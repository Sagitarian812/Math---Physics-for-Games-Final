using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Actor
{
    public float MoveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
        velocity = gameObject.transform.forward * MoveSpeed;
    }

    public override void OnCollisionWith(Actor other)
    {
        if(other is Controller)
        {
            //Projectile collided with Player
        }
        if (other is Asteroid)
        { 
                Debug.Log("Large Collision");
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
        }
        if (other is Projectile)
        {
            //Projectile collided with another Projectile
        }
    }

}
