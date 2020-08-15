using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TrapEvent : MonoBehaviour
{
    [Header("属性")]
    public int ID;//事件id
    public int TrapType;//陷阱id
    public float [] area = new float [4];//区域x1,y1,x2,y2
    public Vector3 dir;//方向

    public enum Dir
    {
        None,//0
        E,//1
        S,//2
        W,//3
        N//4
    }
    public Dir dirNum;
    public Trap trap;
    public GameObject [] trapPrefabs = new GameObject [9];
    private void Start()
    {
     //读取数据，为每个事件添加配置   
    }
    public void EventStart()
    {
        GameObject trapObject = Instantiate(trapPrefabs[TrapType]);//生成TrapType陷阱
        trap = trapObject.GetComponent<Trap>();
        trap.Init(TrapType);

        Vector3 pos = new Vector3(Random.Range(area[0],area[3]),Random.Range(area[1],area[4]));
        trap.EnableEntity(pos);
        switch(dirNum)
        {
            case Dir.None:
                dir=Vector3.zero;//无
                break;
            case Dir.E:
                dir=Vector3.right;//东
                break;
            case Dir.S:
                dir=Vector3.down;//南
                break;
            case Dir.W:
                dir=Vector3.left;//西
                break;
            case Dir.N:
                dir=Vector3.up;//北
                break;
            default:
                break;
        }
        trap.dir=dir;
    }
    public enum EnumEntityType//陷阱类型id
    {
        None,//0
        屠龙宝刀,//1
        江南皮革厂,//2
        游泳健身,//3
        弹窗,//4
        steam,//5
        首充6元,//6
        买一送一,//7
        推荐算法,//8
    }
}
