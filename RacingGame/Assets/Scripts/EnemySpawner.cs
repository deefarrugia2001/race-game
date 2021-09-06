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
    }
}
