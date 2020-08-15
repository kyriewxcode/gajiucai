using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool instance;
    public int shadowCount;
    public Queue<GameObject> dashPool=new Queue<GameObject>();
    public GameObject dashPrefabs;

    void Awake() {
        instance = this;
        FillPool();
    }
    public void FillPool()
    {
        for(int i=0;i<shadowCount;i++)
        {
            var newShadow = Instantiate(dashPrefabs);
            newShadow.transform.SetParent(transform);
            ReturnPool(newShadow);
        }
    }
    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        dashPool.Enqueue(gameObject);

    }
    public GameObject GetFormPool()
    {
        if(dashPool.Count==0) FillPool();
        var outShadow = dashPool.Dequeue();
        outShadow.SetActive(true);
        return outShadow;
    }

}
