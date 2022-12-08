using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster1_v3 : Monster {

    public bool isPlaySound = false;

    private TaskMeat taskMeatScript;
    public NavMeshPath mainPath;

    private Transform monsterPoint1;

	[HideInInspector] public bool isSeeMeat1 = false;
	[HideInInspector] public bool isSeeMeat2 = false;
	[HideInInspector] public bool isSeeMeat3 = false;
	[HideInInspector] public bool isAteMeat1 = false;
	[HideInInspector] public bool isAteMeat2 = false;
	[HideInInspector] public bool isAteMeat3 = false;

    public Transform meat1;
    public Transform meat2;
    public Transform meat3;

	void OnEnable () {

		player = GameObject.Find("Player").transform;
		monster = GameObject.Find("Monster1_v3").transform;
		monsterController = GetComponent<CharacterController>();
		flashlightScript = GameObject.Find ("Flashlight").GetComponent<Flashlight> ();
		healthScript = player.GetComponent<Health>();
		taskMeatScript = player.GetComponent<TaskMeat>();
        crouchScript = player.GetComponent<Crouch>();
        mapScript = GameObject.Find("Player").GetComponent<Map>();
        playerHead = GameObject.Find ("PlayerHead").transform;
        monsterPoint1 = GameObject.Find("Monster6Point1").transform;
        monsterAgent = monster.GetComponent<NavMeshAgent>();

        isSeeMeat1 = false;
        isSeeMeat2 = false;
        isSeeMeat3 = false;
        isAteMeat1 = false;
        isAteMeat2 = false;
        isAteMeat3 = false;

        isPathPossible = true;
        mainPath = new NavMeshPath();
        audioSource.pitch = 1;

    }

	void Update () {

		float distance = Vector3.Distance(player.position, monster.position);
        mapScript.isFastTravel = false;

        runVelocity = UnityEngine.Random.Range(8, 12);
        PlayerDead();
        CheckPath();
       
        if (isPathPossible == true)
        {
            MonsterLongLight(distance);
            MonsterFlashlight(distance);
            MonsterRaycast(distance);
            MonsterAttack(distance);
            MonsterFollowsPlayer(distance);
          
        }else
        {
            MonsterFollowsPoint();
        }

        MonsterAttackSound(distance);
        MonsterCheckMeats();
        MonsterEatMeat(isSeeMeat1, isAteMeat1, monster, meat1, taskMeatScript.meats[0].meatCondition);
        MonsterEatMeat(isSeeMeat2, isAteMeat2, monster, meat2, taskMeatScript.meats[1].meatCondition);
        MonsterEatMeat(isSeeMeat3, isAteMeat3, monster, meat3, taskMeatScript.meats[2].meatCondition);

        // Zatrzymanie odtwarzania dzwiekow

        if (Time.timeScale == 0 && isPlaySound == false)
        {

            audioSource.Pause();

            isPlaySound = true;

        }

        else // Wznowienie odtwarzania dzwiekow

        if (Time.timeScale == 1 && isPlaySound == true)
        {

            audioSource.UnPause();

            isPlaySound = false;
        }

    }

    void CheckPath()
    {
        NavMesh.CalculatePath(monster.transform.position, player.transform.position, -1, mainPath);

        if ((mainPath.status == NavMeshPathStatus.PathInvalid || mainPath.status == NavMeshPathStatus.PathPartial))
        {
            isPathPossible = false;
        } else
        {
            isPathPossible = true;
        }
    }

    void PlayerDead()
    {
        if (healthScript.health <= 0)
        {
            isSawPlayer = false;
            isRayPlayer = false;
            isSawLight = false;
            monsterAnimator.SetBool("IsSaw", false);
            isAttack = false;
            monsterAnimator.SetBool("Attack", false);
        }
    }

    public override void MonsterFollowsPoint()
    {
        monsterAgent.SetDestination(monsterPoint1.transform.position);
        monsterAgent.speed = walkVelocity;
        monsterAgent.Resume();
        monsterAgent.updatePosition = true;
        monsterAnimator.SetBool("IsSaw", false);
    }

    public override void MonsterFollowsPlayer(float _distance)
    {
        if ((isSawLight == true || isSawPlayer == true || isRayPlayer == true) && _distance >= 5 && isSeeMeat1 == false && isSeeMeat2 == false && isSeeMeat3 == false)
        {
            monsterAgent.SetDestination(player.transform.position);
            monsterAgent.Resume();
            monsterAgent.updatePosition = true;
            monsterAgent.speed = runVelocity;
            monsterAnimator.SetBool("IsSaw", true);
        }
    }

    public override void MonsterLongLight(float _distance)
    {
        if (_distance <= 40 && Input.GetMouseButtonDown(2) && flashlightScript.isFlashlightOn == true && isSawLight == false && healthScript.health > 0)
        {
            isSawLight = true;
        }
        else if (_distance >= 50 && flashlightScript.isFlashlightOn == true && healthScript.health > 0)
        {
            isSawLight = false;
        }
        else if (_distance >= 40 && flashlightScript.isFlashlightOn == false)
        {
            isSawLight = false;
        }
        else if (_distance >= 30 && flashlightScript.isFlashlightOn == true && crouchScript.isCrouch == true)
        {
            isSawLight = false;
        }
        else if (_distance >= 20 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true)
        {
            isSawLight = false;
        }
    }

    public override void MonsterFlashlight(float _distance)
    {
        if (((_distance <= 17 && flashlightScript.isFlashlightOn == true) || (_distance <= 26 && Input.GetKey("left shift"))) && isSawPlayer == false && healthScript.health > 0)
        {
            isSawPlayer = true;
        }
        else if (_distance > 30 && flashlightScript.isFlashlightOn == true && healthScript.health > 0)
        {
            isSawPlayer = false;
        }
        else if (_distance > 20 && flashlightScript.isFlashlightOn == false)
        {
            isSawPlayer = false;
        }
        else if (_distance > 13 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true)
        {
            isSawPlayer = false;
        }

        if (_distance <= 11 && flashlightScript.isFlashlightOn == false && isSawPlayer == false && healthScript.health > 0)
        {
            isSawPlayer = true;
        }
    }

    public override void MonsterRaycast(float _distance)
    {
        if (_distance <= 25 && isRayPlayer == false && healthScript.health > 0)
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

        else if (_distance > 40)
        {
            isRayPlayer = false;
        }
    }

    public override void MonsterAttack(float _distance)
    {
        if (_distance < 5 && healthScript.health > 0)
        {
            monsterAgent.Stop();
            monsterAgent.velocity = Vector3.zero;
            isSawLight = false;
            monsterAnimator.SetBool("Attack", true);
            monsterAgent.updatePosition = true;
            monsterAgent.SetDestination(player.transform.position);
            monster.rotation = Quaternion.Slerp(monster.rotation, Quaternion.LookRotation(player.position - monster.position), rotationVelocity * Time.deltaTime);
        }
        else if ((_distance >= 5 && healthScript.health > 0) || healthScript.health <= 0)
        {
            monsterAnimator.SetBool("Attack", false);
        }
    }

    void MonsterAttackSound(float _distance)
    {
        if (_distance < 8 && isAttack == false && healthScript.health > 0 && isSeeMeat1 == false && isSeeMeat2 == false && isSeeMeat3 == false)
        {
            audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.1f);
            audioSource.clip = monsterAttackSound;
            audioSource.Play();
            isAttack = true;
        }
        else if ((_distance >= 8 && isAttack == true) || healthScript.health <= 0)
        {
            audioSource.pitch = 1;
            audioSource.clip = monsterSound;
            audioSource.Play();
            isAttack = false;
            audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.1f);
        }
    }

    void MonsterCheckMeats()
    {

        if (isSawPlayer == true || isRayPlayer == true || isSawLight == true)
        {
            if (taskMeatScript.meats[0].isDragMeat == true && taskMeatScript.meats[0].meatCondition > 0)
            {
                isSeeMeat1 = true;
            }

            if (taskMeatScript.meats[1].isDragMeat == true && taskMeatScript.meats[1].meatCondition > 0)
            {
                isSeeMeat2 = true;
            }

            if (taskMeatScript.meats[2].isDragMeat == true && taskMeatScript.meats[2].meatCondition > 0)
            {
                isSeeMeat3 = true;
            }
        }
    }

    void MonsterEatMeat(bool isMeat, bool isEat, Transform monster, Transform meat, float meatCondition)
    {
        if (isMeat == true)
        {

            float meatDistance = Vector3.Distance(meat.position, monster.position);

            monsterAgent.SetDestination(meat.transform.position);
            monsterAgent.Resume();
            monsterAgent.updatePosition = true;

            if (meatDistance < 5 && isEat == false)
            {
                isEat = true;
            }

            if (isEat == true && meatCondition > 0)
            {
                meatCondition -= 10f * Time.deltaTime;
            }

            if (meatCondition <= 0)
            {
                isEat = false;
            }

        }
    }
}
