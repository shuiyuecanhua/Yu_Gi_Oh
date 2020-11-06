using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Stage
{
    Red_Begin,
    Red_DrawCard,
    Red_Prepare,
    Red_Fight,
    Red_PrepareAgain,
    Red_Over,
    Blue_Begin, 
    Blue_DrawCard,
    Blue_Prepare,
    Blue_Fight,
    Blue_PrepareAgain,
    Blue_Over, 
}
public class StageControler : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Events.GetInstance().AddLister(EventDefine.Blue_Begin,()=> { Debug.LogError("blue_begin"); });
        Events.GetInstance().CalEvent(EventDefine.Blue_Begin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
