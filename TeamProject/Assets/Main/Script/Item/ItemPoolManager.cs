using System.Collections.Generic;
using UnityEngine;


// 오브젝트(아이템) 풀링 시스템
public enum ObjectType {smallCoin, bigCoin, coinBundle, gam, potion}
public class ItemPoolManager : MonoBehaviour
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

    private void Awake()
    {
        // pools 초기화
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

    // pools 에 있는 오브젝트 가져다 쓰기
    public GameObject GetFromPool(ObjectType type, Vector3 position)
    {
        if (!pools.ContainsKey(type)) 
        {
            Debug.Log("pools: null");
            return null;
        }
        Queue<GameObject> queue = pools[type];
        GameObject obj = queue.Count > 0 ? queue.Dequeue() : Instantiate(GetPrefab(type));
        obj.transform.position = position;
        obj.SetActive(true);
        Debug.Log("pools: 있음");
        return obj;
    }


    // 쓴 오브젝트 다시 pools 에 반환하기
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


