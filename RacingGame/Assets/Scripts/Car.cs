using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    static float moveSpeed = 20f;

    public static float MoveSpeed 
    {
        get { return moveSpeed; }
    }

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    void Move() 
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float xPosition = transform.position.x + horizontalMovement;
        transform.position = new Vector3(xPosition, transform.position.y);
    }
}
