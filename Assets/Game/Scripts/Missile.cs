using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;
public class Missile : Entity {
	public float damage=500;
	public GameObject boom;
	public ParticleSystem smoke;
	public TrailRenderer trail;
	public float dropDuration=1;

	private Rigidbody body;
	public float speed=100;
	public Entity target;

	public float lifeTimer;
	public float lifeTime=10;



	public Transform startTransform;
	public Transform targetTransform;

	public float homingAngle=90;

	public float explodeRadius=10;

	void Awake(){

		body=this.GetComponent<Rigidbody>();
	}

	public void OnCollisionEnter(Collision _collision){
		if (_collision.collider.CompareTag("AttackTarget") ){
			Entity ent=_collision.collider.GetComponent<Entity>();
			if (ent.player.flag!=player.flag){
				Explode();
			}
		}
		else{
			Explode();
		}
	}

	public void Explode(){

		if (boom!=null){
			GameObject boomObj=Instantiate(boom);
			boomObj.transform.position=transform.position;

		}

		Collider[] hitCol=Physics.OverlapSphere(transform.position,explodeRadius);
		for (int i=0;i<hitCol.Length;i++){
			if (hitCol[i].CompareTag("AttackTarget")){
				Entity ent=hitCol[i].GetComponent<Entity>();
				ent.Hurt(damage);
				GameManager.Instance().ShowLog("missile hits: "+ent.gameObject.name,2);
			}
		}

		smoke.transform.SetParent(null);
		smoke.Stop();
		GameManager.Instance().StartCoroutine(DoExplode() );
		Destroy(this.gameObject);


	}

	public IEnumerator DoExplode(){
		while (smoke!=null && smoke.IsAlive() ){
			yield return new WaitForEndOfFrame();
		}
		Destroy(smoke.gameObject);
	}

	public void Fire(){
		StartCoroutine(DoFire());

//		GetComponent<UnityStandardAssets.Utility.WaypointProgressTracker>().cir =EnemyManager.Instance().path;
	}

	private Vector3 originForward;
	private Vector3 originPos;
	public IEnumerator DoFire(){
		Collider col=this.GetComponent<Collider>();
		col.enabled=false;

		originForward=transform.forward;
		originPos=transform.position;
		yield return new WaitForSeconds(dropDuration);

		col.enabled=true;

//		yield return new WaitForSeconds(homingDuration);
//		GetComponent<WaypointProgressTracker>().enabled=false;
//		target=null;

	}

	void Update(){
		if (lifeTimer<lifeTime){
			lifeTimer+=Time.deltaTime;
		}
		else{
			Destroy(this.gameObject);
		}


//		Debug.Log(body.velocity.magnitude);
//		if (body.velocity.magnitude>300){
//			target=null;
//		}

		if (target!=null){
//			startTransform.position=originPos;
			startTransform.position=transform.position;

			targetTransform.position=target.transform.position;
		}
		else{
//			startTransform.position=originPos;
			startTransform.position=transform.position;
			targetTransform.position=startTransform.position+originForward*10000;
		}

		Vector3 dir=targetTransform.position-startTransform.position;
		float angle=Vector3.Angle(dir,body.velocity);
//		Debug.Log(angle);
		if (angle>homingAngle ){
			originForward=transform.forward;
			target=null;
		}

//		Vector3 dir=transform.forward;
//		body.velocity=dir.normalized*speed;
//		if (target!=null){
//			target.position =circuit.GetRoutePoint(progressDistance + lookAheadForTargetOffset + lookAheadForTargetFactor*speed).position;
//		target.rotation =
//			Quaternion.LookRotation(
//				circuit.GetRoutePoint(progressDistance + lookAheadForSpeedOffset + lookAheadForSpeedFactor*speed)
//				.direction);
//		}
//		if (target!=null){
//
//			transform.position+=dir.normalized*100*Time.deltaTime;
//		}

	}
}
