using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class pool
    {
        public string tag;
        public GameObject prefab;
        public int size;

    }

    public List<pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
    }


}
