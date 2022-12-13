using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerCorpse : MonoBehaviour, IScreamer {

    [SerializeField] private GameObject corpse;
    [SerializeField] private Cupboard cupboardScript;
    [SerializeField] private bool isCalled;

    public void CallScreamer()
    {
        corpse.AddComponent<Rigidbody>();
        corpse.GetComponent<Rigidbody>().mass = 2;
        corpse.GetComponent<Rigidbody>().AddForce(-corpse.transform.up * 1000f);
        cupboardScript.isCloseOpen = true;
        isCalled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isCalled == false)
        {
            CallScreamer();
        }
    }
}
