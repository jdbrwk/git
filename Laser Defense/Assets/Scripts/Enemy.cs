using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 1.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] float enemyProjectileSpeed = 5f;

    [SerializeField] GameObject explosionVFXPrefab;
    [SerializeField] float durationOfExplosion = 1f;

    [SerializeField] AudioClip deathClip;
    [SerializeField] [Range(0, 1)] float deathClipVolume = 1f;

    [SerializeField] AudioClip enemyShootingClip;
    [SerializeField] [Range(0, 1)] float enemyShootingClipVolume = 1f;



	// Use this for initialization
	void Start () {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
	}
	
	// Update is called once per frame
	void Update () {
        CountDownAndShoot();


	}

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            EnemyFire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void EnemyFire()
    {
        GameObject laser = Instantiate(
            enemyLaserPrefab, transform.position, Quaternion.identity)
            as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyProjectileSpeed);
        AudioSource.PlayClipAtPoint(enemyShootingClip, Camera.main.transform.position, enemyShootingClipVolume);
    }

    private void ExplosionVFX()
    {
        GameObject explosion = Instantiate(
            explosionVFXPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, durationOfExplosion);
        
    }

    private void PlayDeathSFX()
    {
        AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, deathClipVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Destroy(gameObject);
            ExplosionVFX();
            PlayDeathSFX();
        }
    }

}
