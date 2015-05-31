using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Aeroplane;
public class Aircraft : Entity {
	public GameObject boom;

	public AeroplaneAiControl aiController;
	public AeroplaneController plane;

	void Awake(){
		aiController=GetComponent<AeroplaneAiControl>();
		plane=GetComponent<AeroplaneController>();
	}

	public void Expolde(){
		
		if (boom!=null){
			GameObject boomObj=Instantiate(boom);
			boomObj.transform.position=transform.position;
			
		}
//		Destroy(this.gameObject);
	}
	
	public void OnCollisionEnter(){
		if (alive){
			Die();
		}
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
