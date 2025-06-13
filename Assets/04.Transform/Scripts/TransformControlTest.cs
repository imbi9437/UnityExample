using System;
using UnityEngine;

public class TransformControlTest : MonoBehaviour
{
    //Transform : 유니티의 모든 게임 오브젝트가 한개씩 가지고 있는 컴포넌트
    //기본적으로 게임 씬 상에서 위치, 각도(방향), 크기 등을 제어 할 수 있다.
    //Hierarchy상에서의 부모/자식 관게도 Transform을 통해 제어된다.
    //자식 오브젝트는 기본적으로 부모 오브젝트의 움직임을 따라가도록 되어있기 때문.
    public Transform lookTarget;

    private void Start()
    {
        //ControlStraightly();
        //ControlByDirection();
        //ControlByMethod();
        
        //transform.position = new Vector3(5, 0, 0);
        //transform.Translate(5,0,0);
    }

    private void Update()
    {
        //ControlByDirection();
        // transform.Translate(0,0,5 * Time.deltaTime);
        //transform.Rotate(30 * Time.deltaTime, 0, 0);
    }

    //Transform의 위치 제어 기능
    //1. 값을 직접 대입하여 위치를 이동
    private void ControlStraightly()
    {
        //transform.position : 프로퍼티이기 때문에, get 과정에서 값만 입력받는게 아니라, 실제 게임상에서 위치를 이동한다.
        transform.position = new Vector3(3, 2, 1); //x : 3, y : 2, z : 1

        //transform.rotation : 짐벌락 현상을 방지하기 위해 사원수 자료형인 Quaternion을 사용함.
        //transform.rotation = new Quaternion(0.3f, 0.02f, 0.001f, 0);
        //사람이 각도를 정확히 예측하여 값을 지정하기 어렵다.(직관적이지 않다.)
        //직관적으로 사용하기 위해서는 X,Y,Z축의 각도(0~360)를 제어하는게 좋다.
        //개발자가 rotation의 값을 직관적으로 제어하기 위해서 오일러각을 활용.
        transform.rotation = Quaternion.Euler(45,30,90);

        transform.localScale = new Vector3(4, 5, 6);
    }
    
    //2. rotation을 제어할 때, 방향을 이용하는 법
    private void ControlByDirection()
    {   //바라볼 방향 구하기 : 내 transform이 lookTarget을 바라봐야 함.
        Vector3 lookDir = lookTarget.position - transform.position;
        //방향 벡터로 활용 할때는 크기가 상관이 없다.
        
        // transform.right;//x축으로 +가 되는 방향
        // transform.up    //y축으로 +가 되는 방향
        // transform.forward//z축으로 +가 되는 방향
        
        // transform.right = lookDir;
        // transform.up = lookDir;
        transform.forward = lookDir;
    }
    
    //3. 메서드를 통해서 position과 rotation을 제어할 수 있다.
    private void ControlByMethod()
    {   //Transform은 현재 값 기준으로 특정 값을 합산하는 방식으로 위치와 각도를 제어하는 메소드를 제공
        //Transform.Translate : 호출될 때마다 현재 위치에 파라미터만큼 합산한 위치로 Transform을 이동
        //transform.Translate(5 * Time.deltaTime, 0, 0);
        //transform.position = new Vector3(5,0,0);과 같은게 아니라
        //transform.position += new Vector3(5,0,0); 과 같다.
        
        //Transform.Rotate : 호출될 때마다 현재 각도에서 파라미터만큼 합산한 각도로 Transform을 회전
        // transform.Rotate(30,0,0);
        
        //axis를 파라미터로 받는 오버로드된 Rotate는 방향벡터로 axis를 받아 축으로 사용
        //방향 벡터이기 때문에 axis의 크기는 상관없음. 방향만 맞으면 됨.
        //transform.Rotate(new Vector3(1,1,1),30 * Time.deltaTime);
        
        //transform.LookAt : 기본적으로 transform.forward = 방향벡터 대입하는것과 같은 동작.
        //차이점은 transform.up의 방향도 어느정도 worldUp을 향하도록 보정
        //WorldUp을 생략할 경우, Vector3.up이 WorldUp이 됨.
        //transform.forward = lookTarget.position - transform.position;

        transform.LookAt(lookTarget, Vector3.up);
    }
}
