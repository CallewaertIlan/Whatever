using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    public UnityEvent OnGravityClick;

    private static Singleton instance;
    public static Singleton Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError(gameObject.name + " : Multiple instances of Singleton");
            Destroy(gameObject);
        }

        instance = this;
    }

    public void ActiveGravity()
    {
        OnGravityClick.Invoke();
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(scene.buildIndex);
        SceneManager.LoadScene(scene.buildIndex);
    }
}
