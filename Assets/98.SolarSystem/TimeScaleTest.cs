using System;
using UnityEngine;

public class TimeScaleTest : MonoBehaviour
{
    [Range(0.001f,10f)]
    public float timeScale;

    private void Update()
    {
        Time.timeScale = timeScale;
    }
}
