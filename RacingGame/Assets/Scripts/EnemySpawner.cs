using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    List<WaveConfig> waveConfigs;
    bool looping = true;

    IEnumerator Start()
    {
        do
            yield return StartCoroutine(SpawnAllWaves());
        while (looping);
    }

    IEnumerator SpawnAllWaves() 
    {
        foreach (WaveConfig waveConfig in waveConfigs)
            yield return StartCoroutine(SpawnAllEnemiesInWave(waveConfig));
    }

    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig) 
    {
    }
}
