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
            PopulatePool(pool, objectPool);
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    private void PopulatePool(Pool pool, Queue<GameObject> objectPool)
    {
        for (int i = 0; i < pool.size; i++)
        {
            var instantiatedObject = Instantiate(pool.prefab, pool.container.transform);
            instantiatedObject.SetActive(false);
            objectPool.Enqueue(instantiatedObject);
        }
    }

    public GameObject RequestFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        if (poolDictionary[tag].Count > 0)
        {
            var poolObject = poolDictionary[tag].Dequeue();
            if (poolObject != null)
            {
                poolObject.SetActive(true);
                var pooledObjectComponent = poolObject.GetComponent<IPooledObject>();
                if (pooledObjectComponent != null)
                {
                    pooledObjectComponent.OnObjectSpawn();
                }
                return poolObject;
            }
        }
        var pool = pools.FirstOrDefault(x => x.tag == tag);
        if (pool != null)
        {
            var poolObject = Instantiate(pool.prefab, pool.container.transform);
            poolObject.SetActive(true);
            var pooledObjectComponent = poolObject.GetComponent<IPooledObject>();
            if (pooledObjectComponent != null)
            {
                pooledObjectComponent.OnObjectSpawn();
            }
            return poolObject;
        }
        return null;
    }

    public void ReturnToPool(string tag, GameObject objectToPool)
    {
        objectToPool.SetActive(false);
        poolDictionary[tag].Enqueue(objectToPool);
    }
}
