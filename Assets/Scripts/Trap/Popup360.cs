using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup360 : Trap
{
    public override void Init(int id)
    {

        ID = id;
        Name = "360" + id.ToString();



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.getGM.reduceMood(damage);
            Debug.Log("你看到弹窗十分烦躁 心情下降了" + damage);
            
        }
    }

}
