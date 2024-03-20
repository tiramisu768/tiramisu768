using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PooledObject
{
    public string poolItemName = string.Empty;
    public GameObject prefab = null;
    public int poolCount = 0;
    [SerializeField]
    private List<GameObject> poolList = new List<GameObject>();

   // PooledObject 객체를 초기화 할 때 처음 한번만 호출하고,
   // poolCount에 지정한 수 만큼 객체를 생성해서 poolList 리스트에 추가
    public void Initialize(Transform parent = null)
    {
        for (int ix = 0; ix < poolCount; ++ix)
        {
            poolList.Add(CreateItem(parent));
        }
    }
    //사용한 객체를 다시 오브젝트 풀에 반환할 때 사용할 함수
    public void PushToPool(GameObject item, Transform parent = null)
    {
        item.transform.SetParent(parent);
        item.SetActive(false); poolList.Add(item);
    }

    //객체가 필요할 때 오브젝트 풀에 요청하는 용도로 사용할 함수
    public GameObject PopFromPool(Transform parent = null)
    {
        if (poolList.Count == 0)
        {
            poolList.Add(CreateItem(parent));
        }
        GameObject item = poolList[0];
        poolList.RemoveAt(0); return item;
    }
    private GameObject CreateItem(Transform parent = null)
    {
        GameObject item = Object.Instantiate(prefab) as GameObject;
        item.name = poolItemName; item.transform.SetParent(parent);
        item.SetActive(false);
        return item;
    }
}
