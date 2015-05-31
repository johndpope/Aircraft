using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Entity : MonoBehaviour {

	public float hp=100;
	public float maxHP=100;
	public BasePlayer player;
	public bool alive=true;

	public BasePlayer Player {
		get {
			return player;
		}
		set {
			player = value;
		}
	}

	public void Hurt(float _damage){
		hp-=_damage;
		if (hp<=0){
			Die ();
		}
	}

	public virtual void Die(){
		alive=false;
	}


}
