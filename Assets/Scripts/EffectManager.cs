using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
   public PlayerController m_playerController;
    public GameObject Sb_effect;
   
    
     
  public  void AddEffect()
    {
        Instantiate(Sb_effect,m_playerController.transform);
    }

   
   
}
