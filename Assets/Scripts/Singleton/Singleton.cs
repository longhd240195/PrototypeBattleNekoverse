using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;

                if (instance == null)
                {
                    GameObject g = new GameObject();
                    instance = g.AddComponent<T>();
                    instance.gameObject.name = instance.GetType().Name;
                    DontDestroyOnLoad(g);
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    public void Reset()
    {
        instance = null;
    }

    public static bool Exists()
    {
        return (instance != null);
    }
}
