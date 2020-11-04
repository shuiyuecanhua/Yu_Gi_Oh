using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Reflection;

public class ConfigEditorWindow : EditorWindow
{
    [MenuItem("Tool/ConfigEditorWindow", false,1)]
    public static void OpenWindow()
    {
        ConfigEditorWindow config = EditorWindow.GetWindow<ConfigEditorWindow>();
        config.titleContent = new GUIContent("ConfigEditorWindow");
    }
    private string configname;
    private string configpath;
    private string[] keys;
    FieldInfo[] fArray;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("配置名字:");
        configname=EditorGUILayout.TextField(configname);
        configpath = Application.dataPath + "configpath/"+ configname+".json";
        
        
        if (GUILayout.Button("确定"))
        {
            Type t = Type.GetType(configname);
            if (t == null)
            {
                ShowNotification(new GUIContent("当前没有此类:"+ configname));
                return;
            }
            var v = new object();
            v = Activator.CreateInstance(t);
            if (File.Exists(configpath))
            {
                v=JsonUtility.FromJson(File.ReadAllText(configpath), t);
            }
            FieldInfo targetPP = t.GetField("configname");
            string tclassname= (string)targetPP.GetValue(v);
            Type tchild = Type.GetType(tclassname);
            fArray = tchild.GetFields();
            return;
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        if (fArray == null)
        {
            return;
        }


        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        
        foreach (var v in fArray)
        {
            EditorGUILayout.LabelField(v.Name,GUILayout.Width(100));
        } 
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        
    }
}
