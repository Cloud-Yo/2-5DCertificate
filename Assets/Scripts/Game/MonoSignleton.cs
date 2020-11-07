using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSignleton<T> : MonoBehaviour where T : MonoSignleton<T>
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("MonoSingleton Instance is null for: " + _instance);
               
            }

            return _instance;
        }
    }

    private void Awake()
    {

        if (_instance != null && _instance != (T)this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = (T)this;
        }

    }

    public virtual void Init()
    {
        //code
    }
}
