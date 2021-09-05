using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WaveConfig")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] byte quantity;
    [SerializeField] float moveSpeed;

    public GameObject Obstacle => obstacle;

    public List<Transform> Waypoints 
    {
        get 
        {
            List<Transform> waypoints = new List<Transform>();
            foreach (Transform child in pathPrefab.transform)
                waypoints.Add(child);
            return waypoints;
        }
    }

    public float TimeBetweenSpawns => timeBetweenSpawns;
    public byte Quantity => quantity;
    public float MoveSpeed => moveSpeed;
}
