using UnityEngine;

namespace _08.UGUITest
{
    public class UIInteractionTest : MonoBehaviour
    {
        //유니티의 UI들은 기본적으로 상호작용에 대한 UnityEvent를 가지고 있음.
        
        //어떤 스크립트(MonoBehaviour)든 외부에서 멤버 함수를 참조해서 호출해 줄 수 있음.
        int[] array = new int[10];
        public void OnButtonClick()
        {
            Debug.Log("버튼이 클릭됨");
        }

        public void OnButtonClick(int value)
        {
            Debug.Log($"버튼 클릭됨 : {value}");
        }
        
        private void PrivateMethod()
        {
            Debug.Log("이건 프라이빗 메소드 입니다.");
        }

        public void OnValueChanged(bool isOn)
        {
            string text = isOn ? "켜짐" : "꺼짐";
            Debug.Log($"토글이 {text}");
        }

        public void OnValueChange(int value)
        {
            Debug.Log($"해당 번호는 {value} 저장된 단어는 {array[value]}");
        }
    }
}