using Extension;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Menu
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField, Scene, Header("Level Scene")] private string _gameScene;

        public void OnClick()
        {
            SceneManager.LoadScene(_gameScene);
        }
    }
}
