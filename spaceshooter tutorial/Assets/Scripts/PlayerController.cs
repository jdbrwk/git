using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
	{
		public float xMin, xMax, zMin, zMax;
	}

public class PlayerController : MonoBehaviour 
	{

	public Rigidbody rb;
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 0.5f;
    public SimpleTouchPad touchPad;
    public SimpleTouchAreaButton areaButton;

	private float nextFire = 0.0f;
    private AudioSource audioSource;
    private Quaternion calibrationQuaternion;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CalibrateAccellerometer();
    }

    void Update ()
	{
        if (areaButton.CanFire () && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
		
		//GameObject clone = 
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
            audioSource.Play();
		}
	}


    void CalibrateAccellerometer()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    Vector3 FixAcceleration(Vector3 acceleration) 
        {
            Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
            return fixedAcceleration;
        }


	void FixedUpdate ()
	{
        //		float moveHorizontal = Input.GetAxis ("Horizontal");
        //		float moveVertical = Input.GetAxis ("Vertical");
        //      Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //      Vector3 accelerationRaw = Input.acceleration;
        //      Vector3 acceleration = FixAcceleration(accelerationRaw);
        //      Vector3 movement = new Vector3 (acceleration.x, 0.0f, acceleration.y);

        Vector2 direction = touchPad.GetDirection();
        Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);

        rb.velocity = movement * speed;

		rb.position = new Vector3 
		(
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
		
	}

 
}
