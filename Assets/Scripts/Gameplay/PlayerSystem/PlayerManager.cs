using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{


    public CharacterController characterController;


    public bool isControlActivated = false;

    public UnityEvent OnPlayerCharacterDie;


    private void Start()
    {
        characterController.OnCharacterDie.AddListener(() =>
        {
            characterController.SetDeath();
            OnPlayerCharacterDie.Invoke();
        });
    }

    public void DeactivateControl()
    {
        isControlActivated = false;
    }
    public void ActivateControl()
    {
        isControlActivated = true;
    }
    public void Update()
    {
        if (isControlActivated)
        {
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
                characterController.SetIdle();

            if (Input.GetMouseButtonDown(0))
            {
                characterController.Shoot();

            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                characterController.GoLeft();
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                characterController.GoRight();
            }


            if (Input.GetMouseButtonDown(1))
            {
                characterController.Dash();
            }
        }
    }
}
