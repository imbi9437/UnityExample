using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Bullet bullet;
    private SpriteRenderer spriteRenderer;
    
    public Vector3 moveDir;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //매 프레임마다 한번씩 호출
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        spriteRenderer.flipX = x < 0;
        
        moveDir = new Vector3(x, y).normalized;
        Move(moveDir);
        
        if (Input.GetButtonDown("Jump"))
        {
            //transform.position += moveDir.normalized * moveSpeed;
            //움직이는 방향으로 앞으로 일정 거리만크 순간이동 하도록
            Bullet obj = Instantiate(bullet, transform.position, Quaternion.identity);
            obj.moveDir = moveDir;
        }
    }

    private void Move(Vector3 dir)
    {
        //내 게임 오브젝트에 부착되어 있는 transform component를 바로 참조할 수 있음.
        //transform.position = new vector3(1, 0, 0); //내 객체의 position을 정확히 월드좌표 (1,0,0)으로 이동시킴
        //transform.position.x++ //Transform.position이 프로퍼티이기 때문에 내부 필드인 x값을 바로 수정할 수 없음.

        //Translate 메서드 : 이동할 방향 벡터를 파라미터로 입력하면 현재 위치에서 해당 위치로 이동
        transform.Translate(dir * (moveSpeed * Time.deltaTime));

        //transform.position += moveDir * Time.deltaTime;

        //Vector3 currentPosition = transform.position;
        //currentPosition.x += moveDir.x * Time.deltaTime; //Time.deltaTime : 매 프레임마다 이전 프레임과의 시간 간격을 반환
        //currentPosition.y += moveDir.y * Time.deltaTime;
        //transform.position = currentPosition;
    }
}
