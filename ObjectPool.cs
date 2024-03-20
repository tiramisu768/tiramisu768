using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public List<PooledObject> objectPool = new List<PooledObject>();

    void Awake()
    {
        instance = this;

        for (int ix = 0; ix < objectPool.Count; ++ix)
        {
            objectPool[ix].Initialize(transform);
        }
    }

    public bool PushToPool(string itemName, GameObject item, Transform parent = null)
    {
        PooledObject pool = GetPoolItem(itemName);
        if (pool == null)
        {
            return false;
        }

        pool.PushToPool(item, parent == null ? transform : parent);
        return true;
    }

    public GameObject PopFromPool(string itemName, Transform parent = null)
    {
        PooledObject pool = GetPoolItem(itemName);
        if (pool == null)
        {
            return null;
        }

        return pool.PopFromPool(parent);
    }
    PooledObject GetPoolItem(string itemName)
    {
        for (int ix = 0; ix < objectPool.Count; ++ix)
        {
            if (objectPool[ix].poolItemName.Equals(itemName))
            {
                return objectPool[ix];
            }
        }

        Debug.LogWarning("There's no matched pool list."); return null;
    }
}