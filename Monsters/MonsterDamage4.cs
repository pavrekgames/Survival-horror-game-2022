using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage4 : MonoBehaviour {

	private Transform player;
	private Health healthPlayer;

	void Start () {
		player = GameObject.Find("Player").transform;
		healthPlayer = player.GetComponent<Health>();
	}


	void Damage(){
		healthPlayer.PlayerDamage4();
	}
}
