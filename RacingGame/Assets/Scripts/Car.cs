using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float xMin, xMax;
    [SerializeField] float padding = 1f;
    static float moveSpeed = 20f;
    [SerializeField] bool canShoot;

    public static float MoveSpeed 
    {
        get { return moveSpeed; }
    }

    void Start()
    {
        SetBoundaries();
    }

    void Update()
    {
        Move();
    }

    void Move() 
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float xPosition = Mathf.Clamp(transform.position.x + horizontalMovement, xMin, xMax);
        transform.position = new Vector3(xPosition, transform.position.y);
    }

    void SetBoundaries() 
    {
        Camera main = Camera.main;
        xMin = main.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = main.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;
    }
}
