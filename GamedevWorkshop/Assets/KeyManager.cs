using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] keys;
    private List<int> keyList = new List<int>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockKey(int key)
    {
        keys[key].SetActive(true);
        keyList.Add(key);
    }

    public bool hasKey(int key)
    {
        return keyList.Contains(key);
    }
}
