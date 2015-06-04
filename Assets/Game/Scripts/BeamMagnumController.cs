using UnityEngine;
using System.Collections;

public class BeamMagnumController : WeaponObject {

	public BeamMagnumBullet bulletPrefab;
	public float speed;
	public float fireInterval=1.0f;
	private float fireToggle;
	
	public void Fire(){
		if (fireToggle<fireInterval){
			return;
		}
		fireToggle-=fireInterval;
		if (bulletPrefab!=null){
			BeamMagnumBullet bullet=Instantiate(bulletPrefab);
			//			missile.transform.rotation=transform.rotation;
			bullet.transform.position=bulletTransform.position+new Vector3(0,0,0);
			
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
		
		
		
		if (Input.GetKey(KeyCode.X)){
			Fire ();

			
		}
		else {

		}
	}
}
