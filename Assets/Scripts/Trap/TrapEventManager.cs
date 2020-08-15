using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEventManager : MonoBehaviour
{
    static int [] timeAxis = {5,10,15,20,25,30,35,40,45,50,55,60,65,69,73,77,81,85,89,93,97,101,105,109,113,116,119,122,125,128,131,134,137,140,143,146};
    EventGroup [] eventGroup= new EventGroup[timeAxis.Length];
    class EventGroup
    {
        public int ID;//时间点序号
        public TrapEvent [] trapGroup= new TrapEvent[10];//事件组，小于10
        public int DecimationNum;//抽取数
        public EventGroup(int id,int[] trapIDs,int number)
        {
            ID=id;
            for(int i=0;i<trapIDs.Length;i++)
            {
                //根据id生成新的事件，存入trapGroup;
            }
            DecimationNum=number;
        }
    }
    private void Start()
    {
        for(int i=0;i<timeAxis.Length;i++)
        {
            //读取时间轴文件信息，创建(new)事件组赋值到eventGroup
        }
    }
    void StartTrap()
    {
        float curTime = Time.time;
        int n=0;
        if(Time.time-curTime<0)
        {
            curTime=Time.time;
            for(int i=0;i<eventGroup[n].DecimationNum;i++)
            {
                int size = eventGroup[n].trapGroup.Length;
                int ranNum = Random.Range(0,size);
                eventGroup[n].trapGroup[ranNum].EventStart();
            }
        }
    }
}
