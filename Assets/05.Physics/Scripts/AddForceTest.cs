using System;
using UnityEngine;

public class AddForceTest : MonoBehaviour
{
    public float power;
    
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.AddForce(0,0,power);
    }
}
