using System;
using UnityEngine;

public class RigidbodyMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);
        
        // transform.Translate();
        Vector3 currentPos = rb.position;
        rb.MovePosition(currentPos + moveDir * (moveSpeed * Time.deltaTime));
        // 방법 3 : rigidbody.MoveXXX 메소드 사용
        // 파라미터로 전달받은 위치로 물체를 이동시키는데, 이동시키는 시점이 Update에서 호출된 즉시가 아닌
        // 다음 FixedUpdate, 즉 물리 연산이 수행되는 시점에서 해당 위치로 이동
    }
}
