using UnityEngine;
using System.Collections;

public class HyperMegaCanon : Entity {


	public float lifeTimer;
	public float lifeTime=4;
	public float damagePerHit=100;
	public GameObject bodyParticleObj;
	public GameObject headParticleObj;
	public AudioSource launchAudio;

	public CameraFollower cameraFollower;
	
	private CapsuleCollider bulletCollider;
	private LineRenderer bulletBody;
	private float bulletLength;
	private float bulletTargetLength;
	private float raiseTime;
	private Vector3 bulletColliderPos;

	private ParticleSystem bodyParticle;
	private ParticleSystem headParticle;
	private float disapperTimer;
	private float disapperTime=0.4f;
	private bool disappering=false;
	private bool launching=false;
	private float beamBodyWidth;
	private float beamBodyCurrentWidth;
	private Light beamLight;

//	public ParticleSystem spark;
	
	public void OnTriggerStay(Collider _collider){
//		spark.transform.position=_collider.transform.position;

		if (_collider.CompareTag("AttackTarget") ){
			//Debug.Log ("mega hit "+_collider.name);
			Entity ent=_collider.GetComponent<Entity>();
			if (ent.player.flag!=player.flag){
				ent.Hurt(damagePerHit);
			}
		}


	}

	
	void Awake(){

		bulletCollider=this.GetComponent<CapsuleCollider>();
		bulletBody = this.GetComponentInChildren<LineRenderer>();
		bodyParticle = bodyParticleObj.GetComponent<ParticleSystem>();
		headParticle = headParticleObj.GetComponent<ParticleSystem>();
		beamLight = this.GetComponentInChildren<Light>();
		bulletTargetLength = 1000;
		bulletLength = 1;
		raiseTime = 2.5f;
		beamBodyWidth = 20;


		Reset();
	}
	
	void Update(){
		if (launching) {

			if (lifeTimer<lifeTime){
				lifeTimer+=Time.deltaTime;

				if (bulletCollider.height < bulletTargetLength) {
					bulletCollider.height = bulletCollider.height + (bulletTargetLength/raiseTime)*Time.deltaTime;
				}
				if (bulletLength<bulletTargetLength) {
					bulletLength = bulletLength + (bulletTargetLength/raiseTime)*Time.deltaTime;
					Vector3 pos = new Vector3(0,0,bulletLength);
					bulletBody.SetPosition(1,pos);
				}
				if (bulletColliderPos.z < bulletTargetLength/2) {
					bulletColliderPos = bulletColliderPos + new Vector3(0,0,(bulletTargetLength/2/raiseTime)*Time.deltaTime);
					bulletCollider.center = bulletColliderPos;
				}
			}
			else if (disapperTimer<disapperTime){
				disapperTimer+=Time.deltaTime;
				if (!disappering) {
					Disapper();
				}
				if (beamBodyCurrentWidth>0) {
					beamBodyCurrentWidth -= (beamBodyWidth/disapperTime)*Time.deltaTime;
					bulletBody.SetWidth(beamBodyCurrentWidth,beamBodyCurrentWidth);
				}
			}
			else {
				cameraFollower.ChangeCameraMode(false);
				Reset();
			}



		}

	}

	// Use this for initialization
	void Start () {
	
	}

	void Disapper (){
		bodyParticle.enableEmission = false;
		headParticle.enableEmission = false;
		bodyParticle.gameObject.SetActive(false);
		beamLight.gameObject.SetActive(false);
	}

	void Reset () {
		launching = false;
		disappering = false;
		lifeTimer=0;
		disapperTimer=0;
		bulletColliderPos = new Vector3(0,0,0);
		bulletCollider.height = 0;
		bulletCollider.center = bulletColliderPos;
		
		bulletLength = 1;
		Vector3 pos = new Vector3(0,0,bulletLength);
		bulletBody.SetPosition(1,pos);
		beamBodyCurrentWidth = beamBodyWidth;
		bulletBody.SetWidth(beamBodyCurrentWidth,beamBodyCurrentWidth);

		bodyParticle.enableEmission = false;
		headParticle.enableEmission = false;

		bulletBody.gameObject.SetActive(false);
		//this.gameObject.SetActive(false);


		bulletCollider.enabled=false;
	}

	public void Launch () {
		if (!launching) {
			this.gameObject.SetActive(true);
			bulletBody.gameObject.SetActive(true);
			bodyParticle.gameObject.SetActive(true);
			headParticle.gameObject.SetActive(true);
			beamLight.gameObject.SetActive(true);
			bulletCollider.enabled=true;
			launching = true;
			bodyParticle.enableEmission=true;
			headParticle.enableEmission=true;
			launchAudio.Play();

			cameraFollower.ChangeCameraMode(true);
		}

	}

	public bool IsLaunching () {
		return launching;
	}

}
