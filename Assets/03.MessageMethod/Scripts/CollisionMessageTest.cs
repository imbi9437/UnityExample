using System;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionMessageTest : MonoBehaviour
{
    //물리적인 충돌 발생 시 호출되는 메시지 함수가 있음
    //OnCollisionXX 시리즈.
    //이 메시지 함수들은 호출 주체가 Physics와 관련이 있으므로
    //반드시 충돌한 오브젝트 중 하나에는 꼭 RigidBody가 붙어있어야 한다.
    
    //1. OnCollisionEnter : 충돌이 일어났을 때 호출
    private void OnCollisionEnter(Collision c) //충돌 상태의 정보가 담긴 객체(Collsition클래스)
    {
        Collider other = c.collider;
        Debug.Log($"충돌 발생! 나 : {name}, 부딛힌 애 : {other.name}");
    }
    
    //2. OnCollisionExit : 충돌되던 콜라이더가 다시 충돌이 아니게 되면 호출.
    private void OnCollisionExit(Collision c)
    {
        Collider other = c.collider;
        Debug.Log($"충돌 끝... 나 : {name}, 부딛힌 애 : {other.name}");
    }
    
    //3. OnCollisionStay : 충돌 중일때 프레임마다 호출
    private void OnCollisionStay(Collision c)
    {
        Collider other = c.collider; other = c.collider;
        Debug.Log($"충돌 중~~~ 나 : {name}, 부딛힌 애 : {other.name}");
        
    }
}
