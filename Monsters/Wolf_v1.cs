using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wolf_v1 : Monster {

    public bool isPlaySound = false; 

    private RandomJumpscare randomJumpscareScript;
    private NavMeshPath mainPath;
    private Transform monsterPoint1;
    private Transform monsterPoint2;
    private Transform monsterPoint3;
    private Transform monsterPoint4;
    private Transform monsterPoint5;

    [SerializeField] private AudioClip wolfRunSound;
    [SerializeField] private AudioClip wolfHowlSound;
    [SerializeField] private bool isHowl = false;
    [SerializeField] private bool isHowlDone = false;
    [SerializeField] private bool isRun = false;

    public bool isPathPossible = true;

    public enum ActualPoint
    {
        Point1,
        Point2,
        Point3,
        Point4,
        Point5
    }

    public ActualPoint actualPoint;

    public bool isFastTravel = false;

    void OnEnable()
    {

        player = GameObject.Find("Player").transform;
        monster = GameObject.Find("Wolf_v1").transform;
        monsterPoint1 = GameObject.Find("Wolf1Point1").transform;
        monsterPoint2 = GameObject.Find("Wolf1Point2").transform;
        monsterPoint3 = GameObject.Find("Wolf1Point3").transform;
        monsterPoint4 = GameObject.Find("Wolf1Point4").transform;
        monsterPoint5 = GameObject.Find("Wolf1Point").transform;
        flashlightScript = GameObject.Find("Flashlight").GetComponent<Flashlight>();
        healthScript = player.GetComponent<Health>();
        crouchScript = player.GetComponent<Crouch>();
        randomJumpscareScript = player.GetComponent<RandomJumpscare>();
        mapScript = GameObject.Find("Player").GetComponent<Map>();
        playerHead = GameObject.Find("PlayerHead").transform;
        monsterAgent = monster.GetComponent<NavMeshAgent>();

        isPathPossible = true;
        mainPath = new NavMeshPath();

        isFastTravel = false;

    }


    void Update()
    {

        float distance = Vector3.Distance(player.position, monster.position);
        CheckPath();

        if (isSawPlayer == false && isRayPlayer == false && isSawLight == false && isFastTravel == false)
        {
            mapScript.isFastTravel = true;
            isFastTravel = true;
        }

        MonsterFollowsPoint();
        MonsterLongLight(distance);
        MonsterFlashlight(distance);
        MonsterRaycast(distance);
        MonsterAttack(distance);
        MonsterAttackSound(distance);
        MonsterRunSound(distance);
        MonsterHowlSound();
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
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wolf1Point1")
        {
            StartCoroutine(Howl(ActualPoint.Point2));
        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wolf1Point2")
        {
            StartCoroutine(Howl(ActualPoint.Point3));
        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wolf1Point3")
        {
            StartCoroutine(Howl(ActualPoint.Point4));
        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wolf1Point4")
        {
            StartCoroutine(Howl(ActualPoint.Point5));
        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wolf1Point5")
        {
            StartCoroutine(Howl(ActualPoint.Point1));
        }

    }

    IEnumerator Howl(ActualPoint point)
    {
        actualPoint = point;
        isHowl = true;
        monsterAnimator.SetBool("Howl", true);
        yield return new WaitForSeconds(6);
        StopHowl();
    }

    void StopHowl()
    {
        isHowl = false;
        monsterAnimator.SetBool("Howl", false);
        StopCoroutine("Howl");
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
        if ((isSawPlayer == false && isRayPlayer == false && isSawLight == false) || isPathPossible == false)
        {
            if(isHowl == false)
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
                    case ActualPoint.Point4:
                        SetPoint(monsterPoint5);
                        break;
                    case ActualPoint.Point5:
                        SetPoint(monsterPoint5);
                        break;
                }
            }
        }
    }

    void SetPoint(Transform monsterPoint)
    {
        monsterAgent.speed = walkVelocity;
        monsterAgent.SetDestination(monsterPoint.transform.position);
        monsterAgent.Resume();
        monsterAgent.updatePosition = true;
    }

    public override void MonsterFollowsPlayer(float _distance)
    {
        if ((isSawLight == true || isSawPlayer == true || isRayPlayer == true) && _distance >= 7 && isPathPossible == true)
        {
            StopHowl();
            monsterAnimator.SetBool("IsSaw", true);
            monsterAgent.SetDestination(player.transform.position);
            monsterAgent.Resume();
            monsterAgent.updatePosition = true;
            mapScript.isFastTravel = false;
            isFastTravel = false;
        }

        if (healthScript.health <= 0)
        {
            isSawPlayer = false;
            isRayPlayer = false;
            isSawLight = false;
            monsterAnimator.SetBool("IsSaw", false);
            monsterAgent.speed = walkVelocity;
        }
    }

    public override void MonsterLongLight(float _distance)
    {
        if (_distance <= 40 && Input.GetMouseButtonDown(2) && flashlightScript.isFlashlightOn == true && isSawLight == false && healthScript.health > 0)
        {
            isSawLight = true;
            monsterAgent.speed = runVelocity;
        }
        else if (_distance >= 50 && flashlightScript.isFlashlightOn == true && healthScript.health > 0)
        {
            isSawLight = false;
            monsterAnimator.SetBool("IsSaw", false);
            monsterAgent.speed = walkVelocity;
        }
        else if (_distance >= 40 && flashlightScript.isFlashlightOn == false)
        {
            isSawLight = false;
            monsterAnimator.SetBool("IsSaw", false);
            monsterAgent.speed = walkVelocity;
        }
        else if (_distance >= 30 && flashlightScript.isFlashlightOn == true && crouchScript.isCrouch == true)
        {
            isSawLight = false;
            monsterAnimator.SetBool("IsSaw", false);
            monsterAgent.speed = walkVelocity;
        }
        else if (_distance >= 20 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true)
        {
            isSawLight = false;
            monsterAnimator.SetBool("IsSaw", false);
            monsterAgent.speed = walkVelocity;
        }
    }

    public override void MonsterFlashlight(float _distance)
    {
        if (_distance <= 25 && isSawPlayer == false && flashlightScript.isFlashlightOn == true && healthScript.health > 0)
        {
            isSawPlayer = true;
            monsterAgent.speed = runVelocity;
        }
        else if (_distance > 40 && flashlightScript.isFlashlightOn == true && healthScript.health > 0)
        {
            isSawPlayer = false;
            monsterAnimator.SetBool("IsSaw", false);
            monsterAgent.speed = walkVelocity;
        }
        else if (_distance > 30 && flashlightScript.isFlashlightOn == false)
        {
            isSawPlayer = false;
            monsterAnimator.SetBool("IsSaw", false);
            monsterAgent.speed = walkVelocity;
        }
        else if (_distance > 13 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true)
        {
            isSawPlayer = false;
            monsterAnimator.SetBool("IsSaw", false);
            monsterAgent.speed = walkVelocity;
        }

        if (_distance <= 11 && flashlightScript.isFlashlightOn == false && isSawPlayer == false && healthScript.health > 0)
        {
            isSawPlayer = true;
            monsterAgent.speed = runVelocity;
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
                    monsterAgent.speed = runVelocity;
                }
            }
        }
        else if (_distance > 40)
        {
            isRayPlayer = false;
            monsterAnimator.SetBool("IsSaw", false);
            monsterAgent.speed = walkVelocity;
        }
    }

    public override void MonsterAttack(float _distance)
    {
        if (_distance < 7 && healthScript.health > 0)
        {
            monsterAgent.Stop();
            monsterAgent.velocity = Vector3.zero;
            isSawLight = false;
            monsterAgent.speed = runVelocity;
            monsterAnimator.SetBool("Attack", true);
            monsterAgent.updatePosition = true;
            monster.rotation = Quaternion.Slerp(monster.rotation, Quaternion.LookRotation(player.position - monster.position), rotationVelocity * Time.deltaTime);
            mapScript.isFastTravel = false;
            isFastTravel = false;
        }
        else
        {
            monsterAnimator.SetBool("Attack", false);
        }
    }

    void MonsterAttackSound(float _distance)
    {
        if (_distance < 8 && isAttack == false)
        {
            audioSource.clip = monsterAttackSound;
            audioSource.Play();
            isAttack = true;
            isRun = false;

        }
        else if (_distance >= 8 && isAttack == true)
        {
            audioSource.clip = wolfRunSound;
            audioSource.Play();
            isAttack = false;
        }
    }

    void MonsterRunSound(float _distance)
    {
        if ((isSawPlayer == true || isRayPlayer == true || isSawLight == true) && _distance > 9 && isRun == false)
        {
            audioSource.clip = wolfRunSound;
            audioSource.Play();
            isRun = true;
        }
        else if ((isSawPlayer == false && isRayPlayer == false && isSawLight == false) && isRun == true)
        {
            audioSource.clip = monsterSound;
            audioSource.Play();
            isRun = false;
        }
    }

    void MonsterHowlSound()
    {
        if (isHowl == true && isHowlDone == false)
        {
            audioSource.clip = wolfHowlSound;
            audioSource.Play();
            isHowlDone = true;
        }
        else if (isHowl == false && isHowlDone == true)
        {
            audioSource.clip = monsterSound;
            audioSource.Play();
            isHowlDone = false;
        }
    }
}
