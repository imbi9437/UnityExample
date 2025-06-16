using System;
using UnityEngine;

public class VelocityMover : MonoBehaviour
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
        // 방법 2 : Rigidbody의 Property의 방향값을 직접 대입
        // GetComponent<Rigidbody>(); 매 프레임마다 GetComponent를 호출하면 불필요한 오버헤드가 발생
        // 중력에 의한 y축 운동량은 보존을 한 상태로 x, z축만 제어하려면
        
        // moveDir = rb.linearVelocity;
        // moveDir.x = x;
        // moveDir.z = z;
        
        // moveDir = new Vector3(x * moveSpeed, rb.linearVelocity.y, z * moveSpeed);
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        moveDir = new Vector3(x, 0, z) * moveSpeed;
        moveDir.y = rb.linearVelocity.y;

        rb.linearVelocity = moveDir;
    }
}
