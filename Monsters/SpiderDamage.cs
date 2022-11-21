using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderDamage : MonoBehaviour {

    private Transform player;
    private Health healthScript;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        healthScript = player.GetComponent<Health>();
    }


    void Damage()
    {
        healthScript.PlayerDamage4();
    }

}
