using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector3 GetMoveInput()
    {

        return new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0f);

    }
    
    public bool GetDashDown()
    {
        return Input.GetButtonDown("Dash");
    }

}
