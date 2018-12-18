﻿/**
 * @file         ShaderReferenceEditorWindow.cs
 * @author       Hongwei Li(taecg@qq.com)
 * @created      2018-11-10
 * @updated      2018-12-18
 *
 * @brief        着色器语法参考工具
 */

#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace taecg.tools.shaderReference
{
    public class ShaderReferenceEditorWindow : EditorWindow
    {
        #region 数据成员
        private string[] tabNames = new string[] { "GPU", "Pipline", "Properties", "Semantics", "SubShader", "Pass", "Math", "Miscellaneous", "About" };
        private int selectedTabID;

        private ShaderReferenceGPU gpu;
        private ShaderReferencePipline pipline;
        private ShaderReferenceProperties properties;
        private ShaderReferenceSemantics semantics;
        private ShaderReferenceSubShader subShader;
        private ShaderReferencePass pass;
        private ShaderReferenceMath math;
        private ShaderReferenceMiscellaneous miscellaneous;
        private ShaderReferenceAbout about;
        #endregion

        #region 编缉器入口
        [MenuItem("Window/Shader Reference...")]
        public static void Open()
        {
            ShaderReferenceEditorWindow window = EditorWindow.GetWindow<ShaderReferenceEditorWindow>();
            window.titleContent = new GUIContent("Shader");
            window.Show();
        }
        #endregion

        #region OnEnable/OnDisable
        void OnEnable()
        {
            // selectedTabID = EditorPrefs.HasKey(mPrefName + "selectedTabID") ? EditorPrefs.GetInt(mPrefName + "selectedTabID") : 0;
            // properties = ScriptableObject.CreateInstance<ShaderReferenceProperties>();
            gpu = new ShaderReferenceGPU();
            pipline = new ShaderReferencePipline();
            properties = new ShaderReferenceProperties();
            semantics = new ShaderReferenceSemantics();
            subShader = new ShaderReferenceSubShader();
            pass = new ShaderReferencePass();
            math = new ShaderReferenceMath();
            miscellaneous = new ShaderReferenceMiscellaneous();
            about = new ShaderReferenceAbout();
        }
        #endregion

        #region OnGUI
        void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();

            //绘制左侧标签栏
            float _width = 150;
            float _heigth = position.height - 10;
            EditorGUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.MaxWidth(_width), GUILayout.MinHeight(_heigth));
            selectedTabID = GUILayout.SelectionGrid(selectedTabID, tabNames, 1);
            EditorGUILayout.EndVertical();

            //绘制右侧内容区
            EditorGUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.MinWidth(position.width - _width), GUILayout.MinHeight(_heigth));
            switch (selectedTabID)
            {
                case 0:
                    gpu.DrawMainGUI();
                    break;
                case 1:
                    pipline.DrawMainGUI();
                    break;
                case 2:
                    properties.DrawMainGUI();
                    break;
                case 3:
                    semantics.DrawMainGUI();
                    break;
                case 4:
                    subShader.DrawMainGUI();
                    break;
                case 5:
                    pass.DrawMainGUI();
                    break;
                case 6:
                    math.DrawMainGUI();
                    break;
                case 7:
                    miscellaneous.DrawMainGUI();
                    break;
                case 8:
                    about.DrawMainGUI();
                    break;
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.EndVertical();
            Repaint();
        }
        #endregion
    }
}
#endif