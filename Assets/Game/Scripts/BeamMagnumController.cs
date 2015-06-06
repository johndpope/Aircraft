using UnityEngine;
using System.Collections;

public class BeamMagnumController : WeaponObject {

	public BeamMagnumBullet bulletPrefab;
	public float speed;
	public float fireInterval=1.0f;
	public MagnumLaunchSpark launchSpark;
	public HyperMegaCanon hyperMegaCanon;
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
		if (launchSpark!=null){
			launchSpark.PlayAnimation();
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

		if (Input.GetKey(KeyCode.V)) {
			hyperMegaCanon.gameObject.SetActive(true);
			hyperMegaCanon.Launch();
		}
	}
}
