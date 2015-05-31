using UnityEngine;
using System.Collections;

public class Missile : Entity {
	public float damage=500;
	public GameObject boom;
	public ParticleSystem smoke;
	public float dropDuration=1;
	private Rigidbody body;
	public float speed=100;
	public Entity target;
	public Transform startTransform;
	public Transform targetTransform;


	public void OnCollisionEnter(){

		Expolde();
	}

	public void Expolde(){

		if (boom!=null){
			GameObject boomObj=Instantiate(boom);
			boomObj.transform.position=transform.position;

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
		Rigidbody body=this.GetComponent<Rigidbody>();
		col.enabled=false;

		originForward=transform.forward;
		originPos=transform.position;
		yield return new WaitForSeconds(dropDuration);

		col.enabled=true;






	}

	void Update(){

		if (target!=null){
			startTransform.position=transform.position;
//			startTransform.position=originPos;
			targetTransform.position=target.transform.position;
		}
		else{
//			startTransform.position=originPos;
			startTransform.position=transform.position;
			targetTransform.position=startTransform.position+originForward*10000;
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
