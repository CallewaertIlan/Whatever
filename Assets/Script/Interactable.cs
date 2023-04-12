using System.Collections;
using System.Linq;
using Unity.VisualScripting;
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

    public void Grab(Vector3 dist, Transform tr)
    {

        isGrabbed = true;

        rb.isKinematic = true;

        MoveTo(dist);

        transform.SetParent(tr, true);
    }

    public void Release()
    {
        isGrabbed = false;

        rb.isKinematic = false;

        transform.SetParent(null, true);

    }

    public void Throw(Vector3 speed)
    {
        rb.AddForce(speed * 3, ForceMode.VelocityChange);
    }

    public void MoveTo(Vector3 position)
    {
        transform.position = position;
    }

    public void MoveBy(Vector3 position)
    {
        transform.position += position;
    }
}