#region Reference
// Attached to Manager
#endregion
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        #region MadeFunctions
        //Pause Game
        public void PauseGame()
        {
            Time.timeScale = 0;
        }
        // Resume Game
        public void ResumeGame()
        {
            Time.timeScale = 1;
        }
        //Exit Game
        public void ExitGame()
        {
            Application.Quit();
        }
        //Restart Game
        public void RestartGame()
        {
            ResumeGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        #endregion
    }
}