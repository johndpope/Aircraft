using UnityEngine;
using System.Collections;

public class BeamMagnumBullet : Entity {

	public GameObject spark;
	public Rigidbody body;
	public float lifeTimer;
	public float lifeTime=6;
	public float damage=800;

	private CapsuleCollider bulletCollider;
	private LineRenderer bulletBody;
	private float bulletLength;

	public void OnTriggerEnter(Collider _collider){
		Debug.Log ("mega hit "+_collider.name);
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
	
	public void Explode(){
		if (spark!=null){
			GameObject sparkObj=Instantiate(spark);
			sparkObj.transform.position=body.position;//transform.position;
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
		if (bulletCollider.height < 7) {
			bulletCollider.height = bulletCollider.height + 20*Time.deltaTime;
		}
		if (bulletLength<24) {
			bulletLength = bulletLength +40*Time.deltaTime;
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
