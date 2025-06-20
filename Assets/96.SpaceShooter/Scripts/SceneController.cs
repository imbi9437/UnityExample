using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class SceneController : MonoBehaviour
    {
        public void LoadGameScene()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadStartScene()
        {
            Player.score = 0;
            SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}