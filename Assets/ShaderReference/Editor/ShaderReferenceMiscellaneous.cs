/**
 * @file         ShaderReferenceMath.cs
 * @author       Hongwei Li(taecg@qq.com)
 * @created      2018-12-05
 * @updated      2018-12-05
 *
 * @brief        杂项，一些算法技巧
 */

#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace taecg.tools.shaderReference
{
    public class ShaderReferenceMiscellaneous : EditorWindow
    {
        #region 数据成员
        private Vector2 scrollPos;
        #endregion

        public void DrawMainGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
            ShaderReferenceUtil.DrawTitle("Miscellaneous");
            ShaderReferenceUtil.DrawOneContent("float3 objCenterPos = mul( unity_ObjectToWorld, float4( 0, 0, 0, 1 ) ).xyz;", "在Shader中获取当前模型的中心点，其实就是将(0,0,0)点从本地转换到世界空间坐标下即可，在制作对象从下往之类的效果时常用到。");
            EditorGUILayout.EndScrollView();
        }
    }
}
#endif