using Core;
using Extension;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Game
{
    public class ResultPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _resultText;
        
        [SerializeField, Scene, Header("Menu Scene")] private string _gameScene;

        public void OnMenuClick()
        {
            SceneManager.LoadScene(_gameScene);
        }
        
        private void Awake()
        {
            LevelController.Instance.OnLose += () => OnGameFinished("Lose");
            LevelController.Instance.OnWin += () => OnGameFinished("Win");
            gameObject.SetActive(false);
        }

        private void OnGameFinished(string resultValue)
        {
            gameObject.SetActive(true);
            _resultText.text = resultValue;
        }
    }
}
