using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;
    private Vector3 moveDir;

    
    private float effectTime;
    private bool isHit = false;
    
    public int hp;
    public float moveSpeed = 5f;
    public Bullet bullet;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        spriteRenderer.flipX = x < 0;
        
        moveDir = new Vector3(x, y).normalized;
        Move(moveDir);
        
        if (Input.GetButtonDown("Jump") || Input.GetMouseButton(0))
        {
            //transform.position += moveDir.normalized * moveSpeed;
            //움직이는 방향으로 앞으로 일정 거리만크 순간이동 하도록
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스가 스크린에서 어느 위치에 있는지 월드 좌표를 반환하는 함수
            
            //위치1 에서 위치2로 향하는 방향벡터를 구하는 공식 : 위치2 - 위치1
            //방향 벡터를 활용할 때, 힘의 크기가 필요 없다면 벡터 길이를 1로 고정.
            Vector3 fireDir = mousePos - transform.position;
            fireDir.z = 0;
            Fire(fireDir.normalized);
        }

        if (!isHit) return;

        effectTime += GameManager.Instance.effectSpeed * Time.deltaTime;
        spriteRenderer.color = GameManager.Instance.hitEffectGradient.Evaluate(effectTime);
        if (effectTime > 1)
        {
            isHit = false;
        }
    }

    private void Move(Vector3 dir)
    {
        //transform.Translate(dir * (moveSpeed * Time.deltaTime));
        rigid.linearVelocity = dir * moveSpeed;
    }

    private void Fire(Vector3 fireDir)
    {
        Bullet obj = Instantiate(bullet, transform.position, Quaternion.identity);
        obj.moveDir = fireDir;
    }

    public void Hit()
    {
        hp--;
        if (hp <= 0) Application.Quit();
        
        isHit = true;
        effectTime = 0f;
    }
}
