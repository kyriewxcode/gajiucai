using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaoDaoTrap : Trap
{
   
    float initTime;
    public float hitDelay;
    bool IsTriggered;
    public override void Init(int id)
    {
        IsTriggered = false;
        ID = id;
        Name = "宝刀"+id.ToString();
        initTime = Time.time;
       
        
    }

    protected override void UpdateEntity(float detaTime,Vector3 dir)
    {
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time>=initTime+hitDelay)
        {

            if (collision.gameObject.tag=="Player"&& IsTriggered == false)
            {
                GameManager.getGM.ReduceHP(damage);
                Debug.Log("你被🔪砍中了，减"+damage+"元");
                IsTriggered = true;
            }


        }
    }
    
}
