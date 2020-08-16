using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider hpSlider;
    public Text hpText;
    public Text hpChange;

    public Slider moodSlider;
    public Text moodText;
    public Text moodChange;

    AudioSource audioSource;
    public Text wagesTime;
    int wagestime = 10;


    void Start()
    {
        GameManager.getGM.Init();
        StartCoroutine("MoodReduce");
        StartCoroutine("HpAdd");
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        moodSlider.value=GameManager.getGM.Mood;
        moodText.text = GameManager.getGM.Mood.ToString("#0") + "%";
        hpSlider.value=GameManager.getGM.HP;
        hpText.text = GameManager.getGM.HP.ToString("#0");
    }

    IEnumerator HpAdd()//工资
    {
        while(GameManager.getGM.HP>=0)
        {
            for(;wagestime>0;wagestime--)
            {
                wagesTime.text = "发工资倒计时：" + wagestime + "s";
                yield return new WaitForSeconds(1);
            }
            GameManager.getGM.AddHP(GameManager.getGM.wages);
            audioSource.clip = GameManager.getGM.audioEffect[3];
            if (!audioSource.isPlaying) audioSource.Play();
            wagestime = 10;
            //Debug.Log(GameManager.getGM.HP);
        }
        yield return null;
    }

    IEnumerator MoodReduce()//心情递减
    {
        while(GameManager.getGM.Mood>=0)
        {
            GameManager.getGM.ReduceMood(4f);
            GameManager.getGM.moodMultiplier =GameManager.getGM.Mood+20;
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
    
}
