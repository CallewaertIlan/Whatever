using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float grabDistance;
    [SerializeField] private LayerMask interactableLayer;
    private Interactable currentInteractable = null;
    [SerializeField] private Queue<Vector3> positionLastFrames = new Queue<Vector3>(10);


    private ActionsGameplay actions;
    private bool grip = false;

    private void Awake()
    {
        actions = new ActionsGameplay();
        actions.gameplay.drag.performed += Drag;
    }

    private void Update()
    {

        if (grip)
        {
            RaycastHit hit;
            Debug.Log(grabDistance);
            if (Physics.Raycast(transform.position, -transform.up, out hit, grabDistance, interactableLayer))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null && !interactable.isGrabbed)
                {
                    currentInteractable = interactable;
                    Quaternion rotation = currentInteractable.transform.localRotation;
                    currentInteractable.Grab(transform.position - transform.up * 0.1f, transform);

                    currentInteractable.transform.rotation = rotation;
                }
            }
        }
        else
        {
            if (currentInteractable != null)
            {
                currentInteractable.Release();
                Vector3 average = Average(positionLastFrames);
                currentInteractable.Throw(average / Time.deltaTime);
                
                currentInteractable = null;
            }
        }

        positionLastFrames.Enqueue(transform.position);
        if (positionLastFrames.Count >= 10)
        {
            positionLastFrames.Dequeue();
        }
    }

    void Drag(InputAction.CallbackContext context)
    {
        grip = !grip;
    }

    Vector3 Average(Queue<Vector3> list)
    {
        List<Vector3> distance = new List<Vector3>();
        Vector3 average = Vector3.zero;
        Vector3 firstElement;
        Vector3 secondElement;
        firstElement = list.Dequeue();
        secondElement = firstElement;

        int count = list.Count;

        for (int i = 0; i < count - 1; i++)
        {
            firstElement = secondElement;
            secondElement = list.Dequeue();
            distance.Add(secondElement - firstElement);
        }

        for (int j = 0; j < distance.Count; j++)
        {
            average += distance[j];
        }

        return (average / distance.Count);
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