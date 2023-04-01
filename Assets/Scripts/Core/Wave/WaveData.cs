using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Wave
{
    [CreateAssetMenu(fileName = "Wave Data", menuName = "Create SO/Wave Data")]
    public class WaveData : ScriptableObject
    {
        [SerializeField] private int _waveNumber;
        [SerializeField] private float _duration;
        [SerializeField] private Enemy.Enemy[]  _enemiesToSpawn;
        
        public int WaveNumber => _waveNumber;
        public float Duration => _duration;
        public IReadOnlyList<Enemy.Enemy> EnemiesToSpawn => _enemiesToSpawn;
    }
}
