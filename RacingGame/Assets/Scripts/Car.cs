using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Level level;

    [SerializeField] AudioClip deathSoundEffect;

    [SerializeField] GameObject explosionParticles;
    [SerializeField] float explosionDuration = 1f;

    GameSession gameSession;
    [SerializeField] float health = 50f;

    float xMin, xMax;
    [SerializeField] float padding = 1f;
    static float moveSpeed = 20f;

    public float Health => health;
    public static float MoveSpeed => moveSpeed;

    void Start()
    {
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>();
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

        if (health <= 0 && gameSession.Score < 100)
            Die();
    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(deathSoundEffect, Camera.main.transform.position);
        GameObject explosionVFX = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(explosionVFX, explosionDuration);
        Destroy(gameObject);
        level.LoadLose();
    }
}
