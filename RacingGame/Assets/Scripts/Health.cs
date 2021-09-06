using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    TextMeshProUGUI healthElement;
    GameSession car;

    void Start()
    {
        healthElement = GetComponent<TextMeshProUGUI>();
        car = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        healthElement.text = car.Health.ToString();
    }
}
