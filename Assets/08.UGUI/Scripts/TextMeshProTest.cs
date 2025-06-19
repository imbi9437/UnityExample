using TMPro;
using UnityEngine;

namespace _08.UGUITest
{
    public class TextMeshProTest : MonoBehaviour
    {
        public TextMeshProUGUI textMeshPro;
        public TMP_Dropdown dropdown;
        public TMP_InputField inputField;
        public TMP_Text text;
        
        
        private void Start()
        {
            textMeshPro.text = "안녕하세요.";
        }
    }
}
