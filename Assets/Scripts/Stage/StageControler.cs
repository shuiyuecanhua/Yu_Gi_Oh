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
    void Start()
    {
        
    }
     
    void Update()
    {
        
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,100,30),"抽卡"))
        {
            StartCoroutine(FaCard());
        }
    }
    IEnumerator FaCard()
    {
        yield return new WaitForEndOfFrame();
    }
}
