using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void Calback0();
public delegate void Calback1(object obj);
public delegate void Calback2(object obj, object obj2);
public delegate void Calback3(object obj, object obj2, object obj3);
public class Events : MonoBehaviour
{ 
    public static Events _instance;
    Dictionary<object, List<Calback0>> Calback0 = new Dictionary<object, List<Calback0>>();
    Dictionary<object, List<Calback1>> Calback1 = new Dictionary<object, List<Calback1>>();
    Dictionary<object, List<Calback2>> Calback2 = new Dictionary<object, List<Calback2>>();
    Dictionary<object, List<Calback3>> Calback3 = new Dictionary<object, List<Calback3>>();
    public static Events GetInstance()
    {
        if (_instance == null)
        {
            _instance = GameObject.FindObjectOfType<Events>();
        }
        return _instance;
    } 
    public void AddLister(object _event, Calback0 _func1)
    {
        if(!Calback0.ContainsKey(_event))
        {
            Calback0.Add(_event, new List<Calback0>());
        }
        if (Calback0[_event].Contains(_func1))
        {
            return;
        }
        Calback0[_event].Add(_func1);
    }
    public void AddLister(object _event, Calback1 _func1)
    {
        if (!Calback1.ContainsKey(_event))
        {
            Calback1.Add(_event, new List<Calback1>());
        }
        if (Calback1[_event].Contains(_func1))
        {
            return;
        }
        Calback1[_event].Add(_func1);
    }
    public void CalEvent(object _event)
    {
        if (Calback0.ContainsKey(_event))
        {
            foreach (var v in Calback0[_event])
            {
                v();
            }

        }
    }
    public void CalEvent(object _event, object obj1)
    {
        if (Calback1.ContainsKey(_event))
        {
            foreach (var v in Calback1[_event])
            {
                v(obj1);
            }

        }
    }
    public void CalEvent(object _event, object obj1, object obj2)
    {
        if (Calback2.ContainsKey(_event))
        {
            foreach (var v in Calback2[_event])
            {
                v(obj1,obj2);
            }

        }
    }
    public void CalEvent(object _event, object obj1, object obj2, Object obj3)
    {
        if (Calback3.ContainsKey(_event))
        {
            foreach (var v in Calback3[_event])
            {
                v(obj1, obj2, obj3);
            }

        }
    }
    public void RemoveEvent(object _event)
    {
        if (Calback0.ContainsKey(_event))
        {
            Calback0.Remove(_event);
        }
        if (Calback1.ContainsKey(_event))
        {
            Calback1.Remove(_event);
        }
        if (Calback2.ContainsKey(_event))
        {
            Calback2.Remove(_event);
        }
        if (Calback3.ContainsKey(_event))
        {
            Calback3.Remove(_event);
        }
    }
    public void RemoveEvent(object _event, object obj)
    {
        if (Calback0.ContainsKey(_event))
        {
            for (int i= 0;i< Calback0[_event].Count;i++)
            {
                object v = Calback0[_event][i];
                if (v == obj)
                {
                    Calback0[_event].RemoveAt(i);
                    break;
                }
            }
            Calback0.Remove(_event);
        }
        if (Calback1.ContainsKey(_event))
        {
            for (int i = 0; i < Calback1[_event].Count; i++)
            {
                object v = Calback1[_event][i];
                if (v == obj)
                {
                    Calback1[_event].RemoveAt(i);
                    break;
                }
            }
            Calback1.Remove(_event);
        }
        if (Calback2.ContainsKey(_event))
        {
            for (int i = 0; i < Calback2[_event].Count; i++)
            {
                object v = Calback2[_event][i];
                if (v == obj)
                {
                    Calback2[_event].RemoveAt(i);
                    break;
                }
            }
            Calback2.Remove(_event);
        }
        if (Calback3.ContainsKey(_event))
        {
            for (int i = 0; i < Calback3[_event].Count; i++)
            {
                object v = Calback3[_event][i];
                if (v == obj)
                {
                    Calback3[_event].RemoveAt(i);
                    break;
                }
            }
            Calback3.Remove(_event);
        }
    }
}
