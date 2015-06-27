using UnityEngine;
using System.Collections;

public class BeamMagnumBullet : Entity {

	public GameObject spark;
	public Rigidbody body;
	public float lifeTimer;
	public float lifeTime=8;
	public float damage=800;
	public GameObject launchSpark;

	private CapsuleCollider bulletCollider;
	private LineRenderer bulletBody;
	private float bulletLength;

	public void OnTriggerEnter(Collider _collider){

		if (_collider.CompareTag("AttackTarget") ){
			Debug.Log ("mega hit "+_collider.name);
			Entity ent=_collider.GetComponent<Entity>();
			if (ent.player.flag!=player.flag){
				Explode();
				ent.Hurt(damage);
			}
		}
		else if(_collider.name=="Terrain"){
			Explode();
		}
	}
	
	public void Explode(){
		if (spark!=null){
			Object sparkObj=Instantiate(spark,transform.position,transform.rotation);
			//sparkObj.transform.position=body.position;//transform.position;
		}
		Destroy(this.gameObject);
	}
	
	void Awake(){
		body=GetComponent<Rigidbody>();
		bulletCollider=this.GetComponent<CapsuleCollider>();
		bulletBody = this.GetComponentInChildren<LineRenderer>();
		bulletLength = 2;
		Vector3 pos = new Vector3(0,0,bulletLength);
		bulletBody.SetPosition(1,pos);

	}
	
	void Update(){
		if (bulletCollider.height < 5) {
			//bulletCollider.height = bulletCollider.height + 20*Time.deltaTime;
			bulletCollider.height = Mathf.Lerp(0.1f,5,lifeTimer/1);
		}

		if (bulletLength<50) {
			bulletLength = Mathf.Lerp(2,40,lifeTimer/1);
			//bulletLength = bulletLength +140*Time.deltaTime;
			Vector3 pos = new Vector3(0,0,bulletLength);
			bulletBody.SetPosition(1,pos);
		}
		transform.rotation=Quaternion.LookRotation(body.velocity);
		if (lifeTimer<lifeTime){
			lifeTimer+=Time.deltaTime;
		}
		else{
			Destroy(this.gameObject);
		}
	}
}
