using UnityEngine;
using System.Collections;

public class MicroMissilePod : Entity {

	public GameObject[] missileTransforms;
	public MicroMissile microMissile;
	public float damage=500;
	public float launchDuration=5;
	public float launchDelay=0.1f;
	public float microMissileSpeed=40;
	public float minMissileSpeed=20;
	public float maxMissileSpeed=50;

	public float moveSpeed=100;
	public float launchingMoveSpeed=40;

	public float maxMoveTime=10;
	public float maxSelfDestroyingTime=10;

	public GameObject fireBall;

	public MicroMissilePodController microMissilePodController;

	private float launchTimer;
	private float launchDelayTimer;
	private float moveTimer;
	private float selfDestoryingTimer;
	private float minPosX=-1.3f;
	private float maxPosX=1.3f;
	private float minPosY=-0.3f;
	private float maxPosY=0.3f;
	private float maxRotation=80;
	private bool missileLaunching=false;
	private bool selfDestroying=false;

	// Use this for initialization
	void Start () {
		launchTimer=0;
		launchDelayTimer=0;

		this.GetComponent<Rigidbody>().velocity=this.transform.forward*moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.B) && moveTimer > 0.5){

			StartLaunchMissile();
		}

		if (!missileLaunching && !selfDestroying) {
			if (moveTimer < maxMoveTime) {
				moveTimer+=Time.deltaTime;
			}
			else {
				StartLaunchMissile();
			}
		}

		if (missileLaunching) {
			if (launchDelayTimer > launchDelay) {
				LaunchMicroMissile();
				launchDelayTimer=0;
			}
			else {
				launchDelayTimer+=Time.deltaTime;
			}

			if (launchTimer < launchDuration) {
				launchTimer += Time.deltaTime;
			}
			else {
				missileLaunching=false;
				selfDestroying=true;
				launchTimer=0;
				launchDelayTimer=0;

				this.GetComponent<Rigidbody>().useGravity=true;

				microMissilePodController.Reload();
			}
		}

		if (selfDestroying) {
			if (selfDestoryingTimer < maxSelfDestroyingTime) {
				selfDestoryingTimer+=Time.deltaTime;

				if (this.transform.position.y < 0 && selfDestoryingTimer>0.5) {
					Explode();
				}
			}
			else {

				Explode();
			}
		}
	}

	void StartLaunchMissile () {
		if (!missileLaunching && !selfDestroying) {
			missileLaunching=true;

			this.GetComponent<Rigidbody>().velocity=this.transform.forward*launchingMoveSpeed;
		}
	}

	void LaunchMicroMissile () {


		foreach (GameObject transformPart in missileTransforms) {
			float posX = Random.Range(minPosX,maxPosX);
			float posY = Random.Range(minPosY,maxPosY);

			transformPart.transform.localPosition=new Vector3(posX,posY,0);
			transformPart.transform.localRotation=Quaternion.Euler(-(posY/maxPosY)*maxRotation,posX/maxPosX*maxRotation,0);

			MicroMissile missile = (MicroMissile)Instantiate(microMissile,transformPart.transform.position,transformPart.transform.rotation);

			missile.player=player;
			microMissileSpeed=Random.Range(minMissileSpeed,maxMissileSpeed);
			missile.GetComponent<Rigidbody>().velocity=missile.transform.forward* microMissileSpeed;
		}


	}

	void Explode () {
		if (fireBall!=null){
			Object fireball = Instantiate(fireBall,this.transform.position,Quaternion.Euler(0,0,0));
		}
		Destroy(this.gameObject);
	}

	public void OnTriggerEnter(Collider _collider){
		if (selfDestroying) {

			if (_collider.CompareTag("AttackTarget") ){
				Entity ent=_collider.GetComponent<Entity>();
				if (ent.player.flag!=player.flag){
					Explode();
					ent.Hurt(damage);
				}
			}
			else{
				Explode();
			}
		}

	}
}
