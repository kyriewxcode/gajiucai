using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeManager : MonoBehaviour
{
    public Consume[] FixedConsume;
    public Consume[] RandConsume;
    int RandIndex=0;
    private void Start()
    {
        StartCoroutine("RandRefresh");
        StartCoroutine("FixedRefresh");
        StartCoroutine("FixedRefresh2");
    }

    //固定
    IEnumerator FixedRefresh()
    {
        while(true)
        {
            for(int i=0;i<2;i++)//01
            {
                FixedConsume[i].Refresh();
            }
            yield return new WaitForSeconds(15);
        }
    }
    IEnumerator FixedRefresh2()//23
    {
        while(true)
        {
            for (int i = 2; i <= 3; i++)
            {
                FixedConsume[i].Refresh();
            }
            yield return new WaitForSeconds(30);
        }
    }



    //随机
    IEnumerator RandRefresh()//开始随机刷新1~8
    {
        while(RandIndex<9)
        {
            RandConsume[RandIndex].Refresh();
            RandIndex++;
            yield return new WaitForSeconds(10);
        }
        //80秒后
        StartCoroutine("RandRefresh2");
        StopCoroutine("RandRefresh");
    }
    IEnumerator RandRefresh2()
    {
        while(true)
        {
            RandIndex = Random.Range(0,RandConsume.Length);
            RandConsume[RandIndex].Refresh();
            yield return new WaitForSeconds(10);
        }
    }
}
