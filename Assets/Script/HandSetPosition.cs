using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSetPosition : MonoBehaviour
{
    [SerializeField] private bool rightSide;

    private ActionsGameplay actions;

    // Start is called before the first frame update
    void Start()
    {
        actions = new ActionsGameplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (rightSide)
        {
            //transform.position = actions.gameplay.right_hands.ReadValue<Vector3>();
            Debug.Log("Right Hand " + actions.gameplay.right_hand.ReadValue<Vector3>());
        }
        else
        {
            //transform.position = actions.gameplay.left_hands.ReadValue<Vector3>();
            Debug.Log("Left Hand " + actions.gameplay.left_hand.ReadValue<Vector3>());
        }
    }
}
