using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Aeroplane;
public class Aircraft : Entity {
	public GameObject boom;

	public AeroplaneAiControl aiController;
	public AeroplaneController plane;
	private Rigidbody body;

	public WeaponObject[] mainWeapons;
	public WeaponObject[] secondaryWeapons;
	public WeaponObject[] specialWeapons;
	public int mainWeaponIndex;
	public int secondaryIndex;
	public int specialWeaponIndex;

	public void SwitchMainWeapon(){
		mainWeaponIndex++;
		if (mainWeaponIndex>=mainWeapons.Length){
			mainWeaponIndex=0;
		}
	}


	public void SwitchSecondaryWeapon(){
		secondaryIndex++;
		if (secondaryIndex>=secondaryWeapons.Length){
			secondaryIndex=0;
		}
	}

	public void SwitchSpecialWeapon(){
		specialWeaponIndex++;
		if (specialWeaponIndex>=specialWeapons.Length){
			specialWeaponIndex=0;
		}
	}

	public WeaponObject GetMainWeapon(){
		return mainWeapons[mainWeaponIndex];
	}

	public WeaponObject GetSecondaryWeapon(){
		return secondaryWeapons[secondaryIndex];
	}

	public WeaponObject GetSpecialWeapon(){
		return specialWeapons[specialWeaponIndex];
	}

	void Awake(){
		aiController=GetComponent<AeroplaneAiControl>();
		plane=GetComponent<AeroplaneController>();
		body=GetComponent<Rigidbody>();
	}

	public void Expolde(){
		
		if (boom!=null){
			GameObject boomObj=Instantiate(boom);
			boomObj.transform.position=transform.position;
			CameraController.Instance().AddRadialBlur(true,transform.position);
		}

//		body.isKinematic=true;
		Destroy(this.gameObject);
	}
	
	public void OnCollisionEnter(Collision _collision){
		if (alive){
//			Die();
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
