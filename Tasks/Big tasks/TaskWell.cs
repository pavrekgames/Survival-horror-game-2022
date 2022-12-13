using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWell : MonoBehaviour {

	[SerializeField] private Transform bucket;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bucketSound;

    public Transform key;

    struct Stone
    {
        public GameObject stoneObject;
        public string stoneName;
        public bool isStone;
    }

    [SerializeField] private Stone[] stones;

    public int stonesCount = 0;

    void Update()
    {
        if (stonesCount == 5)
        {
            key.GetComponent<Collider>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Collider>().gameObject.name == stones[0].stoneName)
        {
            AddStoneToWell(stones[0]);
        }
        else if (col.gameObject.GetComponent<Collider>().gameObject.name == stones[1].stoneName)
        {
            AddStoneToWell(stones[1]);
        }
        else if (col.gameObject.GetComponent<Collider>().gameObject.name == stones[2].stoneName)
        {
            AddStoneToWell(stones[2]);
        }
        else if (col.gameObject.GetComponent<Collider>().gameObject.name == stones[3].stoneName)
        {
            AddStoneToWell(stones[3]);
        }
        else if (col.gameObject.GetComponent<Collider>().gameObject.name == stones[4].stoneName)
        {
            AddStoneToWell(stones[4]);
        }
    }

    void AddStoneToWell(Stone stone)
    {
        audioSource.PlayOneShot(bucketSound);
        bucket.transform.position = new Vector3(bucket.transform.position.x, bucket.transform.position.y + 0.5f, bucket.transform.position.z);
        key.transform.position = new Vector3(key.transform.position.x, key.transform.position.y + 0.5f, key.transform.position.z);
        stone.isStone = true;
        stone.stoneObject.GetComponent<Collider>().enabled = false;
        stone.stoneObject.SetActive(false);
        stonesCount++;
    }
}
