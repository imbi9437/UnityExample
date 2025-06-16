using System;
using UnityEngine;

public class AddForceMover : MonoBehaviour
{
    public float moveForce = 10f;
    public ForceMode forceMode;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //최대 운동량 고정
        rb.maxLinearVelocity = 10f;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {   //Rigidbody 컴포넌트의 특정 방향으로 힘을 가할때 AddForce 함수를 사용
            // rb.AddForce(Vector3.up * moveForce, forceMode);
            
            //ForceMode
            //              중량값 적용      중량값 무시
            //가속도 추가 => Force           =>Acceleration      : Update 즉 지속적으로 운동량을 누적해야 할 때
            //운동량 추가 => Impulse         =>VelocityChange    : 단발성 충돌 효과를 주려 할 때
        }

        if (Input.GetButton("Jump"))
        {
            rb.AddForce(Vector3.up * moveForce, forceMode);
        }
    }
}
