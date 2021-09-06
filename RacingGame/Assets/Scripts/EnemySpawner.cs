using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    bool looping = true;
    byte startingIndex = 0;

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
        for(byte index = startingIndex; index < waveConfig.Quantity; index++) 
        {
            GameObject obstacle = Instantiate(waveConfig.Obstacle, waveConfig.Waypoints[0].position, Quaternion.identity);
            obstacle.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.MoveSpeed);
        }
    }
}
