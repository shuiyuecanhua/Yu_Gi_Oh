using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void Calback();
public delegate T Calback<T>();
public delegate T Calback<T,T1>();
public delegate T Calback<T, T1,T3>();
public class Events : MonoBehaviour
{ 
    public static Events _instance;

    public static Events GetInstance()
    {
        if (_instance == null)
        {
            _instance = GameObject.FindObjectOfType<Events>();
        }
        return _instance;
    }

    Calback func;
    public void AddLister(EventDefine _event,Calback _func1)
    {

    }
    public void CalEvent<T,T1>(EventDefine _event,T t,T1 t2)
    {

    }
    public void CalEvent(EventDefine _event)
    {
            
    }
}
