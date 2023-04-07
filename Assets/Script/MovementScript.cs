using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform camera;

    private ActionsGameplay actions;
    [SerializeField] private Vector3 initialPos;

    // Start is called before the first frame update
    void Awake()
    {
        actions = new ActionsGameplay();
        actions.gameplay.drag.performed += Drag;
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirForward = camera.forward;
        dirForward.y = 0;
        Vector3 dirRight = camera.right;
        dirRight.y = 0;
        transform.position += dirForward * actions.gameplay.move.ReadValue<Vector2>().y * speed;
        transform.position += dirRight * actions.gameplay.move.ReadValue<Vector2>().x * speed;

        transform.Rotate(0, actions.gameplay.rotate.ReadValue<Vector2>().x * Time.deltaTime * rotationSpeed, 0);
    }

    private void Drag(InputAction.CallbackContext context)
    {
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
