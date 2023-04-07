using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSetPosition : MonoBehaviour
{
    [SerializeField] private bool rightSide;

    private ActionsGameplay actions;

    // Start is called before the first frame update
    void Awake()
    {
        actions = new ActionsGameplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (rightSide)
        {
            transform.localPosition = actions.gameplay.right_hand.ReadValue<Vector3>();
            transform.rotation = actions.gameplay.right_hand_rotation.ReadValue<Quaternion>();
        }
        else
        {
            transform.localPosition = actions.gameplay.left_hand.ReadValue<Vector3>();
            transform.rotation = actions.gameplay.left_hand_rotation.ReadValue<Quaternion>();
        }
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