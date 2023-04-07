using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent OnGrab;
    public UnityEvent OnRelease;

    private Rigidbody rb;
    public bool isGrabbed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Grab()
    {
        isGrabbed = true;

        rb.isKinematic = true;

    }

    public void Release()
    {
        isGrabbed = false;

        rb.isKinematic = false;

    }

    public void MoveTo(Vector3 position)
    {
        transform.position = position;
    }
}