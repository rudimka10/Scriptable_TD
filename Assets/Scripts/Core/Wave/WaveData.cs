using UnityEngine;

namespace Wave
{
    [CreateAssetMenu(fileName = "Wave Data", menuName = "Create SO/Wave Data")]
    public class WaveData : ScriptableObject
    {
        [SerializeField] private int _waveNumber;
        [SerializeField] private float _duration;

        public int WaveNumber => _waveNumber;
        public float Duration => _duration;
    }
}
