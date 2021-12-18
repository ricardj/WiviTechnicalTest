using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class DamageableData
{
    public int health = 1;
    //public int team = 0;

    public bool isDead;
    public UnityEvent OnDeadEvent;

    public void SetHealth(int newHealth)
    {

        health = newHealth;
        health = Mathf.Clamp(newHealth, 0, newHealth);
        if (health == 0)
        {
            isDead = true;
            OnDeadEvent.Invoke();
        }
    }
}
