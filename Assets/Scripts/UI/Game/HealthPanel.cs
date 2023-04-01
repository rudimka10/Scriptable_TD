using Core;
using TMPro;
using UnityEngine;

namespace UI.Game
{
    public class HealthPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _valueText;

        private void OnEnable()
        {
            LevelController.Instance.PlayerHealth.ValueChanged += UpdateContent;
            UpdateContent();
        }

        private void UpdateContent()
        {
            _valueText.text = LevelController.Instance.PlayerHealth.ToString();
        }
    }
}
