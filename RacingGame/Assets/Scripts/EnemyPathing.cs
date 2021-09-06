using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Start()
    {
        waypoints = waveConfig.Waypoints;
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
