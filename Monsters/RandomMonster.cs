using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMonster : Monster {

    public bool isPlaySound = false;

    private Transform[] points;
    private RandomJumpscare randomJumpscareScript;
    private NavMeshPath mainPath;

    [Header("Random monster")]
    [SerializeField] private SkinnedMeshRenderer monsterMesh;
    [SerializeField] private int randomNumber;
    [SerializeField] private int randomPointIndex;
    [SerializeField] private float monsterTime = 30f;
    [SerializeField] private bool isCalculated = true;
    [SerializeField] private int firstRespawn = 0;

    public bool isPathPossible = false;

    void OnEnable()
    {

        player = GameObject.Find("Player").transform;

        points = new Transform[14];
        points[0] = GameObject.Find("MonsterBrookPoint").transform;
        points[1] = GameObject.Find("Monster6Point1").transform;
        points[2] = GameObject.Find("MonsterChanelPoint").transform;
        points[3] = GameObject.Find("MonsterPumpkinPoint1").transform;
        points[4] = GameObject.Find("Monster5Point1").transform;
        points[5] = GameObject.Find("Wolf1Point5").transform;
        points[6] = GameObject.Find("Wolf2Point3").transform;
        points[7] = GameObject.Find("Wolf3Point1").transform;
        points[8] = GameObject.Find("Monster3Point2").transform;
        points[9] = GameObject.Find("MonsterPlantPoint").transform;
        points[10] = GameObject.Find("MonsterPumpkinPoint3").transform;
        points[11] = GameObject.Find("Wolf1Point4").transform;
        points[12] = GameObject.Find("Wolf2Point2").transform;
        points[13] = GameObject.Find("Wolf3Point2").transform;

        monsterController = GetComponent<CharacterController>();
        healthScript = player.GetComponent<Health>();
        playerHead = GameObject.Find("PlayerHead").transform;
        flashlightScript = GameObject.Find("Flashlight").GetComponent<Flashlight>();
        crouchScript = player.GetComponent<Crouch>();
        randomJumpscareScript = player.GetComponent<RandomJumpscare>();
        mapScript = GameObject.Find("Player").GetComponent<Map>();
        monsterMesh = GameObject.Find("RandomMonster_mesh").GetComponent<SkinnedMeshRenderer>();

        randomPointIndex = 0;
        monsterTime = 30f;
        firstRespawn = UnityEngine.Random.Range(0, 2);

        isPathPossible = false;
        mainPath = new NavMeshPath();
        isCalculated = true;

        if (isSawPlayer == false && isSawPlayer == false && isRayPlayer == false && randomPointIndex == 0)
        {
            randomPointIndex = UnityEngine.Random.Range(0, 14);
        }
    }

    void Update()
    {

        float distance = Vector3.Distance(player.position, monster.position);
        runVelocity = UnityEngine.Random.Range(8, 12);
        mapScript.isFastTravel = false;
        CheckPath();

        MonsterLongLight(distance);
        MonsterFlashlight(distance);
        MonsterRaycast(distance);
        MonsterAttack(distance);
        MonsterFollowsPlayer(distance);
        MonsterLifeTime();

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
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterBrookPoint") // 1
        {
           randomPointIndex = 3;
        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster6Point1") // 2
        {
           RandomPoint();
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterChanelPoint")  
        {
           randomPointIndex = 10;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPumpkinPoint1") 
        {
           randomPointIndex = 11;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster5Point1") 
        {
           randomPointIndex = 4;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wolf1Point5") 
        {
           randomPointIndex = 12;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wolf2Point3") 
        {
           randomPointIndex = 13;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wolf3Point1") 
        {
           randomPointIndex = 14;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster3Point2") 
        {
           RandomPoint();
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPlantPoint") 
        {
           randomPointIndex = 13;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPumpkinPoint3") 
        {
           randomPointIndex = 4;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wolf1Point4") 
        {
           randomPointIndex = 6;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wolf2Point2") 
        {
           randomPointIndex = 7;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wolf3Point2") 
        {
           randomPointIndex = 8;
        }
    }

    void MonsterLifeTime()
    {
        if (isSawPlayer == false && isSawPlayer == false && isRayPlayer == false)
        {
            monsterTime -= 1 * Time.deltaTime;
        }

        if (monsterTime <= 0 || randomJumpscareScript.isPossibleTerrain == false)
        {
            monsterMesh.enabled = false;
            audioSource.enabled = false;
            monster.gameObject.GetComponent<RandomMonster>().enabled = false;
            monster.gameObject.SetActive(false);
            mapScript.isFastTravel = true;

        }
    }

    void RandomPoint()
    {
        randomNumber = UnityEngine.Random.Range(0, 14);

        if (randomNumber == randomPointIndex)
        {
            randomPointIndex = randomNumber + 1;
        }
        else
        {
            randomPointIndex = randomNumber;
        }
    }

    void CheckPath()
    {
        if (isSawPlayer == true || isSawPlayer == true || isRayPlayer == true)
        {
            NavMesh.CalculatePath(monster.transform.position, player.transform.position, -1, mainPath);
        }

        if ((mainPath.status == NavMeshPathStatus.PathInvalid || mainPath.status == NavMeshPathStatus.PathPartial) && isCalculated == false)
        {
            isPathPossible = false;
            isCalculated = true;
            randomNumber = UnityEngine.Random.Range(0, 14);

            if (randomNumber == randomPointIndex && randomNumber < 13)
            {
                randomPointIndex = randomNumber + 1;
            }
            else if (randomNumber == randomPointIndex && randomNumber == 13)
            {
                randomPointIndex = randomNumber - 1;
            }
            else
            {
                randomPointIndex = randomNumber;
            }
        }
        else
        {
            isPathPossible = true;
            isCalculated = true;
        }
    }

    void CheckPointPath(Transform point)
    {
        if (isCalculated == true)
        {
            NavMesh.CalculatePath(monster.transform.position, point.transform.position, -1, mainPath);
            isCalculated = false;
        }
    }

    public override void MonsterFollowsPoint()
    {
        if (isSawPlayer == false && isRayPlayer == false && isSawPlayer == false && monsterTime > 0)
        {
            switch (randomPointIndex)
            {
                case 0:
                    SetPoint(points[0]);
                    CheckPointPath(points[0]);
                    break;
                case 1:
                    SetPoint(points[1]);
                    CheckPointPath(points[1]);
                    break;
                case 2:
                    SetPoint(points[2]);
                    CheckPointPath(points[2]);
                    break;
                case 3:
                    SetPoint(points[3]);
                    CheckPointPath(points[3]);
                    break;
                case 4:
                    SetPoint(points[4]);
                    CheckPointPath(points[4]);
                    break;
                case 5:
                    SetPoint(points[5]);
                    CheckPointPath(points[5]);
                    break;
                case 6:
                    SetPoint(points[6]);
                    CheckPointPath(points[6]);
                    break;
                case 7:
                    SetPoint(points[7]);
                    CheckPointPath(points[7]);
                    break;
                case 8:
                    SetPoint(points[8]);
                    CheckPointPath(points[8]);
                    break;
                case 9:
                    SetPoint(points[9]);
                    CheckPointPath(points[9]);
                    break;
                case 10:
                    SetPoint(points[10]);
                    CheckPointPath(points[10]);
                    break;
                case 11:
                    SetPoint(points[11]);
                    CheckPointPath(points[11]);
                    break;
                case 12:
                    SetPoint(points[12]);
                    CheckPointPath(points[12]);
                    break;
                case 13:
                    SetPoint(points[13]);
                    CheckPointPath(points[13]);
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

        if ((isSawPlayer == true || isSawPlayer == true || isRayPlayer == true || firstRespawn == 1) && _distance >= 5 && isPathPossible == true && monsterTime > 0 && randomJumpscareScript.isPossibleTerrain == true)
        {
            monsterAgent.SetDestination(player.transform.position);
            monsterAgent.Resume();
            monsterAgent.updatePosition = true;
            monsterAgent.speed = runVelocity;
        }

        if (healthScript.health <= 0)
        {
            isSawPlayer = false;
            isRayPlayer = false;
            isSawPlayer = false;
        }
    }

    public override void MonsterLongLight(float _distance)
    {
        if (_distance <= 40 && Input.GetMouseButtonDown(2) && flashlightScript.isFlashlightOn == true && isSawPlayer == false && healthScript.health > 0)
        {
            isSawPlayer = true;
            monsterTime = 30f;
            firstRespawn = 0;
        }
        else if (_distance >= 50 && flashlightScript.isFlashlightOn == true && healthScript.health > 0)
        {
            isSawPlayer = false;
        }
        else if (_distance >= 40 && flashlightScript.isFlashlightOn == false)
        {
            isSawPlayer = false;
        }
        else if (_distance >= 30 && flashlightScript.isFlashlightOn == true && crouchScript.isCrouch == true)
        {
            isSawPlayer = false;
        }
        else if (_distance >= 20 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true)
        {
            isSawPlayer = false;
        }
    }

    public override void MonsterFlashlight(float _distance)
    {
        if (_distance <= 17 && isSawPlayer == false && flashlightScript.isFlashlightOn == true && healthScript.health > 0)
        {
            isSawPlayer = true;
            monsterTime = 30f;
            firstRespawn = 0;
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
            monsterTime = 30f;
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
                    firstRespawn = 0;
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
        if (_distance < 5 && healthScript.health > 0 && monsterTime > 0)
        {
            monsterAgent.SetDestination(player.transform.position);
            monsterAgent.updatePosition = true; 
            monsterAgent.Stop();
            monsterAgent.velocity = Vector3.zero;
            isSawPlayer = false;
            monsterAnimator.SetBool("Attack", true);
            monster.rotation = Quaternion.Slerp(monster.rotation, Quaternion.LookRotation(player.position - monster.position), rotationVelocity * Time.deltaTime);
        }
        else
        {
            monsterAnimator.SetBool("Attack", false);
        }
    }
}
