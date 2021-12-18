using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombatManager : MonoBehaviour
{
    public static void KillDamageable(IDamageable combatDamageable)
    {
        combatDamageable.GetDamageableData().SetHealth(0);
    }

}

public class DamageableEventSO : GameEventSO
{
    public class DamageableEvent : UnityEvent<IDamageable> { }
    public DamageableEvent damageableEvent;
    public void AddListener(UnityAction<IDamageable> listener)
    {
        if (damageableEvent == null)
        {
            damageableEvent = new DamageableEvent();
        }
        damageableEvent.AddListener(listener);
    }

    public void RemoveListener(UnityAction<IDamageable> listener)
    {
        if (damageableEvent == null)
        {
            damageableEvent = new DamageableEvent();
        }
        damageableEvent.RemoveListener(listener);

    }

    public void RaiseEvent(IDamageable damageable)
    {
        damageableEvent.Invoke(damageable);
    }

}