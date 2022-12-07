using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider_v3 : Monster {

    public bool isPlaySound = false;

    private NavMeshPath mainPath;
    private Transform monsterPoint1;
    private Transform monsterPoint2;
    private Transform monsterPoint3;

    [SerializeField] private AudioClip spiderRunSound;
    [SerializeField] private bool isRun = false;
    [SerializeField] private bool isSpiderOffConfirmed = false;

    public bool isSpiderOff = false;

    public enum CurrentPoint
    {
        Point1,
        Point2,
        Point3
    }

    public CurrentPoint currentPoint;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        monster = GameObject.Find("Spider_v3").transform;
        monsterPoint1 = GameObject.Find("Spider3Point1").transform;
        monsterPoint2 = GameObject.Find("Spider3Point2").transform;
        monsterPoint3 = GameObject.Find("Spider3Point3").transform;
        healthScript = player.GetComponent<Health>();
        crouchScript = player.GetComponent<Crouch>();
        mapScript = GameObject.Find("Player").GetComponent<Map>();
        playerHead = GameObject.Find("PlayerHead").transform;
        monsterAgent = monster.GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
        isSpiderOff = false;
        isSpiderOffConfirmed = false;
        audioSource.pitch = 1;

        isPathPossible = true;
        mainPath = new NavMeshPath();
    }

    void Update()
    {

        float distance = Vector3.Distance(player.position, monster.position);
        mapScript.isFastTravel = false;
        CheckPath();

        if (isSpiderOff == true && isSpiderOffConfirmed == false)
        {
            DisableMonster();
        }

        MonsterFollowsPoint();
        MonsterLongLight(distance);
        MonsterFlashlight(distance);
        MonsterRaycast(distance);
        MonsterAttack(distance);
        MonsterAttackSound(distance);
        MonsterRunSound(distance);
        MonsterFollowsPlayer(distance);
 
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Spider3Point1")
        {
            currentPoint = CurrentPoint.Point2;
        }

       else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Spider3Point2" && isSpiderOff == false)
        {
            currentPoint = CurrentPoint.Point3;
        }

       else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Spider3Point3")
        {
            currentPoint = CurrentPoint.Point1;
        }

       else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Spider3Point2" && isSpiderOff == true)
        {
            monster.gameObject.SetActive(false);
            monster.gameObject.GetComponent<Spider_v3>().enabled = false;
            mapScript.isFastTravel = true;
        }
    }

    void DisableMonster()
    {
        isSawPlayer = false;
        isRayPlayer = false;
        isSawLight = false;
        monsterAnimator.SetBool("isSaw", true);
        monsterAnimator.SetBool("Attack", false);
        isSpiderOffConfirmed = true;
        monsterAgent.speed = runVelocity;
        monsterAgent.SetDestination(monsterPoint2.transform.position);
        monsterAgent.Resume();
        monsterAgent.updatePosition = true;
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
        if ((isSawPlayer == false && isRayPlayer == false && isSawLight == false && isSpiderOff == false) || isPathPossible == false)
        {
            switch (currentPoint)
            {
                case CurrentPoint.Point1:
                    SetPoint(monsterPoint1);
                    break;
                case CurrentPoint.Point2:
                    SetPoint(monsterPoint2);
                    break;
                case CurrentPoint.Point3:
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
    }

    public override void MonsterFollowsPlayer(float _distance)
    {
        if ((isSawLight == true || isSawPlayer == true || isRayPlayer == true) && _distance >= 5 && isPathPossible == true && isSpiderOff == false)
        {
            monsterAnimator.SetBool("isSaw", true);
            monsterAnimator.SetBool("Point", false);
            monsterAgent.SetDestination(player.transform.position);
            monsterAgent.Resume();
            monsterAgent.updatePosition = true;
        }

        if (healthScript.health <= 0)
        {
            isSawPlayer = false;
            isRayPlayer = false;
            isSawLight = false;
            monsterAnimator.SetBool("isSaw", false);
            monsterAgent.speed = walkVelocity;
            isAttack = false;
            monsterAnimator.SetBool("Attack", false);
        }
    }

    public override void MonsterLongLight(float _distance)
    {
        if (_distance <= 40 && Input.GetMouseButtonDown(2) && flashlightScript.isFlashlightOn == true && isSawLight == false && healthScript.health > 0 && isSpiderOff == false)
        {
            isSawLight = true;
            monsterAgent.speed = runVelocity;
        }
        else if (_distance >= 50 && flashlightScript.isFlashlightOn == true && healthScript.health > 0 && isSpiderOff == false)
        {
            isSawLight = false;
            monsterAnimator.SetBool("IsSaw", false);
        }
        else if (_distance >= 40 && flashlightScript.isFlashlightOn == false && isSpiderOff == false)
        {
            isSawLight = false;
            monsterAnimator.SetBool("IsSaw", false);
        }
        else if (_distance >= 30 && flashlightScript.isFlashlightOn == true && crouchScript.isCrouch == true && isSpiderOff == false)
        {
            isSawLight = false;
            monsterAnimator.SetBool("IsSaw", false);
        }
        else if (_distance >= 20 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true && isSpiderOff == false)
        {
            isSawLight = false;
            monsterAnimator.SetBool("IsSaw", false);
        }
    }

    public override void MonsterFlashlight(float _distance)
    {
        if (_distance <= 25 && isSawPlayer == false && flashlightScript.isFlashlightOn == true && healthScript.health > 0 && isSpiderOff == false)
        {
            isSawPlayer = true;
            monsterAgent.speed = runVelocity;
        }
        else if (_distance > 40 && flashlightScript.isFlashlightOn == true && healthScript.health > 0 && isSpiderOff == false)
        {
            isSawPlayer = false;
            monsterAnimator.SetBool("IsSaw", false);
        }
        else if (_distance > 30 && flashlightScript.isFlashlightOn == false && isSpiderOff == false)
        {
            isSawPlayer = false;
            monsterAnimator.SetBool("IsSaw", false);
        }
        else if (_distance > 13 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true && isSpiderOff == false)
        {
            isSawPlayer = false;
            monsterAnimator.SetBool("IsSaw", false);
        }

        if (_distance <= 11 && flashlightScript.isFlashlightOn == false && isSawPlayer == false && healthScript.health > 0 && isSpiderOff == false)
        {
            isSawPlayer = true;
            monsterAgent.speed = runVelocity;
        }
    }

    public override void MonsterRaycast(float _distance)
    {
        if (_distance <= 25 && isRayPlayer == false && healthScript.health > 0 && isSpiderOff == false)
        {
            RaycastHit hit;

            if (Physics.Raycast(monster.transform.position, monster.transform.forward, out hit, rayLength, 1 << 10))
            {
                if (hit.collider.gameObject.name == "Player")
                {
                    isRayPlayer = true;
                    monsterAgent.speed = runVelocity;
                }
            }
        }
        else if (_distance > 40)
        {
            isRayPlayer = false;
            monsterAnimator.SetBool("Widzi_ok", false);
        }
    }

    public override void MonsterAttack(float _distance)
    {
        if (_distance < 5 && healthScript.health > 0 && isSpiderOff == false)
        {
            monsterAgent.Stop();
            monsterAgent.velocity = Vector3.zero;
            isSawLight = false;
            monsterAgent.speed = runVelocity;
            monsterAnimator.SetBool("Attack", true);
            monsterAgent.updatePosition = true; 
            monster.rotation = Quaternion.Slerp(monster.rotation, Quaternion.LookRotation(player.position - monster.position), rotationVelocity * Time.deltaTime);
        }
        else
        {
            monsterAnimator.SetBool("Attack", false);
        }
    }

    void MonsterAttackSound(float _distance)
    {
        if (_distance < 6 && isAttack == false && healthScript.health > 0)
        {
            audioSource.clip = monsterAttackSound;
            audioSource.pitch = 1;
            audioSource.Play();
            isAttack = true;
            isRun = false;

        }
        else if (_distance >= 6 && isAttack == true && healthScript.health > 0)
        {
            audioSource.clip = spiderRunSound;
            audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.5f);
            audioSource.Play();
            isAttack = false;
        }
    }

    void MonsterRunSound(float _distance)
    {
        if ((isSawPlayer == true || isRayPlayer == true || isSawLight == true) && _distance > 7 && isRun == false)
        {
            audioSource.clip = spiderRunSound;
            audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.5f);
            audioSource.Play();
            isRun = true;

        }
        else if ((isSawPlayer == false && isRayPlayer == false && isSawLight == false) && isRun == true)
        {
            audioSource.clip = monsterSound;
            audioSource.pitch = 1;
            audioSource.Play();
            isRun = false;
        }
    }

}
