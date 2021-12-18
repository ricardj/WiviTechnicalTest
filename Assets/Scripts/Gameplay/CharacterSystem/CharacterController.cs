using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour, IDamageable
{

    public CharacterAvatar characterAvatar;
    public Rigidbody rb;
    public CharacterState currentCharacterState;
    public CharacterControllerEvent onChangedState;
    public CharacterSettings characterSettings;

    public DamageableData damageableData;
    public VisualEffectAsset deathEffect;

    public void SetDeath()
    {
        HyperFXManager.get.SpawnEffect(deathEffect, transform.position);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    public UnityEvent OnCharacterDie;

    [Header("Shoot configuration")]
    public Transform shootPlaceholder;
    public VisualEffectAsset shootEffect;


    [Header("Broadcasts on")]
    public Vector3EventSO onShootHarpoon;

    private void Start()
    {
        damageableData.OnDeadEvent.AddListener(() =>
        {
            OnCharacterDie.Invoke();

        });
    }

    internal void SetIdle()
    {
        //if (CanTransitionTo(CharacterState.IDLE))
        //{
            rb.velocity = Vector3.zero;
            Debug.Log("Setting character idle");
            SetCurrentCharacterState(CharacterState.IDLE);
            characterAvatar.SetIdle();
        //}
    }

    internal void Shoot()
    {
        Debug.Log("Shooting");
        onShootHarpoon.RaiseEvent(shootPlaceholder.position);
        HyperFXManager.get.SpawnEffect(shootEffect, shootPlaceholder.position);
        characterAvatar.SetShootAnimation();
    }

    internal void GoLeft()
    {
        rb.velocity = Vector3.left * characterSettings.GetSpeed();
        SetCurrentCharacterState(CharacterState.MOVING_LEFT);
        characterAvatar.SetRunning(Direction.LEFT);

    }

    internal void GoRight()
    {
        rb.velocity = Vector3.right * characterSettings.GetSpeed();
        SetCurrentCharacterState(CharacterState.MOVING_RIGHT);
        characterAvatar.SetRunning(Direction.RIGHT);
    }

    internal void Dash()
    {
        if (CanTransitionTo(CharacterState.DASHING_LEFT) && CanTransitionTo(CharacterState.DASHING_RIGHT))
        {
            Vector3 direction = GetDashingDirection();
            CharacterState dashingState = GetDashingState(direction);
            rb.velocity = direction * characterSettings.GetDashSpeed();
            SetCurrentCharacterState(dashingState);
            StartCoroutine(DelayedStopDashing(characterSettings.GetDashDuration()));
        }
    }

    public IEnumerator DelayedStopDashing(float dashDuration)
    {
        yield return new WaitForSeconds(dashDuration);
        SetIdle();
    }

    private CharacterState GetDashingState(Vector3 direction)
    {
        return direction.x > 0 ? CharacterState.DASHING_RIGHT : direction.x < 0 ? CharacterState.DASHING_LEFT : CharacterState.IDLE;
    }

    private Vector3 GetDashingDirection()
    {
        Vector3 direction = Vector3.zero;
        switch (currentCharacterState)
        {
            case CharacterState.MOVING_LEFT:
                direction = Vector3.left;
                break;
            case CharacterState.MOVING_RIGHT:
                direction = Vector3.right;
                break;

            default:
                break;
        }

        return direction;
    }

    public bool CanTransitionTo(CharacterState toCharacterState)
    {
        CharacterState from = currentCharacterState;
        CharacterState to = toCharacterState;

        if (from.Equals(CharacterState.DEATH))
            return false;

        if (
            (from.Equals(CharacterState.DASHING_LEFT) || from.Equals(CharacterState.DASHING_RIGHT))
            && (to.Equals(CharacterState.DASHING_RIGHT) || to.Equals(CharacterState.DASHING_LEFT))
            )
            return false;

        return true;
    }

    public void SetCurrentCharacterState(CharacterState newCharacterState)
    {
        currentCharacterState = newCharacterState;
        onChangedState.Invoke(currentCharacterState);
    }

    public DamageableData GetDamageableData()
    {
        return damageableData;
    }
}


public enum CharacterState
{
    MOVING_LEFT,
    MOVING_RIGHT,
    IDLE,
    SHOOTING,
    DASHING_LEFT,
    DASHING_RIGHT,
    DEATH
}