using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesManager : MonoBehaviour
{
    public List<EnemyController> enemies;

    public UnityEvent OnAllEnemiesDeath;

    int enemyDeathCount = 0;

    public void Start()
    {
        enemyDeathCount = enemies.Count;

        enemies.ForEach(enemy =>
        {
            enemy.gameObject.SetActive(false);
            enemy.OnEnemyDeath.AddListener(() =>
            {
                CheckAllEnemiesDead();
            });
        });
    }

    private void CheckAllEnemiesDead()
    {
        enemyDeathCount--;
        if (enemyDeathCount == 0)
        {
            OnAllEnemiesDeath.Invoke();
        }
    }

    public void ActivateEnemies()
    {

        StartCoroutine(ActivateEnemiesSequence());

    }

    public IEnumerator ActivateEnemiesSequence()
    {
        enemies.ForEach(enemy =>
        {
            enemy.gameObject.SetActive(true);
        });
        yield return null;

        enemies.ForEach(enemy =>
        {
            enemy.ActivateEnemy();
        });
    }


}
