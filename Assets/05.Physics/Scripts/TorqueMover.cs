using System;
using UnityEngine;

public class TorqueMover : MonoBehaviour
{
    public float moveTorque = 30f;
    public float boostPower = 20f;
    
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float z = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");

        // angularVelocity : linearVelocity가 물체를 이동하는 운동량이라고 하면,
        // angularVelocity는 물체를 회전시키는 운동량.
        rb.angularVelocity = new Vector3(x, 0, -z) * moveTorque;

        if (Input.GetButton("Jump"))
        {
            rb.AddTorque(0,boostPower,0,ForceMode.Force);
            
            //AddTorque : AddForce의 angular 버전.
            //순간적으로 회전 운동량을 추가해줌
        }
    }
}
