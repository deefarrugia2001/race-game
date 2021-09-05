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
}
