using UnityEngine;
using System.Collections;

public class EnemyManager : BasePlayer {
	private static EnemyManager instance ;
	
	public static  EnemyManager Instance(){
		if (instance == null)
			instance =GameObject.FindObjectOfType<EnemyManager>();
		return instance;
	}
	public UnityStandardAssets.Utility.WaypointCircuit path;


}
