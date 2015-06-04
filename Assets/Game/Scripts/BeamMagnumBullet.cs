using UnityEngine;
using System.Collections;

public class BeamMagnumBullet : Entity {

	public GameObject spark;
	public Rigidbody body;
	public float lifeTimer;
	public float lifeTime=6;
	public float damage=800;

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
	}
	
	void Update(){
		transform.rotation=Quaternion.LookRotation(body.velocity);
		if (lifeTimer<lifeTime){
			lifeTimer+=Time.deltaTime;
		}
		else{
			Destroy(this.gameObject);
		}
	}
}
