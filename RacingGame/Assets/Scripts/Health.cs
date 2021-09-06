using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    TextMeshProUGUI healthElement;
    Car car;

    void Start()
    {
        healthElement = GetComponent<TextMeshProUGUI>();
        car = FindObjectOfType<Car>();
    }

    void Update()
    {
        healthElement.text = car.Health.ToString();
    }
}
