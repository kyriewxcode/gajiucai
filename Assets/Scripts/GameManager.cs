using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    private static GameManager gm;

    public bool imRich;
    public bool imPoor;

    public AudioClip[] BGM;
    public AudioClip[] audioEffect;
    private AudioSource audioSource;
    public int[] ConsumeTimesCount = new int[13];

    public float ConsumemoneyCount;

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
        GameObject.DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    public void Init()
    {
        imPoor = false;
        imRich = false;
        HP = 20000;
        Mood = 100;
    }

    public void AddHP(float count){
        HP += count;
        if(HP>200000000f) HP=200000000f;
    }
    public void ReduceHP(float count){
        HP -= count;

        if (HP < 0)
            SceneManager.LoadScene(2);
    }
    public void AddMood(float count){
        Mood+=count;
        if(Mood>100) Mood=100;
    }
    public void ReduceMood(float count){
        Mood-=count* moodMultiplier/100;

        if (Mood < 0)
            SceneManager.LoadScene(2);

        Debug.Log(Mood);
        Debug.Log(moodMultiplier);
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