using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float MovementSharpness;

    public float DashingCooldownTime=3f;
    float DashCDTimeCount;
    public float DashingTime =1f;
    float DashTimeCount;
    public float DashSpeedMultiplier = 2f;
    float speedModifier = 1f;

    Vector3 characterMovementVelocity { get; set; }

    public bool IsDashing { get; private set; }

   public Camera m_camera;
    PlayerInputHandler m_playerInputHandler;
    // Start is called before the first frame update
    private void Awake()
    {
        m_playerInputHandler = GetComponent<PlayerInputHandler>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementHandler();
    }



    void MovementHandler()
    {

        Dash();
        Vector3 movementInput = m_playerInputHandler.GetMoveInput();
        Vector3 targetVelocity = new Vector3(movementInput.x*HorizontalSpeed,movementInput.y*VerticalSpeed,0f)*speedModifier;
        characterMovementVelocity = Vector3.Lerp(characterMovementVelocity,targetVelocity,MovementSharpness*Time.deltaTime);
       
        
        GroundCheck();
        
            transform.position += characterMovementVelocity * Time.deltaTime;
        
    }

    void Dash()
    {
        if (m_playerInputHandler.GetDashDown()&&DashCDTimeCount>=DashingCooldownTime)
        {
            DashTimeCount = 0f;
            IsDashing = true;
        }
        if (IsDashing&&DashTimeCount<DashingTime)
        {
            speedModifier = DashSpeedMultiplier;
            DashTimeCount += Time.deltaTime;
        }
        if (DashTimeCount>=DashingTime)
        {
            DashCDTimeCount = 0f;
            speedModifier = 1f;
            IsDashing = false;
            DashTimeCount = 0f;
        }
        if (!IsDashing&&DashCDTimeCount<DashingCooldownTime)
        {
            DashCDTimeCount += Time.deltaTime;
        }
        Debug.Log(DashCDTimeCount);
        Debug.Log(DashTimeCount);
    }

    void GroundCheck()
    {
        Vector3 startPoint = transform.position;

        Vector3 upPoint = startPoint + new Vector3(0f,1f,0f);
        Vector3 downPoint = startPoint + new Vector3(0f,-1f,0f);
        Vector3 leftPoint = startPoint + new Vector3(-1f,0f,0f);
        Vector3 rightPoint = startPoint + new Vector3(1f,0f,0f);

        RaycastHit2D rayUp = Physics2D.Raycast(upPoint,Vector3.forward,1f,1<<LayerMask.NameToLayer ("Ground"));
        
        RaycastHit2D rayDown = Physics2D.Raycast(downPoint, Vector3.forward, 1f, 1 << LayerMask.NameToLayer("Ground"));
        
        RaycastHit2D rayLeft = Physics2D.Raycast(leftPoint, Vector3.forward, 1f, 1 << LayerMask.NameToLayer("Ground"));
        
        RaycastHit2D rayRight = Physics2D.Raycast(rightPoint, Vector3.forward, 1f, 1 << LayerMask.NameToLayer("Ground"));
        

        if (rayUp.collider == null)
        {
            characterMovementVelocity =new Vector3( characterMovementVelocity.x,Mathf.Clamp(characterMovementVelocity.y, Mathf.NegativeInfinity, 0f),0f);
        }
        if (rayDown.collider == null)
        {
            characterMovementVelocity = new Vector3(characterMovementVelocity.x, Mathf.Clamp(characterMovementVelocity.y, 0f , Mathf.Infinity), 0f);
        }
        if (rayLeft.collider == null)
        {
            characterMovementVelocity = new Vector3(Mathf.Clamp(characterMovementVelocity.x,0f,Mathf.Infinity),characterMovementVelocity.y,0f);
        }
        if (rayRight.collider == null)
        {
            characterMovementVelocity = new Vector3(Mathf.Clamp(characterMovementVelocity.x,Mathf.NegativeInfinity,0f),characterMovementVelocity.y,0f);
        }
        
          
        
    }

}
