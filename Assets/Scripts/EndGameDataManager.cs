using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameDataManager : MonoBehaviour
{
    Text hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<Text>();
        hp.text = ("你还剩"+GameManager.getGM.HP+"钱");
    }

    
   
}
