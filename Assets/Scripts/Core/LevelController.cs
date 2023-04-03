using System;
using System.Collections;
using System.Linq;
using Core.Wave;
using Unity.VisualScripting;
using UnityEngine;
using Utils;
using Utils.Singleton;

namespace Core
{
    public class LevelController : SingletonMonoBehaviour<LevelController>
    {
        [SerializeField] private WaveData[] _waves;
        [SerializeField] private Spawner _spawner;
        
        public ReactiveProperty<int> PlayerHealth = new();
        public ReactiveProperty<int> CurrentWaveIndex = new();
        public ReactiveProperty<int> Coins = new();

        public event Action OnWin; 
        public event Action OnLose; 

        public int WavesCount => _waves.Length;
        
        private void Start()
        {
            StartGame();
            PlayerHealth.ValueChanged += () =>
            {
                if (PlayerHealth.Value <= 0)
                {
                    StopAllCoroutines();
                    foreach (var enemy in _spawner.CurrentEnemies)
                    {
                        if (enemy != null)
                        {
                            Destroy(enemy.gameObject);
                        }
                    }
                    OnLose?.Invoke();
                }
            };
            
        }

        private void StartGame()
        {
            PlayerHealth.Value = 100;
            CurrentWaveIndex.Value = 0;
            Coins.Value = 100;
            StartNextWave();
        }

        private void StartNextWave()
        {
            int nextIndex;
            if (CurrentWaveIndex.Value == 0)
            {
                nextIndex = 1;
            }
            else
            {
                nextIndex = CurrentWaveIndex.Value + 1;
            }

            if (!_waves.Select(x => x.WaveNumber).Contains(nextIndex))
            {
                StartCoroutine(CheckWinningRoutine());
                return;
            }
            
            StartCoroutine(StartWave(_waves.FirstOrDefault(x => x.WaveNumber == nextIndex)));
        }

        private IEnumerator CheckWinningRoutine()
        {
            while (true)
            {
                if (_spawner.CurrentEnemies.Count == 0)
                {
                    break;
                }

                yield return new WaitForEndOfFrame();
            }
            
            OnWin?.Invoke();
        }
        
        private IEnumerator StartWave(WaveData wave)
        {
            CurrentWaveIndex.Value = wave.WaveNumber;
            StartCoroutine(StartWaveDurationCheck(wave.Duration));
            for (int i = 0; i < wave.EnemiesToSpawn.Count; i++)
            {
                _spawner.SpawnEnemy(wave.EnemiesToSpawn[i]);
                yield return new WaitForSeconds(1f);
            }
        }

        private IEnumerator StartWaveDurationCheck(float duration)
        {
            float currentTime = 0;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            
            StartNextWave();
        }
        
    }
}
