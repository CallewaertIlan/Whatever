using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReloadSceneButton : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private GameObject presser;
    private bool isPressed;


    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed && other != null)
        {
            button.transform.localPosition = new Vector3(0, 0.03f, 0);
            presser = other.gameObject;
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser && isPressed)
        {
            isPressed = false;
            button.transform.localPosition = new Vector3(0, 0.05f, 0);
            Singleton.Instance.ReloadScene();
        }
    }
}
