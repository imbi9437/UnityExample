using System;
using UnityEngine;
using UnityEngine.UI;

namespace _08.UGUITest
{
    public class UIScriptingTest : MonoBehaviour
    {
        //유니티의 UI 구성 요소들도 Component이므로 Inspector등을 통해 참조를 하거나 객체를 찾는것이 가능.
        public Image image;
        public Text text;
        public InputField inputField;
        public Slider slider;
        public Dropdown dropdown;
        public Toggle toggle;
        public Button button;

        public Sprite changeImage;
        public string changeText;
        
        private void Start()
        {
            image.sprite = changeImage;
            image.color = Color.red;
            text.text = changeText;
            
            (inputField.placeholder as Text).text = "아무거나 입력하세요...";
            slider.value = 0.65f;

            dropdown.value = 3;
            toggle.isOn = true;
        }
    }
}
