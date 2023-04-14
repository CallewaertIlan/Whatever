using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 GetPositionArea()
    {
        return new Vector3(transform.position.x, transform.position.y + transform.lossyScale.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable interactableScript = other.GetComponent<Interactable>();
        if (interactableScript != null && !interactableScript.isGrabbed && other.tag == "Domino")
        {
            other.transform.position = GetPositionArea();
            other.transform.localRotation = new Quaternion(0, 0, 0, 0);

            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
