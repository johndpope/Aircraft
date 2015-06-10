using UnityEngine;
using System.Collections;

public class MicroMissile : Entity {
	public float lifeTime=1;
	public float maxLifeTime=2;
	public float minLifeTime=1f;
	public float disappearTime=0.5f;
	public GameObject missileBody;
	public GameObject missileFireBall;
	public float damage=100;

	private float lifeTimer;
	private bool exploded=false;
	// Use this for initialization
	void Start () {
		//lifeTime=Random.Range(minLifeTime,maxLifeTime);
	}
	
	// Update is called once per frame
	void Update () {

		if (lifeTimer < lifeTime){
			lifeTimer+=Time.deltaTime;
		}
		else {
			if (!exploded) {


				this.gameObject.GetComponent<Collider>().enabled=false;
				this.gameObject.GetComponent<Rigidbody>().Sleep();

				missileBody.GetComponent<MeshRenderer>().enabled=false;

				Explode();

			}
			if (lifeTimer < lifeTime+disappearTime) {
				lifeTimer+=Time.deltaTime;
			}
			else {
				Destroy(this.gameObject);
			}
		}
	
	}

	public void OnTriggerEnter(Collider _collider){
		if (_collider.CompareTag("AttackTarget") ){
			Entity ent=_collider.GetComponent<Entity>();
			if (ent.player.flag!=player.flag){
				Explode();
				ent.Hurt(damage);
			}
		}
		else{
			if (!_collider.CompareTag("MicroMissilePod") ){
				Explode();
			}
		}
	}

	void Explode () {
		exploded=true;
		if (missileFireBall!=null){
			Object fireball=Instantiate(missileFireBall,transform.position,transform.rotation);
		}

	}
}
