using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonsManager : MonoBehaviour
{
    public HarpoonController harpoonPrefab;

    public int maxHarpoons;
    public Queue<HarpoonController> pooledHarpoons;
    public float harpoonCooldown = 0.3f;
    bool isHarpoonCoolingDown = false;

    [Header("Listens to")]
    public Vector3EventSO onShootHarpoon;

    public void Start()
    {
        pooledHarpoons = new Queue<HarpoonController>();
        for (int i = 0; i < maxHarpoons; i++)
        {
            HarpoonController newHarpoon = Instantiate(harpoonPrefab);
            newHarpoon.gameObject.SetActive(false);
            pooledHarpoons.Enqueue(newHarpoon);
        }
    }

    public void OnEnable()
    {
        onShootHarpoon.AddListener(SpawnHarpoon);
    }
    public void OnDisable()
    {
        onShootHarpoon.RemoveListener(SpawnHarpoon);
    }

    public void SpawnHarpoon(Vector3 targetPosition)
    {
        //if (isHarpoonCoolingDown)
        //{
        //    return;
        //}

        HarpoonController currentHarpoon = pooledHarpoons.Dequeue();
        currentHarpoon.gameObject.SetActive(true);
        currentHarpoon.transform.position = targetPosition;
        currentHarpoon.Reset();
        currentHarpoon.Activate();
        pooledHarpoons.Enqueue(currentHarpoon);

        //StartCoroutine(HarpoonCooldownSequence());
    }

    public IEnumerator HarpoonCooldownSequence()
    {
        isHarpoonCoolingDown = true;
        yield return new WaitForSeconds(harpoonCooldown);
        isHarpoonCoolingDown = false;
    }

}
