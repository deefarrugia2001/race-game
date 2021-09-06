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

    void Move()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float frameIndependentMovement = Time.deltaTime * waveConfig.MoveSpeed;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, frameIndependentMovement);

            if (transform.position == targetPosition)
                waypointIndex++;
        }
        else
            Destroy(gameObject);
    }

    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
