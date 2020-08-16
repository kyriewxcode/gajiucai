using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consume : MonoBehaviour
{
    public enum ConsumeType
    {
        固定消费点,
        随机消费点
    }
    public int ID;//消费点id
    public string _name;//名字
    public float moneyReduce;//消耗财富
    public float moodAdd;//心情增长
    public ConsumeType type;
    private Collider2D coll;
    private SpriteRenderer thisSprite;
    AudioSource audioSource;


    private void Awake() {
        thisSprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
        //tempTime=refreshTime;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("碰到"+other.collider.tag);
        if(other.collider.CompareTag("Player"))
        {
            Debug.Log("玩家碰到"+gameObject.name);
            if(GameManager.getGM.HP>=moneyReduce)
            {
                SuccesBuy();
                //触发对话  成功购买
                Debug.Log("成功购买");
            }
            else
            {
                //触发对话  钱不够
            }
        }
    }
    void SuccesBuy()
    {
        audioSource.clip = GameManager.getGM.audioEffect[4];
        if (!audioSource.isPlaying) audioSource.Play();
        if(ID==9&&type==ConsumeType.随机消费点)
            GameManager.getGM.wages*=2;

        coll.enabled = false;
        thisSprite.enabled = false;
        GameManager.getGM.moodMultiplier = 100;
        GameManager.getGM.ReduceHP(moneyReduce);
        GameManager.getGM.AddMood(moodAdd);
        GameManager.getGM.ConsumeTimesCount[ID]++;
        GameManager.getGM.ConsumemoneyCount += moneyReduce;
    }
    public void Refresh()
    {
        //随机刷新
        if(type==ConsumeType.随机消费点)
        {
            Vector2 randPos = new Vector2(Random.Range(-7f,7f),Random.Range(-3.5f,3f));
            transform.position = randPos;
        }
        coll.enabled = true;
        thisSprite.enabled = true;
    }
}
