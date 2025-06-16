using System;
using UnityEngine;

public class FollowingEnemyTest : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float rotateSpeed;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 moveDir = target.position - transform.position;
        moveDir.y = 0;
        moveDir = moveDir.normalized * moveSpeed;
        // rb.linearVelocity = moveDir;
        rb.MovePosition(rb.position + moveDir * Time.deltaTime);
    }
}
