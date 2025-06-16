using System;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    private Collider col;
    private Renderer renderer;

    private void Awake()
    {
        col = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        //키보드 '1' 누를 시
        //col.isTrigger = Input.GetKey(KeyCode.Alpha1); //콜라이더를 트리거로 변경
        col.enabled = Input.GetKey(KeyCode.Alpha1); //콜라이더를 비활성화
        renderer.material.color = col.isTrigger ? new Color(1, 1, 1, 0.5f) : new Color(1, 1, 1, 1);
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     other.transform.localScale = Vector3.one * 1.2f;
    // }
}
