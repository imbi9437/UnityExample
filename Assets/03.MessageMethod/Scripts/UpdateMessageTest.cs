using System;
using UnityEngine;

public class UpdateMessageTest : MonoBehaviour
{
    //유니티의 Update계열 메시지 함수는 매 프레임 또는 갱신이 필요한 일정 주기마다 호출된다는 공통점이 있으나,
    //용도에 따라 호출되는 시점이 조금 차이가 있다.
    
    //1. Update : 매 프레임의 중간에 호출

    private float preFrameTime = 0; //이전 프레임의 호출시간
    
    private void Update()
    {
        Debug.Log($"Update 호출됨. 호출시간 : {Time.time}, 이전 프레임과 시간차이 : {Time.time - preFrameTime}");
        preFrameTime = Time.time;
        Debug.Log($"deltaTime : {Time.deltaTime}");
    }
    
    //2. FixedUpdate : 프레임과는 별개로 물리 연산이 수행될 때마다 호출. 호출 주기가 고정되어있음.
    //언제쓰냐 : Transform과 물리연산을 수행하기 가장 좋은 시점.
    //주의할 점 : Update와 호출 시점이 다르므로, 입력이나 렌더링 등을 수행하기에는 부족함.
    private float preFixedFrameTime = 0;
    private void FixedUpdate()
    {
        Debug.Log($"FixedUpdate 호출됨. 호출시간 : {Time.time}, 이전 프레임과 시간차이 : {Time.time - preFixedFrameTime}");
        preFixedFrameTime = Time.time;
        Debug.Log($"fixedDeltaTime : {Time.fixedDeltaTime}");
        
        //이 입력은 무시 될 수 있음
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
        }
    }
    
    //3. LateUpdate : 매 프레임의 모든 프로세스(런더링, 충돌처리 등)가 수행된 후 맨 마지막에 호출
    //동일 프레임에서 호출 되므로 Update와는 호출 순서만 다를뿐 시간차이는 크지 않음.
    //언제쓰냐 : 다른 모든 객체들의 렌더링이 끝난 후 호출되므로, 카메라 움직임 등을 제어하기 좋음

    private void LateUpdate()
    {
        Debug.Log($"LateUpdate 호출됨. 호출시간 : {Time.time}, update 호출 시점과의 시간차이 시간차이 : {Time.time - preFrameTime}");
    }
        
    //update 관련 메시지 함수의 공통적인 주의점 : 
    //메시지 함수는 아예 정의되어 있지 않으면 호출 자체를 안하며
    //만약 메시지 함수가 정의는 되어있는데 내용이 없을 경우
    //즉, 빈 Update등 의미없는 메소드를 정의하더라도 일단 호출을 하므로 일정부분 오버해드 발생
}
