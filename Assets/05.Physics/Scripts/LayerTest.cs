using System;
using UnityEngine;

public class LayerTest : MonoBehaviour
{
    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        //키보드로 2를 눌렀을 때만 레이어를 "Wall"레이어로 교체하고 싶다.
        gameObject.layer = Input.GetKey(KeyCode.Alpha2) ? LayerMask.NameToLayer("Wall") : LayerMask.NameToLayer("Default");
        renderer.material.color = Input.GetKey(KeyCode.Alpha2) ? new Color(1, 1, 1, 0.5f) : new Color(1, 1, 1, 1);
    }
}
