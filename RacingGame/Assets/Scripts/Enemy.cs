using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] AudioClip deathSoundEffect;

    [SerializeField] GameObject explosionParticles;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] bool canShoot;
    [SerializeField] float minimumShootTime = .2f, maximumShootTime = 3f;
    [SerializeField] float projectileSpeed = 20f;
    float shotCounter;

    void Start()
    {
        shotCounter = Random.Range(minimumShootTime, maximumShootTime);
    }

    void Update()
    {
        if (canShoot)
            CountDownAndShoot();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessHit();
    }

    void ProcessHit() 
    {
        Die();
    }

    void Die() 
    {
        //Debug.Log("The enemy has died.");
        //GameObject explosionVFX = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        //Destroy(explosionVFX, 1f);
        Destroy(gameObject);
    }

    void CountDownAndShoot() 
    {
        shotCounter -= Time.deltaTime;
        
        if(shotCounter <= 0) 
        {
            Fire();
            shotCounter = Random.Range(minimumShootTime, maximumShootTime);
        }
    }

    void Fire() 
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }
}
