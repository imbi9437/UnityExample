using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _06.CoroutineTest
{
    public class CoroutineSamples : MonoBehaviour
    {
        private bool printKey;
        
        private void Start()
        {
            // StartCoroutine("ReturnNull"); //이름이 같은 IEnumerator를 반환하는 함수를 찾아 코루틴으로 호출
            // StartCoroutine(ReturnNull());
            // StartCoroutine(ReturnWaitForSeconds(1f, 5));
            // StartCoroutine("ReturnWaitForSecondsRealTime", 1);
            // StartCoroutine(ReturnWaitForSecondsRealTime(1f));
            //StartCoroutine(ReturnWaitUntilWhile());
            // StartCoroutine(ReturnWaitForEndOfFrame());
            // StartCoroutine(ReturnWaitForFixedUpdate());
            StartCoroutine(_1st());
        }

        private void FixedUpdate()
        {
            // if (printKey == false)
            // {
            //     Debug.Log("Fixed Update 호출");
            //     printKey = true;
            // }
        }

        //1. yield return null : 바로 한 프레임 뒤에 다음 yield return을 반환.
        IEnumerator ReturnNull()
        {
            Debug.Log("Return Null 코루틴 시작");
            while (true)
            {
                yield return null;
                Debug.Log($"Return Null 코루틴 호출 : {Time.time}");
            }
        }

        //2. yield return new WaitForSeconds(float time) : 코루틴이 yield return에서 newe WaitForSeconds()를 만나면 time만큼 대기 후 수행
        IEnumerator ReturnWaitForSeconds(float interval, int count)
        {
            //같은 interval로 WaitForSeconds 객체를 생성하는게 확정되어 있다면 1개만 생성해서 재활용 할 수 있다.
            WaitForSeconds wait = new WaitForSeconds(interval);
            Debug.Log("Return Wait For Seconds 코루틴 시작");
            for (int i = 0; i < count; i++)
            {
                yield return wait; //WaitForSeconds 객체가 3번 생성된다.
                Debug.Log($"Wait For Seconds가 {i + 1}번 호출됨");
            }

            Debug.Log("Return Wait For Seconds 코루틴 끝");
        }

        //3. WaitForSecondsRealTime(float time) : WaitForSeconds와 같은데 TimeScale에 영향받지 않음.
        private string[] words = { "멍개", "해삼", "말미잘", "개불", "연어" };

        IEnumerator ReturnWaitForSecondsRealTime(float interval)
        {
            Debug.Log("RealTime 코루틴 시작, Time Scale : 0.5");
            Time.timeScale = 0.5f;
            WaitForSecondsRealtime wait = new WaitForSecondsRealtime(interval);
            foreach (string word in words)
            {
                Debug.Log($"{word}, Time : {Time.time}, RealTime : {Time.unscaledTime}");
                yield return wait;
            }

            Debug.Log("RealTime 코루틴 끝.");
            Time.timeScale = 1f;
        }

        public bool isContinue;
        private bool IsContinue() => isContinue;

        //4. WaitUntil, WaitWhile (delegate) 특정 조건이 true / false가 될때까지 대기
        IEnumerator ReturnWaitUntilWhile()
        {
            Debug.Log("Until / While 코루틴 시작");
            WaitUntil waitUntil = new WaitUntil(IsContinue);
            WaitWhile waitWhile = new WaitWhile(() => isContinue);
            while (true)
            {
                yield return waitUntil;
                Debug.Log("컨티뉴 키가 참이 됨");
                yield return waitWhile;
                Debug.Log("컨티뉴 키가 거짓이 됨");
            }
        }

        // 5. Update타임과 동기화 된 YieldInstruction :
        // a-Update와 동기화 된 타이밍 : yield return null;
        // b-FixedUpdate와 동기화 된 타이밍 : yield return new WaitForFixedUpdate();
        // c-프레임의 맨 마지막 ; yield return new WaitForEndOfFrame();

        IEnumerator ReturnWaitForFixedUpdate()
        {
            yield return new WaitForFixedUpdate();
            Debug.Log("WaitForFixedUpdate 코루틴 수행");
        }

        IEnumerator ReturnWaitForEndOfFrame()
        {   //렌더링까지 끝난 후 프레임의 맨 마지막에 수행
            yield return new WaitForEndOfFrame();
            Debug.Log("WaitForEndOfFrame 코루틴 수행");
        }
        
        //Yield return 코루틴 : 리턴으로 오는 코루틴이 끝날때까지 대기

        IEnumerator _1st()
        {
            Debug.Log("1번 코루틴 시작");
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.3f);
                Debug.Log($"1번 코루틴이 {i + 1}번 수행");
            }
            
            Debug.Log("1번 코루틴이 2번 코루틴을 시작하고 대기");
            yield return StartCoroutine(_2nd());
            
            Debug.Log("1번 코루틴 끝");
        }

        private Coroutine _3rdCo;
        
        IEnumerator _2nd()
        {
            Debug.Log("2번 코루틴 시작");
            Debug.Log("2번 코루틴이 3번 코루틴을 시작하고 대기");
            _3rdCo = StartCoroutine(_3rd());
            yield return _3rdCo;
            
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.3f);
                Debug.Log($"2번 코루틴이 {i + 1}번 수행");
            }
            Debug.Log("2번 코루틴 끝");
        }
        
        IEnumerator _3rd()
        {
            Debug.Log("3번 코루틴 시작");
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.3f);
                Debug.Log($"3번 코루틴이 {i + 1}번 수행");
            }
            
            Debug.Log("3번 코루틴 끝");
        }
    }
}