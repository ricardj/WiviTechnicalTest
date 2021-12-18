using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    LEFT,
    RIGHT
}

public class CharacterAvatar : MonoBehaviour
{
    public Animator animatorController;

    [Header("Triggers")]
    public string runTrigger = "Run";
    public string idleTrigger = "Idle";
    public string shootTrigger = "Shoot";
    public string deathTrigger = "Die";

    bool isMovingRight = false;
    bool isMovingLeft = false;
    Vector3 lastPosition;
    private void Start()
    {
        lastPosition = transform.position;
    }
    public void Update()
    {
        isMovingRight = lastPosition.x < transform.position.x;
        isMovingLeft = lastPosition.x > transform.position.x;
        lastPosition = transform.position;
    }

    public void SetRunning(Direction direction)
    {
        switch (direction)
        {
            case Direction.LEFT:
                transform.forward = Vector3.left;
                break;
            case Direction.RIGHT:
                transform.forward = Vector3.right;
                break;
            default:
                break;
        }
        animatorController.Play("Run");
        //SetTrigger(runTrigger);

    }
    public void SetIdle()
    {
        transform.forward = Vector3.forward;
        //SetTrigger(idleTrigger);
        animatorController.Play("Idle");
    }

    internal void SetShootAnimation()
    {
        animatorController.Play("Shoot");
        //SetTrigger(shootTrigger);
    }

    public void SetTrigger(string trigger)
    {


        animatorController.SetTrigger(trigger);
    }

  
}
