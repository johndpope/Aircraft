using UnityEngine;
using System.Collections;

public class MissileLauncher : WeaponObject {

	public Missile missilePrefab;
	public override void Fire(){
		base.Fire();
		
		if (missilePrefab!=null){
			Missile missile=Instantiate(missilePrefab);
			missile.transform.rotation=transform.rotation;
//			missile.transform.position=transform.TransformPoint(new Vector3(0,-5,0) );
			missile.transform.position=bulletTransform.position;
			missile.target=target;
			missile.Fire ();
			missile.player=owner.player;
			missile.GetComponent<Rigidbody>().velocity=owner.GetComponent<Rigidbody>().velocity;
			gameObject.GetComponent<AudioSource>().Play();
		}
	}

	public override void FireButtonDown() {
		base.FireButtonDown();
		Fire();
	}

	protected override void Update(){
		base.Update();
//		if (Input.GetKeyDown(KeyCode.C) || GameInputController.Instance().GetButtonDown("Button1") ){
//			Fire ();
//		}
	}
}
