using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public string missileName = "missaile";
    public float moveSpeed = 10f;
    public float lifeTime = 3f;
    public float _elapsedTime = 0f;

    void Update()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
        if (GetTimer() > lifeTime)
        {
            SetTimer();
            ObjectPool.instance.PushToPool(missileName, gameObject);
        }
    }

    float GetTimer()
    {
        return (_elapsedTime += Time.deltaTime);
    }

    void SetTimer()
    {
        _elapsedTime = 0f;
    }
}
