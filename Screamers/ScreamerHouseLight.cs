using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerHouseLight : MonoBehaviour, IScreamer {

    [SerializeField] private GameObject houseLight;
    public bool isCalled;

    public void CallScreamer()
    {
        isCalled = true;
        houseLight.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isCalled == false)
        {
            CallScreamer();
        }
    }

}
