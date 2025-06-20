using System;
using UnityEngine;

public class TransformMover : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector3 moveDir;
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
         moveDir = new Vector3(x, 0, z);
        
        // transform.Translate(moveDir * (moveSpeed * Time.deltaTime));
        // Rigidbody에 의해 물리 작용을 밪는 객체가 Update에서 transform을 제어하는 연산을 수행하면 물리연산과 시점이 맞지 않아 움직임이 어색함
        
        
    }

    private void FixedUpdate()
    {
        transform.Translate(moveDir * (moveSpeed * Time.fixedDeltaTime),Space.World);
        // 방법 1 : Transform 제어를 FixedUpdate에서 수행해서
        // Rigidbody의 위치 연산과 동기화 하는 방법이 있다.
        // 문제점 : 운동량 제어가 안됨(Rigidbody.linearVelocity와 angularVelocity값을 상쇄하지 못함.)
        
    }
}
