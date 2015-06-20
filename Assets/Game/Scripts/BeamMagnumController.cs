using UnityEngine;
using System.Collections;

public class BeamMagnumController : WeaponObject {

	public BeamMagnumBullet bulletPrefab;
	public float speed;
	public float fireInterval=1.0f;
	public MagnumLaunchSpark launchSpark;
	public HyperMegaCanon hyperMegaCanon;
	public bool charging;
	public float maxChargeTime=4f;
	public AudioSource chargingSE;
	public AudioSource chargedSE;
	private float fireToggle;
	private float chargeTimer;

	
	public override void Fire(){
		base.Fire();
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


	public override void FireButtonDown() {
		if (hyperMegaCanon.IsLaunching()) {
			return;
		}
		base.FireButtonDown();
		charging =true;
		chargeTimer = 0;
	}


	public override void FireButtonUp() {
		if (hyperMegaCanon.IsLaunching()) {
			return;
		}
		base.FireButtonUp();
		chargingSE.Stop();
		if (chargeTimer >= maxChargeTime) {
			HyperMegaCanonLaunch();
		}
		else {
			Fire();
		}

		charging =false;
		chargeTimer = 0;
	}
	
	protected override void Update(){
		base.Update();
		
		if (fireToggle<fireInterval){
			fireToggle+=Time.deltaTime;
		}
		else {
			if (charging && chargeTimer < maxChargeTime) {
				if (chargeTimer > 0.5) {
					if (!chargingSE.isPlaying) {
						chargingSE.Play();
					}

				}
				chargeTimer +=Time.deltaTime;
				if (chargeTimer >= maxChargeTime) {
					chargingSE.Stop();
					chargedSE.Play();
				}
			}
		}


		/*
		if (Input.GetKey(KeyCode.V)) {
			HyperMegaCanonLaunch();

		}
		*/
	}

	void HyperMegaCanonLaunch () {
		hyperMegaCanon.gameObject.SetActive(true);
		if (launchSpark!=null){
			launchSpark.PlayAnimation();
		}
		hyperMegaCanon.Launch();

	}
}
