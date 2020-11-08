using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class SplitMeshEditor
{
    [MenuItem("Tool/Split")]
    public static void Split()
    {
        GameObject obj = Selection.activeGameObject;
        Debug.LogError(obj.name);
        Transform trans = obj.transform;
        Renderer render=obj.GetComponent<Renderer>();
        Bounds bunds = render.bounds;
        Vector3 max = bunds.max;
        Vector3 min = bunds.min;
        
        float len =(float)( (max.x - min.x) / 5);
        int count = trans.childCount;
        for (int i=0;i<count;i++)
        {
            var tran = trans.GetChild(i);
            Vector3 pos = tran.transform.position;
            pos.x = min.x + (len * (i + 1));
            tran.transform.position = pos;
        }
    }
}
