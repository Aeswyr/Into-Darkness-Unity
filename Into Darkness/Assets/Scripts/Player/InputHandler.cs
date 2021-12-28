using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public Vector2 dir {
        get;
        private set;
    }

    void FixedUpdate()
    {
        
    }

    public void Move(InputAction.CallbackContext ctx) {
        if (ctx.canceled)
            dir = Vector2.zero;
        else
            dir = ctx.ReadValue<Vector2>();
    }
}
