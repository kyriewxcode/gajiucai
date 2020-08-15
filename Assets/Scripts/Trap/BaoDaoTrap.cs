using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaoDaoTrap : Trap
{
    public override void Init(int id)
    {
        ID = id;
        Name = "宝刀"+id.ToString();
        EntityType = EnumEntityType.屠龙宝刀;
    }

    protected override void UpdateEntity(float detaTime)
    {

    }
    
    
}
