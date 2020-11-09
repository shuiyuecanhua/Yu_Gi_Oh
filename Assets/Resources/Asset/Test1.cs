using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    // Start is called before the first frame update
    int step = 0;
    public Transform target;
    public float time=1f;
    void Start()
    {
        step = 0;
        Debug.LogError("DDDD");
    }

    // Update is called once per frame
    void Update()
    {
        if (step==1)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, time);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, time);
            float a = Quaternion.Dot(transform.localRotation, Quaternion.identity);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, time);
            if (Mathf.Abs(a - 1) < 0.01)
            {
                transform.localRotation = Quaternion.identity;
                transform.localPosition = Vector3.zero;
                transform.localScale = Vector3.one;
                step = 2; 
            }
        }
    }
    private void OnGUI()
    {
        if (step == 0)
        {
            if (GUI.Button(new Rect(0, 50, 100, 30), "抽卡"))
            {
                Debug.LogError("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                transform.parent = target;
                step = 1;
            }
        }
    }
}
