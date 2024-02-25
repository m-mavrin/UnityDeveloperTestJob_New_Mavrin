using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private T m_prefab { get; }
    private Transform m_container { get; }

    private List<T> m_pool;
    private readonly int m_poolSize = 8;

    public Pool(T prefab, Transform container)
    {
        m_prefab = prefab;
        m_container = container;
        CreatePool();
    }

    private void CreatePool()
    {
        m_pool = new List<T>(m_poolSize);
        for (int i = 0; i < m_poolSize; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(m_prefab, m_container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        m_pool.Add(createdObject);
        return createdObject;
    }

    public bool IsHasFreeObject(out T obj)
    {
        foreach (var item in m_pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                obj = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }

        obj = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (IsHasFreeObject(out var obj))
        {
            return obj;
        }

        return CreateObject(true);
    }

    public void DisableAllObjects()
    {
        foreach (var obj in m_pool)
        {
            obj.gameObject.SetActive(false);
        }
    }
}