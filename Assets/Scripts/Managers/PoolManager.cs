using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField]
    private List<Pool> pools;

    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    protected override void Awake()
    {
        base.Awake();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                var instantiatedObject = Instantiate(pool.prefab, pool.container.transform);
                instantiatedObject.SetActive(false);
                objectPool.Enqueue(instantiatedObject);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject RequestFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Tag " + tag + " does not exist in pool");
            return null;
        }
        var poolObject = poolDictionary[tag].Dequeue();
        if (poolObject != null)
        {
            poolObject.SetActive(true);
            poolDictionary[tag].Enqueue(poolObject);
            return poolObject;
        }
        return null;
    }
}
