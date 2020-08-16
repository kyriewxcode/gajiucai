using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    private static GameManager gm;


    public Text moodChange;
    public Text hpChange;

    public bool imRich;
    public bool imPoor;

    public AudioClip[] BGM;
    public AudioClip[] audioEffect;
    private AudioSource audioSource;
    public int[] ConsumeTimesCount = new int[13];

    public float ConsumemoneyCount;
    PlayerController player;
    
    
    public EffectManager m_Em;


    public static GameManager getGM{
        get{
            return gm;
        }
    }

    public float HP = 20000f;
    public float wages = 5000f;
    public float Mood = 100f;
    public float moodMultiplier=100f;//买到好东西的时候回到100
    void Awake () {
        
        

        
        
        gm = this;
        
        audioSource = GetComponent<AudioSource>();
    }
    public void Init()
    {
        

        imPoor = false;
        imRich = false;
        HP = 20000;
        Mood = 100;
    }
    public void Destroy()
    {
        Destroy(this);
    }
    public void AddHP(float count){
        HP += count;
        m_Em.AddEffect();
        if (HP>200000000f) HP=200000000f;
        hpChange.text = "+" + count.ToString("#0");
    }
    public void ReduceHP(float count){
        HP -= count;
        
        m_Em.AddEffect();
        
        if (HP < 0)
            SceneManager.LoadScene(2);
        hpChange.text = "-" + count.ToString("#0");
    }
    public void AddMood(float count){
        Mood+=count;
        if(Mood>100) Mood=100;
        moodChange.text = "+" + count.ToString("#0") + "%";
    }
    public void ReduceMood(float count){
        Mood-=count* moodMultiplier/100;
        moodChange.text = "-"+ (count* moodMultiplier/ 100).ToString("#0") + "%";

        if (Mood < 0)
            SceneManager.LoadScene(2);

        if (Mood >= 80f)
        {
            audioSource.clip = BGM[1];
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else if (Mood >= 20f)
        {
            audioSource.clip = BGM[2];
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else if (Mood < 20f)
        {
            audioSource.clip = BGM[3];
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
    }
}