using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider hpSlider;
    public Slider moodSlider;
    
    void Start()
    {
        GameManager.getGM.Init();
        StartCoroutine("MoodReduce");
        StartCoroutine("HpAdd");
    }

    void Update()
    {
        moodSlider.value=GameManager.getGM.Mood;
        hpSlider.value=GameManager.getGM.HP;
    }

    IEnumerator HpAdd()//工资
    {
        while(GameManager.getGM.HP>=0)
        {
            yield return new WaitForSeconds(10);
            GameManager.getGM.addHP(5000f);
            Debug.Log(GameManager.getGM.HP);
        }
        yield return null;
    }

    IEnumerator MoodReduce()//心情递减
    {
        while(GameManager.getGM.Mood>=0)
        {
            GameManager.getGM.reduceMood(4f);
            GameManager.getGM.moodMultiplier-=4f;
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
    
}
