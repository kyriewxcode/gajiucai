using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEventManager : MonoBehaviour
{
    static int[] timeAxis = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60, 62, 64, 66, 68, 70, 72, 74, 76, 78, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255, 256, 257, 258, 259, 260, 261, 262, 263, 264, 265, 266, 267, 268, 269, 270, 271, 272, 273, 274, 275, 276, 277, 278, 279, 280, 281, 282, 283, 284, 285, 286, 287, 288, 289, 290, 291, 292, 293, 294, 295, 296, 297, 298, 299, 300 };
    int timeAxisIndex;
    EventGroup[] eventGroup = new EventGroup[timeAxis.Length];

    public int[] DecimationNum = new int[timeAxis.Length];//抽取数

    public int[][] trapGroup = new int[timeAxis.Length][];

    public TextAsset trapGroupData;

    public TrapEvent m_trapEvent;
    public AudioSource m_sound;
    public AudioClip audioClip;
    
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
        m_sound.clip = audioClip;
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


//                Debug.Log(eventGroup[n].TrapType[i]);
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