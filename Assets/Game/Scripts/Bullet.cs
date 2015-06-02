using UnityEngine;
using System.Collections;

public class Bullet : Entity {

	public GameObject spark;
	public Rigidbody body;
	public float lifeTimer;
	public float lifeTime=1;
	public float damage=10;

	public void OnCollisionEnter(Collision _collision){
		Debug.Log ("hit "+_collision.collider.name);
		if (_collision.collider.CompareTag("AttackTarget") ){
			Entity ent=_collision.collider.GetComponent<Entity>();
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
			sparkObj.transform.position=transform.position;
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
