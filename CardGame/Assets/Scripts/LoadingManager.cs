#region
// Add to Manager in Loading Scene.
#endregion
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LoadingManager : MonoBehaviour
    {
        #region Variables
        //public

        public TMP_Text loadingText;
        public Slider loadingBar;
        #endregion

        #region UnityFunction

        //Make dummy Loading Effect.
        IEnumerator Start()
        {
            loadingText.text = "Loading.";
            loadingBar.value = .3f;
            yield return new WaitForSeconds(1f);
            loadingText.text = "Loading...";
            loadingBar.value = .6f;
            yield return new WaitForSeconds(2f);
            loadingText.text = "Loading....";
            loadingBar.value = 1f;
            yield return new WaitForSeconds(1f);
            LoadNextScene();

        }
        #endregion

        #region MadeFunction
        //load Next Scene
        public void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        #endregion
    }
}