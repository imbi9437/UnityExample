using UnityEngine;
using UnityEngine.UI;

namespace _08.UGUITest
{
    public class ButtonCounter : MonoBehaviour
    {
        public Text text;

        private int count;

        public void CountUp()
        {
            Debug.Log("카운트 상승");
            count++;
            text.text = count.ToString();
        }
    }
}
