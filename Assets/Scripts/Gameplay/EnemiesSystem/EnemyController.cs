using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour, IDamageable, IBounceable
{
    public Rigidbody rb;
    public DamageableData damageableData;
    public BouncerData bounceData;

    public VisualEffectAsset deathEffect;

    [Header("Initial parameters")]
    public Vector3 initialForceDirection;
    public float initialForceMagnitude;

    public UnityEvent OnEnemyDeath;

    public void Start()
    {
        bounceData.Setup(rb);
        rb.isKinematic = true;
        damageableData.OnDeadEvent.AddListener(() =>
        {
            HyperFXManager.get.SpawnEffect(deathEffect, transform.position);
            OnEnemyDeath.Invoke();
            StartCoroutine(DelayedDestroy());
        });
    }

    public IEnumerator DelayedDestroy()
    {
        yield return null;
        Destroy(gameObject);

    }

    public void ActivateEnemy()
    {
        rb.isKinematic = false;
        rb.AddForce(initialForceDirection.normalized * initialForceMagnitude, ForceMode.Impulse);
    }


    public void OnCollisionEnter(Collision collision)
    {
        CheckIsDamageable(collision);
        //CheckIsBouncer(collision);

    }


    public void CheckIsBouncer(Collision collision)
    {
        IBouncer bouncer = collision.gameObject.GetComponent<IBouncer>();
        if (bouncer != null)
        {
            bouncer.Bounce(this);
        }
    }

    private void CheckIsDamageable(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            CombatManager.KillDamageable(damageable);
        }
    }

    public BouncerData GetBouncerData()
    {
        return bounceData;
    }

    public DamageableData GetDamageableData()
    {
        return damageableData;
    }
}
