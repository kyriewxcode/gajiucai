using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    float horizontalInput;
    float verticalInput;


    [Header("冲刺参数")]
    public float dashTime;//dash时长
    private float dashTimeLeft;//冲锋剩余时间
    private float lastDash=-10;//上次冲刺时间
    public float dashCollDown;//dash CD
    public float dashSpeed;

    public bool isDash = false;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if(Input.GetButtonDown("Jump"))
        {
            if(Time.time >= (lastDash+dashCollDown))
            {
                //cd过了，允许冲刺
                dashTimeLeft = dashTime;
                lastDash = Time.time;
                isDash = true;
            }
        }
    }
    private void FixedUpdate() {
        Dash();
        if(horizontalInput!=0 || verticalInput!=0)
        {
            Vector3 move = new Vector3(horizontalInput,verticalInput);
            transform.Translate(move*Time.deltaTime*moveSpeed,Space.World);
        }
        
    }

    void Dash()
    {
        if(isDash)
        {
            if(dashTimeLeft>0)
            {
                transform.Translate(Vector2.up * Time.deltaTime * dashSpeed);
                dashTimeLeft-=Time.deltaTime;
                Pool.instance.GetFormPool();
            }
            else isDash=false;
        }
    }
}
