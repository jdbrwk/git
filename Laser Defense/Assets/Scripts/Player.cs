using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    // configuratio parameters
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 200;
    [SerializeField] AudioClip playerDeathClip;
    [SerializeField] [Range(0,1)] float playerDeathClipVolume = 0.75f;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projetileFiringPeriod = 0.1f;
    [SerializeField] AudioClip playerProjectileClip;
    [SerializeField] [Range(0, 1)] float playerProjectileClipVolume = 0.5f;

    Coroutine firingCoroutine;

    float xMin;
    float yMin;
    float xMax;
    float yMax;


	// Use this for initialization
	void Start () {
        SetUpBoundaries();
	}



    // Update is called once per frame
    void Update () {
        Move();
        Fire();

	}

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))

        {
            // InstantiateFire();
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }

    }


    IEnumerator FireContinuously()
    {
        while (true)
        {
            InstantiateFire();
            yield return new WaitForSeconds(projetileFiringPeriod);
        }

    }


    private void InstantiateFire()
    {
        GameObject laser = Instantiate(
            laserPrefab, transform.position, Quaternion.identity)
            as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(playerProjectileClip, Camera.main.transform.position, playerProjectileClipVolume);
    }


    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX * moveSpeed, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY * moveSpeed, yMin, yMax);;

        transform.position = new Vector2(newXPos, newYPos);



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return;  }
        ProcessHit(damageDealer);
                                         
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(playerDeathClip, Camera.main.transform.position, playerDeathClipVolume);
        }
    }


    private void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }


}
