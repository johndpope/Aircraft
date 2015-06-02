using UnityEngine;
using System.Collections;

public class MissileLauncher : WeaponObject {

	public Missile missilePrefab;
	public void Fire(){
		
		if (missilePrefab!=null){
			Missile missile=Instantiate(missilePrefab);
			missile.transform.rotation=transform.rotation;
			missile.transform.position=transform.TransformPoint(new Vector3(0,-5,0) );
			missile.target=target;
			missile.Fire ();
			missile.player=owner.player;
			missile.GetComponent<Rigidbody>().velocity=owner.GetComponent<Rigidbody>().velocity;
		}
	}

	protected override void Update(){
		base.Update();
		if (Input.GetKeyDown(KeyCode.M)){
			Fire ();
		}
	}
}
