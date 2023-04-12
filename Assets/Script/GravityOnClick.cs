using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GravityOnClick : MonoBehaviour
{
    public UnityEvent OnGravityClick;
    private ActionsGameplay actions;

    // Start is called before the first frame update
    void Awake()
    {
        actions = new ActionsGameplay();
        actions.gameplay.drag.performed += OnClick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        OnGravityClick.Invoke();
        Debug.Log("ca lance");
    }
    void OnEnable()
    {
        actions.gameplay.Enable();
    }
    void OnDisable()
    {
        actions.gameplay.Disable();
    }
}
