using System;
using System.Collections;
using UnityEngine;

namespace _06.CoroutineTest
{
    public class CoroutineTest : MonoBehaviour
    {
        //코루틴(Coroutine) : 메인 루틴을 보조하는 서브루틴이라는 의미.
        //프로그래밍에서는 메인 프로세스와 비동기적으로 동작하는 보조 프로세스를 의미(스레드)
        //비동기 프로그래밍 : 특정 프로세스의 완료 여부와 상관 없이 별도로 진행되는 프로세스를 프로그래밍.

        #region 비동기 프로그래밍을 Update로 수행해본 예시
        
        //어떤 행동을 interval간격으로 count횟수만큼 수행
        // public float interval;
        // public int count;
        //
        // private float lastTime = -10f;
        // private int currentCount = 0;
        // private bool isDone = false;
        //
        // private void Update()
        // {
        //     if (isDone) return;
        //     if (Time.time > lastTime + interval)
        //     {
        //         lastTime = Time.time;
        //         currentCount++;
        //         if (currentCount > count)
        //         {
        //             Debug.Log("수행 완료!");
        //             isDone = true;
        //         }
        //     }
        // }
        
        #endregion

        private MeshRenderer mr;

        public Material woodMaterial;
        public Material stoneMaterial;

        private float lastTime = -10f;
        private bool isDone = false;
        private void Awake()
        {
            mr = GetComponent<MeshRenderer>();
        }

        private void Start()
        {   //3초 후에 mr의 material을 wood material로 교체하고 싶다.
            lastTime = Time.time;

            // IEnumerator enumerator = SomEnumerator();
            // enumerator.MoveNext();
            // StartCoroutine(SomeCoroutine());
            IEnumerator someCoroutine = SomeCoroutine();
            StartCoroutine(someCoroutine);
            mr.sharedMaterial = stoneMaterial;
            //SomeCoroutine을 먼저 호출했다고 SomeCoroutine이 먼저 수행되는게 아님.
        }
        
        //유니티의 코루틴 : IEnumerator를 반환하는 함수를 만들고
        //그 안에서 yield return으로 YieldInstructor를 상속한 객체를 반환하는 방식으로 만들어 사용함.
        
        //기존에 IEnumerator 함수를 만들 때
        private IEnumerator SomeCoroutine()
        {
            Debug.Log("Coroutine Start!");
            //앞의 프로세스가 어떻게 되건 3초를 기다린 후에 밑이 수행됨
            yield return new WaitForSeconds(3f);
            Debug.Log("Coroutine End!");
            mr.sharedMaterial = woodMaterial;
        }

        private void Update()
        {
            // if (isDone) return;
            // if (Time.time < lastTime + 3f) return;
            // isDone = true;
            // lastTime = Time.time;
            // mr.material = woodMaterial;
        }
    }
}