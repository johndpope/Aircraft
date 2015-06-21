using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponObject : MonoBehaviour {
	public string weaponName="Weapon";
	public Entity owner;
	public float detectRange=50;
	public float detectAngle=180;
	public Entity target;
	public Transform bulletTransform;
	public bool inSpecialState=false;
	public AudioClip[] voiceClips;



	public virtual void Fire(){

	}

	public virtual void FireButtonDown() {

	}

	public virtual void FireButtonUp() {

	}

	public virtual void FireButton(){

	}

	public void Dectect(){
		
		Entity tmpTarget=target;
		target=null;
		
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectRange);
		
		List<Entity> targets=new List<Entity>();
		
		for (int i=0;i<hitColliders.Length;i++){
			if (hitColliders[i].CompareTag("AttackTarget")){
				Entity hitTarget=hitColliders[i].GetComponent<Entity>();
				if (hitTarget!=null && hitTarget!=this && hitTarget.Player.flag!=owner.player.flag ){
					Vector3 curDir=hitColliders[i].transform.position-transform.position;
					if (Vector3.Angle(curDir,transform.forward)<detectAngle ){
						targets.Add(hitTarget);
					}
				}
				
			}
		}
		
		if (targets.Count>0){
			int minIndex=0;
			
			for (int i=0;i<targets.Count;i++){
				if (i!=minIndex){
					Vector3 minDir=targets[minIndex].transform.position-transform.position;
					Vector3 curDir=hitColliders[i].transform.position-transform.position;
					if ( curDir.magnitude<minDir.magnitude ){
						minIndex=i;
					}
				}
			}
			
			if (targets.Contains(tmpTarget) ){
				target=tmpTarget;
			}
			else{
				target=targets[minIndex];
			}
		}
	}

	public void PlayVoice() {
		if (voiceClips!=null && voiceClips.Length>=1) {
			int _idx = (int)(Random.value * voiceClips.Length);
			AudioManager.Instance().PlaySFX(voiceClips[_idx]);

		}


	}
	
	protected virtual void Update(){
		Dectect();
		if (target==null){
			
		}
		else{
			Vector3 curDir=target.transform.position-transform.position;
			//			Debug.Log(Vector3.Angle(curDir,transform.forward));
			Debug.DrawLine(transform.position,target.transform.position,Color.red);
		}
		//		Debug.Log("12");
	}
}
