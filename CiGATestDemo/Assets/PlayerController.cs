using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float MovementSharpness;


    Vector3 characterMovementVelocity { get; set; }




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
        Vector3 movementInput = m_playerInputHandler.GetMoveInput();
        Vector3 targetVelocity = new Vector3(movementInput.x*HorizontalSpeed,movementInput.y*VerticalSpeed,0f);
        characterMovementVelocity = Vector3.Lerp(characterMovementVelocity,targetVelocity,MovementSharpness*Time.deltaTime);
        transform.position += characterMovementVelocity * Time.deltaTime;
    }
}
