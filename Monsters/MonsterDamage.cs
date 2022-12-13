using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour {

	[SerializeField] private Health healthScript;
    [SerializeField] private Canvas damageCanvas;
    [SerializeField] private float damage;

    void Start()
    {
        healthScript = GameObject.Find("Player").GetComponent<Health>();
    }

    void InflictDamage()
    {
        healthScript.ReceiveDamage(damage, damageCanvas);
    }
}
