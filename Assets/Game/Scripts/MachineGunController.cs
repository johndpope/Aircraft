using UnityEngine;
using System.Collections;

public class MachineGunController : WeaponObject {

	public Bullet bulletPrefab;
	public float speed;
	public float fireInterval=0.02f;
	private float fireToggle;

	public void Fire(){
		if (fireToggle<fireInterval){
			return;
		}
		fireToggle-=fireInterval;
		if (bulletPrefab!=null){
			Bullet bullet=Instantiate(bulletPrefab);
//			missile.transform.rotation=transform.rotation;
			bullet.transform.position=bulletTransform.position+new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0);

			bullet.player=owner.player;
			bullet.transform.rotation=bulletTransform.rotation;


			bullet.GetComponent<Rigidbody>().velocity=bulletTransform.forward* speed;

			this.GetComponent<AudioSource>().Play();
		}
	}
	
	protected override void Update(){
		base.Update();

		if (fireToggle<fireInterval){
			fireToggle+=Time.deltaTime;
		}



		if (Input.GetKey(KeyCode.Z)){
			Fire ();
		}
	}
}
