using System.Collections.Generic;
using UnityEngine;

public enum ObjectType { smallCoin, bigCoin, coinBundle }
public class PoolManager : MonoBehaviour
{
    [System.Serializable]
    public class PoolItem
    {
    public ObjectType type;
    public GameObject prefab;
    public int size;
    }
    
    public List<PoolItem> items;
    private Dictionary<ObjectType, Queue<GameObject>> pools = new();

    void Start()
    {
        foreach (var item in items)
        {
            Queue<GameObject> queue = new();
            for (int i = 0; i < item.size; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }
            pools[item.type] = queue;
        }
    }

    public GameObject GetFromPool(ObjectType type, Vector3 position)
    {
        if (!pools.ContainsKey(type)) return null;

        Queue<GameObject> queue = pools[type];
        GameObject obj = queue.Count > 0 ? queue.Dequeue() : Instantiate(GetPrefab(type));
        obj.transform.position = position;
        obj.SetActive(true);
        return obj;
    }

    public void ReturnToPool(ObjectType type, GameObject obj)
    {
        obj.SetActive(false);
        if (!pools.ContainsKey(type)) pools[type] = new Queue<GameObject>();
        pools[type].Enqueue(obj); 
    }

    private GameObject GetPrefab(ObjectType type)
    {
        foreach (var item in items)
        {
            if (item.type == type)
                return item.prefab;
        }
        return null;
    }
}


