using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;

public class PentagramRadar : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float radius=47f;
    // Start is called before the first frame update
    
    public RoleUI roleUI;
    
    
    public float maxHealth=300f;
    public float maxAttack=50f;
    public float maxDefense=80f;
    public float maxArmor=100f;
    public float maxAgility=10f;
    
    public float[] maxStatus;
    private void Awake()
    {
        maxStatus = new float[] { maxHealth, maxAttack, maxDefense, maxArmor, maxAgility };
    }
    

    public void DrawPentagram(List<float> status)
    {
        
        lineRenderer.useWorldSpace = false; //相对位置 而非世界位置
        
        int points = 5; // 五个顶点
        // 设置 LineRenderer 的顶点数量：外圈和内圈各 5 个点，再加上一个闭合点
        lineRenderer.positionCount = points + 1; // 10 个顶点 + 闭合点（第一个点）
        Vector3[] positions = new Vector3[points + 1]; // 用于存储所有顶点的位置
        
        for (int i = 0; i < points; i++)
        {
            // 计算外圈点的位置
            float angle = i * Mathf.PI * 2f / points; // 根据角度分布五个外圈点，角度为 360°/5
            positions[i] = new Vector3(  
                Mathf.Cos(angle)*radius*(status[i]/maxStatus[i]),         // X 坐标：cos(角度) * 半径
                Mathf.Sin(angle)*radius*(status[i]/maxStatus[i]),         // Y 坐标：sin(角度) * 半径
                0);                            // Z 坐标：保持为 0
            
        }

        positions[points] = positions[0]; 

        // 将计算出来的顶点坐标传给 LineRenderer，绘制五芒星的轮廓
        lineRenderer.SetPositions(positions);

        // 设置 LineRenderer 的线条宽度为 0.1f
        lineRenderer.startWidth = 5f;  // 起始宽度
        lineRenderer.endWidth = 5f;    // 结束宽度
     
    }
    

}
