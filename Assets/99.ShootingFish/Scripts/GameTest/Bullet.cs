using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 moveDir;
    public float moveSpeed = 20f;

    private void Update()
    {
        transform.position += moveDir * (moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) return;
        
        Destroy(gameObject);

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Hit();
        }
    }
}
