using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster2_v2 : Monster {

    public bool isPlaySound = false; 

    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private AudioClip hitDoorSound;

    private Transform monsterStartPoint;
    private Transform monsterPoint1;
    private Transform monsterPoint2;
    private Transform monsterPoint3;

    public NavMeshPath mainPath;

	public bool isStartPoint = false;

    public enum ActualPoint
    {
        Point1,
        Point2,
        Point3
    }

    public ActualPoint actualPoint;

    private GameObject kitchenDoor;
    public bool isKitchenDoor = false;
    private GameObject uncleDoor;
    public bool isUncleDoor = false;
    private GameObject bathroomDoor;
    public bool isBathroomDoor = false;
    private GameObject toiletDoor;
    public bool isToiletDoor = false;
    private GameObject nicheDoor;
    public bool isNicheDoor = false;
    private GameObject stableDoor;
    public bool isStableDoor = false;
    private GameObject smallShedDoor;
    public bool isSmallShedDoor = false;
    private GameObject toolShedDoor;
    public bool isToolShedDoor = false;
    private GameObject secretRoomDoor;
    public bool isSecretRoomDoor = false;
    private GameObject cornfieldDoor;
    public bool isCornfieldDoor = false;
    private GameObject gardenDoor;
    public bool isGardenDoor = false;
    private GameObject houseDoor;
    public bool isHouseDoor = false;

	void OnEnable () {

		player = GameObject.Find("Player").transform;
		monster = GameObject.Find("Monster2_v2").transform;
		monsterStartPoint = GameObject.Find("Monster4StartPoint").transform;
        monsterPoint1 = GameObject.Find("Monster4Point1").transform;
        monsterPoint2 = GameObject.Find("Monster4Point2").transform;
        monsterPoint2 = GameObject.Find("Monster4Point3").transform;
        monsterController = GetComponent<CharacterController>();
		flashlightScript = GameObject.Find ("Flashlight").GetComponent<Flashlight> ();
		healthScript = player.GetComponent<Health>();
        crouchScript = player.GetComponent<Crouch>();
        monsterAgent = monster.GetComponent<NavMeshAgent>();
		playerHead = GameObject.Find ("PlayerHead").transform;
        mapScript = GameObject.Find("Player").GetComponent<Map>();

        kitchenDoor = GameObject.Find("DoorKitchen").gameObject;
        uncleDoor = GameObject.Find("DoorUncle").gameObject;
        bathroomDoor = GameObject.Find("DoorBathroom").gameObject;
        toiletDoor = GameObject.Find("DoorToilet").gameObject;
        nicheDoor = GameObject.Find("DoorNiche").gameObject;
        stableDoor = GameObject.Find("DoorStable").gameObject;
        smallShedDoor = GameObject.Find("DoorSmallShed").gameObject;
        toolShedDoor = GameObject.Find("DoorToolShed").gameObject;
        secretRoomDoor = GameObject.Find("DoorSecretRoom").gameObject;
        cornfieldDoor = GameObject.Find("DoorCornfield").gameObject;
        gardenDoor = GameObject.Find("DoorGarden").gameObject;
        houseDoor = GameObject.Find("DoorHouse").gameObject;

        isKitchenDoor = false;
        isUncleDoor = false;
        isBathroomDoor = false;
        isToiletDoor = false;
        isNicheDoor = false;
        isStableDoor = false;
        isSmallShedDoor = false;
        isToolShedDoor = false;
        isSecretRoomDoor = false;
        isCornfieldDoor = false;
        isGardenDoor = false;
        isHouseDoor = false;

        isStartPoint = false;
        actualPoint = ActualPoint.Point1;

        isPathPossible = true;
        mainPath = new NavMeshPath();

        hitAudioSource.clip = null;
        audioSource.pitch = 1;

    }

	void Update () {

		float distance = Vector3.Distance(player.position, monster.position);

        runVelocity = UnityEngine.Random.Range(8, 12);
        mapScript.isFastTravel = false;
        CheckPath();

        if (isStartPoint == false)
        {
            monsterAgent.updatePosition = true;
            monsterAgent.SetDestination(monsterStartPoint.transform.position);
        }

        MonsterFollowsPoint();
        MonsterLongLight(distance);
        MonsterFlashlight(distance);
        MonsterRaycast(distance);
        MonsterAttack(distance);
        MonsterFollowsPlayer(distance);
        MonsterAttackSound(distance);

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && isPlaySound == false)
        {

            audioSource.Pause();
            hitAudioSource.Pause();

            isPlaySound = true;

        }

        else // Wznowienie odtwarzania dzwiekow

        if (Time.timeScale == 1 && isPlaySound == true)
        {

            audioSource.UnPause();
            hitAudioSource.UnPause();

            isPlaySound = false;
        }

    }

	void OnTriggerEnter(Collider other){

        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster4StartPoint")
        { 
            isStartPoint = true;
        }else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster4Point1")
        {
            actualPoint = ActualPoint.Point2;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster4Point2")
        {
            actualPoint = ActualPoint.Point3;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster4Point3")
        {
            actualPoint = ActualPoint.Point1;
        }
    }

    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "DoorKitchen" && isKitchenDoor == false)
        {
            MonsterHitDoor(kitchenDoor, isKitchenDoor);
        }
        else if(other.gameObject.GetComponent<Collider>().gameObject.name == "DoorUncle" && isUncleDoor == false)
        {
            MonsterHitDoor(kitchenDoor, isUncleDoor);
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DoorBathroom" && isBathroomDoor == false)
        {
            MonsterHitDoor(kitchenDoor, isBathroomDoor);
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DoorToiler" && isToiletDoor == false)
        {
            MonsterHitDoor(kitchenDoor, isToiletDoor);
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DoorNiche" && isNicheDoor == false)
        {
            MonsterHitDoor(kitchenDoor, isNicheDoor);
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DoorStable" && isStableDoor == false)
        {
            MonsterHitDoor(kitchenDoor, isStableDoor);
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DoorSmallShed" && isSmallShedDoor == false)
        {
            MonsterHitDoor(kitchenDoor, isSmallShedDoor);
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DoorToolShed" && isToolShedDoor == false)
        {
            MonsterHitDoor(kitchenDoor, isToolShedDoor);
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DoorSecretRoom" && isSecretRoomDoor == false)
        {
            MonsterHitDoor(kitchenDoor, isSecretRoomDoor);
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DoorCornfield" && isCornfieldDoor == false)
        {
            MonsterHitDoor(kitchenDoor, isCornfieldDoor);
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DoorGarden" && isGardenDoor == false)
        {
            MonsterHitDoor(kitchenDoor, isGardenDoor);
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DoorHouse" && isHouseDoor == false)
        {
            MonsterHitDoor(kitchenDoor, isHouseDoor);
        }

    }

    void MonsterHitDoor(GameObject door, bool isHit)
    {
        door.tag = "Move2";
        hitAudioSource.clip = hitDoorSound;
        hitAudioSource.Play();
        Destroy(door.GetComponent<HingeJoint>());
        isHit = true;
        door.gameObject.GetComponent<Door>().isDestroyed = true;
    }

    void CheckPath()
    {
        if (isSawLight == true || isSawPlayer == true || isRayPlayer == true)
        {
            NavMesh.CalculatePath(monster.transform.position, player.transform.position, -1, mainPath);
        }


        if ((mainPath.status == NavMeshPathStatus.PathInvalid || mainPath.status == NavMeshPathStatus.PathPartial))
        {
            isPathPossible = false;
        }
        else
        {
            isPathPossible = true;
        }
    }

    public override void MonsterFollowsPoint()
    {
        if ((isSawPlayer == false && isRayPlayer == false && isSawLight == false && isStartPoint == true) || (isStartPoint == true && isPathPossible == false))
        {
            switch (actualPoint)
            {
                case ActualPoint.Point1:
                    SetPoint(monsterPoint1);
                    break;
                case ActualPoint.Point2:
                    SetPoint(monsterPoint2);
                    break;
                case ActualPoint.Point3:
                    SetPoint(monsterPoint3);
                    break;
            }
        }
    }

    void SetPoint(Transform monsterPoint)
    {
        monsterAgent.SetDestination(monsterPoint.transform.position);
        monsterAgent.speed = walkVelocity;
        monsterAgent.Resume();
        monsterAgent.updatePosition = true;
        monsterAnimator.SetBool("isSaw", false);
    }

    public override void MonsterFollowsPlayer(float _distance)
    {
        if ((isSawLight == true || isSawPlayer == true || isRayPlayer == true) && _distance >= 5 && isStartPoint == true && isPathPossible == true)
        {
            monsterAgent.SetDestination(player.transform.position);
            monsterAgent.Resume();
            monsterAgent.updatePosition = true;
            monsterAgent.speed = runVelocity;
            monsterAnimator.SetBool("isSaw", true);
        }

        if (healthScript.health <= 0)
        {
            isSawPlayer = false;
            isRayPlayer = false;
            isSawLight = false;
            isAttack = false;
            monsterAnimator.SetBool("Attack", false);
        }

    }

    public override void MonsterLongLight(float _distance)
    {
        if (_distance <= 100 && Input.GetMouseButtonDown(2) && flashlightScript.isFlashlightOn == true && isSawLight == false && healthScript.health > 0 && isStartPoint == true)
        {
            isSawLight = true;
        }
        else if (_distance >= 80 && flashlightScript.isFlashlightOn == true && healthScript.health > 0 && isStartPoint == true)
        {
            isSawLight = false;
        }
        else if (_distance >= 70 && flashlightScript.isFlashlightOn == false && isStartPoint == true)
        {
            isSawLight = false;
        }
        else if (_distance >= 40 && flashlightScript.isFlashlightOn == true && crouchScript.isCrouch == true && isStartPoint == true)
        {
            isSawLight = false;
        }
        else if (_distance >= 30 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true && isStartPoint == true)
        {
            isSawLight = false;
        }
    }

    public override void MonsterFlashlight(float _distance)
    {
        if (_distance <= 27 && isSawPlayer == false && flashlightScript.isFlashlightOn == true && healthScript.health > 0 && isStartPoint == true)
        {
            isSawPlayer = true;
        }
        else if (_distance > 40 && flashlightScript.isFlashlightOn == true && healthScript.health > 0 && isStartPoint == true)
        {
            isSawPlayer = false;
        }
        else if (_distance > 30 && flashlightScript.isFlashlightOn == false && isStartPoint == true)
        {
            isSawPlayer = false;
        }
        else if (_distance > 13 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true && isStartPoint == true)
        {
            isSawPlayer = false;
        }

        if (_distance <= 21 && flashlightScript.isFlashlightOn == false && isSawPlayer == false && healthScript.health > 0 && isStartPoint == true)
        {
            isSawPlayer = true;
        }
    }

    public override void MonsterRaycast(float _distance)
    {
        if (_distance <= 35 && isRayPlayer == false && healthScript.health > 0 && isStartPoint == true)
        {
            RaycastHit hit;

            if (Physics.Raycast(monster.transform.position, monster.transform.forward, out hit, rayLength, 1 << 10))
            {

                if (hit.collider.gameObject.name == "Player")
                {
                    isRayPlayer = true;
                }
            }
        }

        else if (_distance > 50 && isStartPoint == true)
        {
            isRayPlayer = false;
        }
    }

    public override void MonsterAttack(float _distance)
    {

        if (_distance < 5 && healthScript.health > 0 && isStartPoint == true)
        {
            monsterAgent.SetDestination(player.transform.position);
            monsterAgent.updatePosition = true; 
            monsterAgent.Stop();
            monsterAgent.velocity = Vector3.zero;
            isSawLight = false;
            monsterAnimator.SetBool("Attack", true);
            monster.rotation = Quaternion.Slerp(monster.rotation, Quaternion.LookRotation(player.position - monster.position), rotationVelocity * Time.deltaTime);
        }
        else
        {
            monsterAnimator.SetBool("Attack", false);
        }
    }

    void MonsterAttackSound(float _distance)
    {
        if (_distance < 8 && isAttack == false && isStartPoint == true && healthScript.health > 0)
        {
            audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.1f);
            audioSource.clip = monsterAttackSound;
            audioSource.Play();
            isAttack = true;
        }
        else if (_distance >= 8 && isAttack == true && isStartPoint == true && healthScript.health > 0)
        {
            audioSource.pitch = 1;
            audioSource.clip = monsterSound;
            audioSource.Play();
            isAttack = false;
        }
    }

}
