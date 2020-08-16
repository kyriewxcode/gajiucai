using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mai1Song1 : Trap
{
    public override void Init(int id)
    {

        ID = id;
        Name = "买一送一" + id.ToString();


        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.getGM.reduceHP(damage);
            Debug.Log("你忍不住剁手，花了" + damage + "块");
            Destroy(gameObject);
        }
    }


   

}
