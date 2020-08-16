﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEventManager : MonoBehaviour
{
    static int[] timeAxis = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 69, 73, 77, 81, 85, 89, 93, 97, 101, 105, 109, 113, 117, 121, 125, 129, 133, 137, 141, 145, 149, 152, 155, 158, 161, 164, 167, 170, 173, 176, 179, 182, 185, 188, 191, 194, 197, 200, 203, 206, 209, 212, 215, 218, 221, 224, 227, 230, 233, 236, 239, 242, 245, 248, 251, 254, 257, 260, 263, 266, 269, 272, 275, 278, 281, 284, 287, 290, 293, 296, 299 };
    int timeAxisIndex;
    EventGroup[] eventGroup = new EventGroup[timeAxis.Length];

    public int[] DecimationNum = new int[timeAxis.Length];//抽取数

    public int[][] trapGroup = new int[timeAxis.Length][];

    public TextAsset trapGroupData;

    public TrapEvent m_trapEvent;

    class EventGroup
    {
        public int[] TrapType;
        public int ID;//时间点序号
        public EventGroup(int Id, int TypeQuant)
        {
            ID = Id;
            TrapType = new int[TypeQuant];
        }
    }
    private void Start()
    {
        Debug.Log(timeAxis.Length);
        timeAxisIndex = 0;
        addTrapGroup();
        addTrapEvent();
    }
    private void Update()
    {
        UpdateTrapSpawn();
    }
    void addTrapEvent()
    {

        for (int n = 0; n < eventGroup.Length; n++)
        {

            eventGroup[n] = new EventGroup(n, DecimationNum[n]);

            for (int i = 0; i < DecimationNum[n]; i++)
            {
                int size = trapGroup[n].Length;
                int ranNum = UnityEngine.Random.Range(0, size);
                eventGroup[n].TrapType[i] = trapGroup[n][ranNum];


                Debug.Log(eventGroup[n].TrapType[i]);
            }
            
        }
    }
    void addTrapGroup()
    {
        string temptext = trapGroupData.text;

        string[][] temp2DArray = new string[timeAxis.Length][];

        string[] tempTextArray = temptext.Split('\n');



        for (int i = 0; i < timeAxis.Length; i++)
        {
            
               temp2DArray[i] = tempTextArray[i].Split(',');
            trapGroup[i] = Array.ConvertAll(temp2DArray[i], int.Parse);


        }



    }

    void UpdateTrapSpawn()
    {
        if (Time.time > timeAxis[timeAxisIndex])
        {
               for (int i = 0; i < eventGroup[timeAxisIndex].TrapType.Length; i++)
            {
                m_trapEvent.TrapType = eventGroup[timeAxisIndex].TrapType[i];
                m_trapEvent.EventStart();
                Debug.Log("生成陷阱");
            }


            timeAxisIndex += 1;

        }
        //Debug.Log(timeAxis[timeAxisIndex]);
       // Debug.Log(Time.time);

    }

}