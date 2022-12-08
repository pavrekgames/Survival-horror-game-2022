using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPainting : MonoBehaviour, IRaycastTask {

	[SerializeField] private Transform painting;
	public bool isPainting = false;

    public void Execute()
    {
        painting.gameObject.AddComponent<Rigidbody>();
        isPainting = true;
    }
}
