using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float speed;

    private ActionsGameplay actions;

    // Start is called before the first frame update
    void Awake()
    {
        actions = new ActionsGameplay();
        actions.gameplay.drag.performed += Drag;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(actions.gameplay.move.ReadValue<Vector2>().x * Time.deltaTime * speed, 0, actions.gameplay.move.ReadValue<Vector2>().y * Time.deltaTime * speed);
    }

    private void Drag(InputAction.CallbackContext context)
    {
        Debug.Log("Drag");
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
