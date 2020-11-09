#if UNITY_EDITOR
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
    public bool IsInit;
    FieldInfo[] fArray;
    Type tchild;
    Type type;
    Type listtype;
    System.Object config;
    IEnumerable configlist;
    Vector2 scrollpos;
     
    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("配置名字:");
        configname=EditorGUILayout.TextField(configname);
        configpath = Application.dataPath + "/Config/" + configname+".json"; 
        if (GUILayout.Button("确定"))
        {
            type= Type.GetType(configname);
            if (type == null)
            {
                ShowNotification(new GUIContent("当前没有此类:"+ configname));
                return;
            } 
            var _config = Activator.CreateInstance(type);
            if (File.Exists(configpath))
            {
                _config = JsonUtility.FromJson(File.ReadAllText(configpath), type);
            }
            tchild = Type.GetType(configname + "+Config"); 
            FieldInfo configpp = type.GetField("List");
            System.Object v = configpp.GetValue(_config);
            listtype = configpp.FieldType; 
            configlist = v as IEnumerable;
            config = _config;
            fArray = tchild.GetFields();
            return;
        }
        if (config == null)
            return;
        if (config!=null)
        {
            if (GUILayout.Button("保存"))
            {
                if (config == null) return;
                string jsonstr = JsonUtility.ToJson(config);
                if (File.Exists(configpath))
                {
                    File.Delete(configpath);
                }
                File.WriteAllText(configpath, jsonstr);
                AssetDatabase.SaveAssets();
            }
            if (GUILayout.Button("添加"))
            {
                Type t = tchild;
                object item;
                MethodInfo method = listtype.GetMethod("Add");
                item = Activator.CreateInstance(t);
                object[] tempt = new object[1];
                tempt[0] = item;
                method.Invoke(configlist, tempt);
            }
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

        scrollpos= EditorGUILayout.BeginScrollView(scrollpos);

        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();

        foreach (var _v in fArray)
        {
            EditorGUILayout.LabelField(_v.Name, GUILayout.Width(100));
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical();
        int index = 0;
        foreach (var _v in configlist)
        {
            EditorGUILayout.BeginHorizontal();
            foreach (var _v2 in fArray)
            {
                FieldInfo targetPP = tchild.GetField(_v2.Name);
                object value;  
                if(targetPP.FieldType.Name== "Int32")
                {
                    value = int.Parse(targetPP.GetValue(_v).ToString());
                    value = EditorGUILayout.IntField((int)value, GUILayout.Width(100));
                }
                else
                {
                    object obj = targetPP.GetValue(_v);
                    if (obj == null)
                    {
                        obj = "";
                    }
                    value = obj.ToString();
                    value = EditorGUILayout.TextField((string)value, GUILayout.Width(100));
                }
                targetPP.SetValue(_v, value);
            }
            if (GUILayout.Button("删除",GUILayout.Width(100)))
            {
                MethodInfo method = listtype.GetMethod("RemoveAt"); 
                object[] tempt = new object[1];
                tempt[0] = index;
                method.Invoke(configlist, tempt);
                return;
            }

            index++;
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();

    }
}
#endif