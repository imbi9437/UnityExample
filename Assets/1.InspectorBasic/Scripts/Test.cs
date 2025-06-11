using System;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    
    private void Start()
    {
        Debug.Log("Hello World!");
        
        MyDataContainer data = new MyDataContainer();
        data.a = 1;
        data.b = 3;
        
        Debug.Log($"myData.a = {data.a}, myData.b = {data.b}");
    }
}

public class MyDataContainer
{
    public int a;
    public int b;
}