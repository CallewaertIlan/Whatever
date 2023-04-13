using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GravityOnClick : MonoBehaviour
{
    [SerializeField] private UnityEvent OnGravityClick;

    private static GravityOnClick instance;
    public static GravityOnClick Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    public void OnClick()
    {
        OnGravityClick.Invoke();
    }
}
