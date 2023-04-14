using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform cam;

    private ActionsGameplay actions;
    [SerializeField] private Vector3 initialPos;

    // Start is called before the first frame update
    void Awake()
    {
        actions = new ActionsGameplay();
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirForward = cam.forward;
        dirForward.y = 0;
        Vector3 dirRight = cam.right;
        dirRight.y = 0;
        transform.position += dirForward * actions.gameplay.move.ReadValue<Vector2>().y * speed;
        transform.position += dirRight * actions.gameplay.move.ReadValue<Vector2>().x * speed;

        transform.Rotate(0, actions.gameplay.rotate.ReadValue<Vector2>().x * Time.deltaTime * rotationSpeed, 0);

        transform.position = new Vector3(transform.position.x, initialPos.y - (initialPos.y - transform.position.y), transform.position.z);
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
