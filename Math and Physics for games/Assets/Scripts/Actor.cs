using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Actor : MonoBehaviour
{
    public bool isActive = true;
    public bool performsCollisionDetection = true;
    public static bool GameIsPaused = false;
    
    public float CollisionRadius = 1f;
    public float Mass = 1f;
    public int Health = 100;
    public Vector3 velocity = Vector3.zero;

    public GameObject spaceShip;
    public GameObject projectile;
    public GameObject PauseMenuUI;
    public GameObject GameOverUI;

    public TextMeshProUGUI health;
    //AudioSource audio;

    private void Start()
    {
        health.text = Health.ToString();
        //audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!isActive)
        { return; }

        ActorLogic();
        Movement();
        if (performsCollisionDetection)
        { CollisionDetection(); }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public virtual void ActorLogic()
    {

    }
    public virtual void CollisionDetection()
    {
        Actor[] actors = GameObject.FindObjectsOfType<Actor>();

        foreach(Actor a in actors)
        {
            if(CheckCollisionWith(a))
            {
                OnCollisionWith(a);
            }
        }
    }
    public Vector3 Location
    {
        get{ return gameObject.transform.position;}
    }

    public virtual void Movement()
    {
        if (GameIsPaused)
        {
            return;
        }
        else
        {
            Vector3 location = gameObject.transform.position;
            location += velocity * Time.deltaTime;

            if (location.z > 13)
            {
                location.z = -13;
            }
            if (location.z < -13)
            {
                location.z = 13;
            }

            if (location.x > 17)
            {
                location.x = -17;
            }
            if (location.x < -17)
            {
                location.x = 17;
            }
            gameObject.transform.position = location;
        }
    }

    public virtual void Fire()
    {
        Debug.Log("Fire");
    }

    public virtual bool CheckCollisionWith(Actor other)
    {
        //Check against self = false;
        if(this == other)
        { return false; }

        Vector3 distanceVector = other.Location - this.Location;

        if(distanceVector.magnitude <= (other.CollisionRadius + this.CollisionRadius))
        {
            Debug.Log("COLLISION DETECTED: " + this.gameObject.name + " WITH " + other.gameObject.name);
            return true;
         
        }
        return false;
    }

    public virtual void OnCollisionWith(Actor other)
    {

    }

    public virtual int HealthChange(int damage)
    {
        int temp = Health;
        Health = temp - damage;
        health.text = Health.ToString();
        //Debug.Log("Current Health: " + (temp - damage));
        if(Health <= 0)
        {
            Debug.Log("GAME OVER");
            GameOverUI.SetActive(true);
            Destroy(spaceShip);
        }
        return temp - damage;
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


}
