using Core;
using TMPro;
using UnityEngine;

namespace UI.Game
{
    public class CoinsPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _valueText;

        private void OnEnable()
        {
            LevelController.Instance.Coins.ValueChanged += UpdateContent;
            UpdateContent();
        }

        private void UpdateContent()
        {
            _valueText.text = LevelController.Instance.Coins.ToString();
        }
    }
}
