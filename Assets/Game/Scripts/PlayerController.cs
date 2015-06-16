using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : BasePlayer {
	private static PlayerController instance ;
	
	public static  PlayerController Instance(){
		if (instance == null)
			instance =GameObject.FindObjectOfType<PlayerController>();
		return instance;
	}

	public Image aimLockOn;

	public Aircraft player;
	public Text txtWeapon;
	public Transform radarTransform;
	public float detectRange=800;
	public float detectAngle=360;

	public Image enemyDotPrefab;
	public List<Image> enemyDots;
	public int maxEnemyCount=100;
	void Awake(){
		for (int i=0;i<maxEnemyCount;i++){
			Image enemyDot=Instantiate(enemyDotPrefab);
			enemyDot.transform.SetParent(radarTransform);
			enemyDot.transform.localScale=new Vector3(1,1,1);
			enemyDot.gameObject.SetActive(false);
			enemyDots.Add(enemyDot);
		}
	}

	void Update(){
		if (GameInputController.Instance().GetButton("Button0") || Input.GetKey(KeyCode.Z) ){
			player.GetMainWeapon().Fire();
		}

		if (GameInputController.Instance().GetButtonDown("Button1") || Input.GetKeyDown(KeyCode.X) ){
			player.GetSecondaryWeapon().Fire();
		}

		if (GameInputController.Instance().GetButtonDown("Button2") || Input.GetKeyDown(KeyCode.A) ){
			player.SwitchMainWeapon();
			Debug.Log(player.GetMainWeapon().name);
		}

		if (GameInputController.Instance().GetButtonDown("Button3") || Input.GetKeyDown(KeyCode.S) ){
			player.SwitchSecondaryWeapon();
			Debug.Log(player.GetSecondaryWeapon().name);
		}

		txtWeapon.text=string.Format("W1: {0}\nW2: {1}",player.GetMainWeapon().name,player.GetSecondaryWeapon().name );

		Detect();
	}

//	void FixedUpdate(){
//
//	}

	void Detect(){
		Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, detectRange);
		
		List<Entity> targets=new List<Entity>();
		
		for (int i=0;i<hitColliders.Length;i++){
			if (hitColliders[i].CompareTag("AttackTarget")){
				Entity hitTarget=hitColliders[i].GetComponent<Entity>();
				if (hitTarget!=null && hitTarget!=this && hitTarget.Player.flag!=player.player.flag ){
					Vector3 curDir=hitColliders[i].transform.position-player.transform.position;
					if (Vector3.Angle(curDir,transform.forward)<detectAngle ){
						targets.Add(hitTarget);
					}
				}
				
			}
		}

		for (int i=0;i<enemyDots.Count;i++){
			enemyDots[i].gameObject.SetActive (false);
		}


		for (int i=0;i<targets.Count;i++){
			enemyDots[i].gameObject.SetActive(true);
			Vector3 dir=targets[i].transform.position- player.transform.position;
			Vector2 pos=new Vector2(dir.x,dir.z );
//			Debug.Log(pos);

			enemyDots[i].rectTransform.anchoredPosition=pos/20;
		}

		Vector3 tmpRotation=radarTransform.localEulerAngles;
		tmpRotation.z=player.transform.localEulerAngles.y;
		radarTransform.localEulerAngles=tmpRotation;
	}
}
