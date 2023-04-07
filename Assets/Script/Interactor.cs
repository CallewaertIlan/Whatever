using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public float grabDistance = 0.1f;
    public LayerMask interactableLayer;
    private Interactable currentInteractable = null;
    private Vector3 grabOffset = Vector3.zero; // l'offset de position entre la position de l'objet et la position du contrôleur VR lors de la saisie

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
            Debug.Log("test");
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, grabDistance, interactableLayer))
            {

                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null && !interactable.isGrabbed)
                {
                    currentInteractable = interactable;
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
                currentInteractable = null;
            }
        }

        if (currentInteractable != null)
        {
            currentInteractable.MoveTo(transform.position + grabOffset);
        }
    }

    void Drag(InputAction.CallbackContext context)
    {
        grip = !grip;
    }
}