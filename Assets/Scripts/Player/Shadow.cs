using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    private Transform player;
    SpriteRenderer thisSprite;
    SpriteRenderer playerSprite;

    [Header("时间控制参数")]
    public float activeTime;//暗影显示时间
    public float activeStart;//开始显示的时间点

    [Header("不透明度控制")]
    public float alphaSet;//初始值
    public float alphaMuti;
    public Color color;

    private void OnEnable() {
        player=GameObject.FindGameObjectWithTag("Player").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite=player.GetComponent<SpriteRenderer>();
        color.a = alphaSet;
        thisSprite.sprite = playerSprite.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        activeStart = Time.time;
    }
    
    void Update()
    {
        color.a *= alphaMuti;
        thisSprite.color = color;
        if(Time.time>=activeStart+activeTime)
        {
            Pool.instance.ReturnPool(gameObject);
        }
    }
}
