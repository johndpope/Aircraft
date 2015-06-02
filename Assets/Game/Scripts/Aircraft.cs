using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Aeroplane;
public class Aircraft : Entity {
	public GameObject boom;

	public AeroplaneAiControl aiController;
	public AeroplaneController plane;
	private Rigidbody body;

	void Awake(){
		aiController=GetComponent<AeroplaneAiControl>();
		plane=GetComponent<AeroplaneController>();
		body=GetComponent<Rigidbody>();
	}

	public void Expolde(){
		
		if (boom!=null){
			GameObject boomObj=Instantiate(boom);
			boomObj.transform.position=transform.position;
			
		}

//		body.isKinematic=true;
		Destroy(this.gameObject);
	}
	
	public void OnCollisionEnter(){
		if (alive){
			Die();
		}
	}

	public override Vector3 GetPredictPos(){
		return transform.position+body.velocity;
	}

	public override void Die(){
		base.Die();
		if (aiController!=null){
			aiController.enabled=false;
		}

		plane.Immobilize();
//		plane.enabled=false;
//		aiController.
//		plane.=0;
		Expolde();
	}


}
