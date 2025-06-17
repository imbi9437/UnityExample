using System;
using System.Collections;
using UnityEngine;

namespace _06.CoroutineTest
{
    public class CoroutineStartStop : MonoBehaviour
    {
        private Coroutine loopCoroutine;

        public CoroutineTarget target;
        
        public bool breakKey;
        public bool yieldBreakKey;
        public bool stopCoroutineKey;
        private IEnumerator Start()
        {
            //Start 메시지 함수는 반환형이 IEnumerator면 유니티가 자동으로 코루틴으로 만들어줌.
            
            loopCoroutine = StartCoroutine(LoopCoroutine());
            
            //코루틴의 소유 객체는 반드시 내 스크립트가 아니어도 됨
            target.StartCoroutine(LoopCoroutine());

            while (true)
            {
                yield return new WaitForSeconds(1);
                Debug.Log("Start도 무한반복 중");
            }
        }

        private void Update()
        {
            //3. 코루틴 객체를 보관했다가 StopCoroutine을 호출하면서 파라미터로 넘김
            if (stopCoroutineKey && loopCoroutine != null)
            {
                StopCoroutine(loopCoroutine);
                loopCoroutine = null;
                Debug.Log("StopCoroutine을 통해 코루틴 종료");
            }
        }

        private void OnDisable()
        {
            //4. 객체를 비활성화 시키면 자동으로 코루틴이 종료됨.
            Debug.Log($"비활성화 되면서 {name}이 가진 모든 코루틴이 종료");
        }

        private IEnumerator LoopCoroutine()
        {
            while (true)
            {
                // 1. 코루틴의 루프를 끝내고 빠져나감
                // 루프를 끈태고 while문 밖의 "무한 반복 끝"을 출력
                if (breakKey) break;
                
                //2. 코루틴의 다음 yield를 끊음
                //코루틴의 다음 yield를 끊음으로써 코루틴을 종료. 즉, "무한 반복 끝"이 출력되지 않음.
                if (yieldBreakKey) yield break;
            
                yield return new WaitForSeconds(1);
                Debug.Log("무한 반복중");
            }
            
            Debug.Log("무한 반복 끝");
        }
    }
}
