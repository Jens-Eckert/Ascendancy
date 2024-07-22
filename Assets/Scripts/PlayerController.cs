using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions m_actions;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_actions ??= new InputSystem_Actions();
        m_actions.Player.SetCallbacks(this);

        m_actions.UI.Disable();
        m_actions.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Move " + context.action.name);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
