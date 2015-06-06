using UnityEngine;
using System.Collections;

public class HyperMegaCanon : Entity {


	public float lifeTimer;
	public float lifeTime=4;
	public float damagePerHit=100;
	public GameObject bodyParticleObj;
	public GameObject headParticleObj;
	public AudioSource launchAudio;
	
	private CapsuleCollider bulletCollider;
	private LineRenderer bulletBody;
	private float bulletLength;
	private float bulletTargetLength;
	private float raiseTime;
	private Vector3 bulletColliderPos;

	private ParticleSystem bodyParticle;
	private ParticleSystem headParticle;
	private float disapperTimer;
	private float disapperTime=1;
	private bool launching=false;
	
	public void OnTriggerEnter(Collider _collider){
		
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
		bulletTargetLength = 1000;
		bulletLength = 1;
		raiseTime = 2.5f;


		Reset();
	}
	
	void Update(){
		if (launching) {
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
			

			if (lifeTimer<lifeTime){
				lifeTimer+=Time.deltaTime;
			}
			else{
				Reset();
			}
		}

	}

	// Use this for initialization
	void Start () {
	
	}

	void Reset () {
		launching = false;
		lifeTimer=0;
		bulletColliderPos = new Vector3(0,0,0);
		bulletCollider.height = 0;
		bulletCollider.center = bulletColliderPos;
		
		bulletLength = 1;
		Vector3 pos = new Vector3(0,0,bulletLength);
		bulletBody.SetPosition(1,pos);

		bodyParticle.enableEmission = false;
		headParticle.enableEmission = false;

		this.gameObject.SetActive(false);
	}

	public void Launch () {
		if (!launching) {
			this.gameObject.SetActive(true);
			launching = true;
			bodyParticle.enableEmission=true;
			headParticle.enableEmission=true;
			launchAudio.Play();
		}

	}

}
