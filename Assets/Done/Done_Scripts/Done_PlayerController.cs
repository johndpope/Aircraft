using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
	private Rigidbody body;

	void Awake(){
		body=GetComponent<Rigidbody>();
	}

	void Update ()
	{
		if (Input.GetButton("Jump") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		body.velocity = movement * speed;
		
//		body.position = new Vector3
//		(
//			Mathf.Clamp (body.position.x, boundary.xMin, boundary.xMax), 
//			0.0f, 
//			Mathf.Clamp (body.position.z, boundary.zMin, boundary.zMax)
//		);
//		
//		body.rotation = Quaternion.Euler (0.0f, 0.0f, body.velocity.x * -tilt);
	}
}
