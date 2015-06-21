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

	public ParticleSystem chargeEnergyBall;
	public ParticleSystem chargeEnergyParticle;
	public ParticleSystem chargeFinishRing;
	public Light chargeEnergyLight;




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
		chargeEnergyBall.enableEmission=false;
		chargeEnergyParticle.enableEmission=false;
		chargeFinishRing.enableEmission=false;
		chargeEnergyLight.enabled=false;
		if (chargeTimer >= maxChargeTime) {
			HyperMegaCanonLaunch();
		}
		else {
			Fire();
		}

		charging =false;
		chargeTimer = 0;

		weaponName="Hyper Mega Launcher";
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
						chargeEnergyBall.enableEmission=true;
						chargeEnergyParticle.enableEmission=true;
						chargeEnergyLight.enabled=true;
						chargingSE.Play();
					}

				}
				chargeEnergyBall.startSize = Mathf.Lerp(1,6,chargeTimer/maxChargeTime);
				chargeEnergyLight.intensity = Mathf.Lerp(0,0.5f,chargeTimer/maxChargeTime);
				chargeTimer +=TimerController.realDeltaTime;
				if (chargeTimer >= maxChargeTime) {
					weaponName="Hyper Mega Canon";
					chargeFinishRing.enableEmission=true;
					chargeFinishRing.Emit(1);
					chargeEnergyParticle.enableEmission=false;
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
		if (voiceClip!=null){
			AudioManager.Instance().PlaySFX(voiceClip);
		}
		hyperMegaCanon.gameObject.SetActive(true);
		if (launchSpark!=null){
			launchSpark.PlayAnimation();
		}
		hyperMegaCanon.Launch();

	}
}
