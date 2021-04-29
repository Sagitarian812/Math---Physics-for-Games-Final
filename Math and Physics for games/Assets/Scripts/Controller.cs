using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Actor
{
    public GameObject projSpawnLocation;
    public Vector3 LookAtVector;
    //Vector3 mouseLocation;

    public override void Fire()
    {
        Instantiate(projectile, projSpawnLocation.transform.position, projSpawnLocation.transform.rotation);
    }

    public override void ActorLogic()
    {
        if (GameIsPaused)
        {
            return;
        }

        Vector3 deltaTranslate = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            deltaTranslate.x += 0.06f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            deltaTranslate.x -= 0.06f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            deltaTranslate.z += 0.06f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            deltaTranslate.z -= 0.06f;
        }
        gameObject.transform.position = gameObject.transform.position + deltaTranslate;


        if (Input.GetMouseButtonDown(0))
        { Fire(); }

        LookAtVector = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        LookAtVector = Input.mousePosition - LookAtVector;
        LookAtVector.z = LookAtVector.y;
        LookAtVector.y = 0f;

        gameObject.transform.forward = LookAtVector;
    }
 }
