using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float grabDistance = 1f;
    [SerializeField] private LayerMask interactableLayer;
    private Interactable currentInteractable = null;
    private Vector3 grabOffset = Vector3.zero; // l'offset de position entre la position de l'objet et la position du contrôleur VR lors de la saisie
    private float distance;

    private ActionsGameplay actions;
    private bool grip = false;

    private void Awake()
    {
        actions = new ActionsGameplay();
        actions.gameplay.drag.performed += Drag;
    }

    private void Update()
    {
        Debug.Log(actions.gameplay.left_hand_speed.ReadValue<Vector3>());
        if (grip)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, grabDistance, interactableLayer))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                //grabDistance = interactable.transform.lossyScale.x;

                if (interactable != null && !interactable.isGrabbed)
                {
                    currentInteractable = interactable;
                    distance = hit.distance;
                    grabOffset = currentInteractable.transform.position - transform.position;
                    currentInteractable.Grab();
                }
            }
        }
        else
        {
            if (currentInteractable != null)
            {
                currentInteractable.Release();
                currentInteractable.Throw(actions.gameplay.left_hand_speed.ReadValue<Vector3>());
                currentInteractable = null;
            }
        }

        if (currentInteractable != null)
        {
            currentInteractable.MoveTo(transform.position + grabOffset);
            //currentInteractable.transform.position += transform.forward * dist;
        }
    }

    void Drag(InputAction.CallbackContext context)
    {
        grip = !grip;
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