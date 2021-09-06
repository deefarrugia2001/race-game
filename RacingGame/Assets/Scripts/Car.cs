using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float health = 50f;

    float xMin, xMax;
    [SerializeField] float padding = 1f;
    static float moveSpeed = 20f;

    public float Health => health;
    public static float MoveSpeed => moveSpeed;

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (!damageDealer)
            return;
        
        ProcessHit(damageDealer);
    }

    void ProcessHit(DamageDealer damageDealer) 
    {
        health -= damageDealer.Damage;
        damageDealer.Hit();
    }
}
