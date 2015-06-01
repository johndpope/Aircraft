using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	private static GameManager instance ;
	
	public static  GameManager Instance(){
		if (instance == null)
			instance =GameObject.FindObjectOfType<GameManager>();
		return instance;
	}

	public Text txtInfo;

	public void ShowLog(string _logStr,float _duration){

		StartCoroutine(DoShowLog(_logStr,_duration) );
	}

	public IEnumerator DoShowLog(string _logStr,float _duration){
		txtInfo.text=_logStr;
		yield return new WaitForSeconds(_duration);
		txtInfo.text="";
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
