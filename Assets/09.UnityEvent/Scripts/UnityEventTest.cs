using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace _09.UnityEventTest
{
    public class UnityEventTest : MonoBehaviour
    {
        public List<UnityEvent> someEvents;
        public UnityEvent<string> stringEvent;
        IEnumerator<UnityEvent> eventEnums;
        
        private void Start()
        {
            eventEnums = someEvents.GetEnumerator();
        }

        private void Update()
        {
            //F키를 누를때마다 someEvents의 이벤트를 하나씩 수행하고자 한다.
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("F Key Pressed");
                if (eventEnums.MoveNext())
                    eventEnums.Current?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                stringEvent?.Invoke("안녕");
            }
        }

        public void PrintText()
        {
            Debug.Log("Hello");
        }

        public void PrintText(string message)
        {
            Debug.Log(message);
        }
    }
}
