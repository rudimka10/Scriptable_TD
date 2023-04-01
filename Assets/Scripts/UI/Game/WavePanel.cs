using Core;
using TMPro;
using UnityEngine;

namespace UI.Game
{
    public class WavePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _valueText;
        
        private void OnEnable()
        {
            LevelController.Instance.CurrentWaveIndex.ValueChanged += UpdateContent;
            UpdateContent();
        }

        private void UpdateContent()
        {
            _valueText.text = $"Wave {LevelController.Instance.CurrentWaveIndex}/{LevelController.Instance.WavesCount}";
        }
        
    }
}
