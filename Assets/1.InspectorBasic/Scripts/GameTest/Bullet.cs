using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 moveDir;
    public float moveSpeed = 20f;
    public float lifeTime = 5f;
    public float time = 0f;

    private void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    private void Update()
    {
        if (moveDir == Vector3.zero) Destroy(gameObject);
        transform.position += moveDir * (moveSpeed * Time.deltaTime);
        //transform.Translate(moveDir * (moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
