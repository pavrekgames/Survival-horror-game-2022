using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMonster2 : MonoBehaviour {

    public bool isPlaySound = false; 

    private Transform player;
    public Transform playerHead;
    private Transform monster;
    public NavMeshAgent monsterAgent;
    public AudioSource audioSource;
    private SkinnedMeshRenderer monsterMesh;
    private Transform point1;
    private Transform point2;
    private Transform point3;
    private Transform point4;
    private Transform point5;
    private Transform point6;
    private Transform point7;
    private Transform point8;
    private Transform point9;
    private Transform point10;
    private Transform point11;
    private Transform point12;
    private Transform point13;
    private Transform point14;

    public Animator monsterAnimator;
    private CharacterController monsterController;
    private Health healthScript;
    private Flashlight flashlightScript;
    private Crouch crouchScript;
    private RandomJumpscare randomJumpscareScript;
    private Map mapScript;

    public NavMeshPath mainPath;
    public bool isPathPossible = false;
    public int randomNumber;
    public int randomPointIndex;
    public float monsterTime = 30f;
    public bool isCalculated = true;

    public float walkVelocity = 5f;
    public float runVelocity = 8f;

    public float currentVelocity = 7.0f;
    public float rotationVelocity = 5.0f;
    public float height = 0f;

    public bool isSawPlayer = false;
    public bool isRayPlayer = false;
    public bool isSawLight = false;
    public int firstRespawn = 0;

    private Ray monsterAim;
    public float rayLength = 30f;


    void OnEnable()
    {

        player = GameObject.Find("Player").transform;
        monster = GameObject.Find("Monster1_Losowy2").transform;
        point1 = GameObject.Find("MonsterPotokPunkt").transform;
        point2 = GameObject.Find("MonsterPunkt1").transform;
        point3 = GameObject.Find("Monster3Punkt1").transform;
        point4 = GameObject.Find("MonsterDyniaPunkt1").transform;
        point5 = GameObject.Find("Monster5Punkt1").transform;
        point6 = GameObject.Find("Wilk1Punkt5").transform;
        point7 = GameObject.Find("Wilk2Punkt3").transform;
        point8 = GameObject.Find("Wilk3Punkt1").transform;
        point9 = GameObject.Find("Monster3Punkt2").transform;
        point10 = GameObject.Find("MonsterRoslinaPunkt").transform;
        point11 = GameObject.Find("MonsterDyniaPunkt3").transform;
        point12 = GameObject.Find("Wilk1Punkt4").transform;
        point13 = GameObject.Find("Wilk2Punkt2").transform;
        point14 = GameObject.Find("Wilk3Punkt2").transform;

        monsterController = GetComponent<CharacterController>();
        healthScript = player.GetComponent<Health>();
        playerHead = GameObject.Find("GraczGora").transform;
        flashlightScript = GameObject.Find("Latarka").GetComponent<Flashlight>();
        crouchScript = player.GetComponent<Crouch>();
        randomJumpscareScript = player.GetComponent<RandomJumpscare>();
        mapScript = GameObject.Find("Player").GetComponent<Map>();
        monsterMesh = GameObject.Find("Monster1_Losowy2_mesh").GetComponent<SkinnedMeshRenderer>();

        randomPointIndex = 0;
        monsterTime = 30f;
        firstRespawn = Random.Range(0, 2);

        isPathPossible = false;
        mainPath = new NavMeshPath();
        isCalculated = true;

        if (isSawPlayer == false && isSawLight == false && isRayPlayer == false && randomPointIndex == 0)
        {
            randomPointIndex = Random.Range(1, 15);
        }

    }


    void Update()
    {

        //Vector3 ruch = new Vector3(Monster.forward.x, Wysokosc, Monster.forward.z);

        runVelocity = Random.Range(10, 13);
        mapScript.isFastTravel = false;

        // kalkulowanie sciezki gdy widzi gracza

        if (isSawLight == true || isSawPlayer == true || isRayPlayer == true)
        {
            NavMesh.CalculatePath(monster.transform.position, player.transform.position, -1, mainPath);
        }

        // kalkulowanie sciezki dla puntktow gdy nie widzi gracza

        if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 1)
        {
            NavMesh.CalculatePath(monster.transform.position, point1.transform.position, -1, mainPath);
            isCalculated = false;
        }

        else if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 2)
        {
            NavMesh.CalculatePath(monster.transform.position, point2.transform.position, -1, mainPath);
            isCalculated = false;
        }

        else if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 3)
        {
            NavMesh.CalculatePath(monster.transform.position, point3.transform.position, -1, mainPath);
            isCalculated = false;
        }

        else if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 4)
        {
            NavMesh.CalculatePath(monster.transform.position, point4.transform.position, -1, mainPath);
            isCalculated = false;
        }

        else if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 5)
        {
            NavMesh.CalculatePath(monster.transform.position, point5.transform.position, -1, mainPath);
            isCalculated = false;
        }

        else if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 6)
        {
            NavMesh.CalculatePath(monster.transform.position, point6.transform.position, -1, mainPath);
            isCalculated = false;
        }

        else if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 7)
        {
            NavMesh.CalculatePath(monster.transform.position, point7.transform.position, -1, mainPath);
            isCalculated = false;
        }

        else if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 8)
        {
            NavMesh.CalculatePath(monster.transform.position, point8.transform.position, -1, mainPath);
            isCalculated = false;
        }

        else if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 9)
        {
            NavMesh.CalculatePath(monster.transform.position, point9.transform.position, -1, mainPath);
            isCalculated = false;
        }

        else if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 10)
        {
            NavMesh.CalculatePath(monster.transform.position, point10.transform.position, -1, mainPath);
            isCalculated = false;
        }

        else if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 11)
        {
            NavMesh.CalculatePath(monster.transform.position, point11.transform.position, -1, mainPath);
            isCalculated = false;
        }

        else if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 12)
        {
            NavMesh.CalculatePath(monster.transform.position, point12.transform.position, -1, mainPath);
            isCalculated = false;
        }

        else if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 13)
        {
            NavMesh.CalculatePath(monster.transform.position, point13.transform.position, -1, mainPath);
            isCalculated = false;
        }

        else if (isSawLight == false && isSawPlayer == false && isRayPlayer == false && isCalculated == true && randomPointIndex == 14)
        {
            NavMesh.CalculatePath(monster.transform.position, point14.transform.position, -1, mainPath);
            isCalculated = false;
        }

        // sprawdzanie czy cel osiagalny 

        if ((mainPath.status == NavMeshPathStatus.PathInvalid || mainPath.status == NavMeshPathStatus.PathPartial) && isCalculated == false)
        {
            isPathPossible = false;
            isCalculated = true;
            randomNumber = Random.Range(1, 15);

            if (randomNumber == randomPointIndex && randomNumber < 14)
            {
                randomPointIndex = randomNumber + 1;
            }
            else if (randomNumber == randomPointIndex && randomNumber == 14)
            {
                randomPointIndex = randomNumber - 1;
            }
            else
            {
                randomPointIndex = randomNumber;
            }

            //Debug.Log("Sciezka_FAILED");
        }
        else
        {
            isPathPossible = true;
            isCalculated = true;
            //Debug.Log("Sciezka_SUCCESS");
        }


        // podazanie potwora do punktow

        if (isSawPlayer == false && isRayPlayer == false && isSawLight == false && monsterTime > 0) {

            if (randomPointIndex == 1)
            {
                monsterAgent.SetDestination(point1.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                //Debug.Log("Puntk1_!!!");
            }

            else if (randomPointIndex == 2)
            {
                monsterAgent.SetDestination(point2.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                // Debug.Log("Puntk2_!!!");
            }

            else if (randomPointIndex == 3)
            {
                monsterAgent.SetDestination(point3.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                //Debug.Log("Puntk3_!!!");
            }

            else if (randomPointIndex == 4)
            {
                monsterAgent.SetDestination(point4.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                //Debug.Log("Puntk4_!!!");
            }

            else if (randomPointIndex == 5)
            {
                monsterAgent.SetDestination(point5.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                //Debug.Log("Puntk5_!!!");
            }

            else if (randomPointIndex == 6)
            {
                monsterAgent.SetDestination(point6.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                //Debug.Log("Punkt6_!!!");
            }

            else if (randomPointIndex == 7)
            {
                monsterAgent.SetDestination(point7.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                // Debug.Log("Puntk7_!!!");
            }

            else if (randomPointIndex == 8)
            {
                monsterAgent.SetDestination(point8.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                //Debug.Log("Puntk8_!!!");
            }

            else if (randomPointIndex == 9)
            {
                monsterAgent.SetDestination(point9.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                //Debug.Log("Puntk9_!!!");
            }

            else if (randomPointIndex == 10)
            {
                monsterAgent.SetDestination(point10.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                //Debug.Log("Puntk10_!!!");
            }

            else if (randomPointIndex == 11)
            {
                monsterAgent.SetDestination(point11.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                //Debug.Log("Puntk11_!!!");
            }

            else if (randomPointIndex == 12)
            {
                monsterAgent.SetDestination(point12.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                //Debug.Log("Puntk12_!!!");
            }

            else if (randomPointIndex == 13)
            {
                monsterAgent.SetDestination(point13.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                //Debug.Log("Puntk13_!!!");
            }

            else if (randomPointIndex == 14)
            {
                monsterAgent.SetDestination(point14.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                //Debug.Log("Puntk14_!!!");
            }

        }

        // czas istnienia potwora

        if (isSawPlayer == false && isSawLight == false && isRayPlayer == false)
        {
            monsterTime -= 1 * Time.deltaTime;
        }

        if (monsterTime <= 0 || randomJumpscareScript.isPossibleTerrain == false)
        {
            monsterMesh.enabled = false;
            audioSource.enabled = false;
            monster.gameObject.SetActive(false);
            monster.gameObject.GetComponent<RandomMonster2>().enabled = false;
            mapScript.isFastTravel = true;
        }

        //Ray MonsterAim = MonsterCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //Ray MonsterAim = new Ray(transform.position, transform.right);

        float Dystans = Vector3.Distance(player.position, monster.position);
        //Debug.DrawRay(Monster.transform.position, Monster.transform.forward * RayLength, Color.green);

        if (!monsterController.isGrounded)
        { // odpowiada za to ze przeciwnik nie lata
            height += Physics.gravity.y * Time.deltaTime;
        }

        // Linie odpowiedzialne za podazanie przeciwnika za graczem

        if (Dystans <= 40 && Input.GetMouseButtonDown(2) && flashlightScript.isFlashlightOn == true && isSawLight == false && healthScript.health > 0)
        {
            isSawLight = true;
            monsterTime = 30f;
            firstRespawn = 0;
        }
        else if (Dystans >= 50 && flashlightScript.isFlashlightOn == true && healthScript.health > 0)
        {
            isSawLight = false;
        }
        else if (Dystans >= 40 && flashlightScript.isFlashlightOn == false)
        {
            isSawLight = false;
        }
        else if (Dystans >= 30 && flashlightScript.isFlashlightOn == true && crouchScript.isCrouch == true)
        {
            isSawLight = false;
        }
        else if (Dystans >= 20 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true)
        {
            isSawLight = false;
        }

        // normalnie z latarka

        if (Dystans <= 17 && isSawPlayer == false && flashlightScript.isFlashlightOn == true && healthScript.health > 0)
        {
            isSawPlayer = true;
            monsterTime = 30f;
            firstRespawn = 0;
        }
        else if (Dystans > 30 && flashlightScript.isFlashlightOn == true && healthScript.health > 0)
        {
            isSawPlayer = false;
        }
        else if (Dystans > 20 && flashlightScript.isFlashlightOn == false)
        {
            isSawPlayer = false;
        }
        else if (Dystans > 13 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true)
        {
            isSawPlayer = false;
        }

        // Bez wlaczonej latarki

        if (Dystans <= 11 && flashlightScript.isFlashlightOn == false && isSawPlayer == false && healthScript.health > 0)
        {
            isSawPlayer = true;
            monsterTime = 30f;
        }

        // gracz w zasiegu wzroku

        if (Dystans <= 25 && isRayPlayer == false && healthScript.health > 0)
        {
            RaycastHit hit;

            if (Physics.Raycast(monster.transform.position, monster.transform.forward, out hit, rayLength, 1 << 10))
            {

                if (hit.collider.gameObject.name == "Player")
                {
                    isRayPlayer = true;
                    Debug.Log("Wykryl");
                    firstRespawn = 0;
                }

            }

        }

        else if (Dystans > 40)
        {
            isRayPlayer = false;
            //AnimatorMonster.SetBool("Widzi_ok", false);
        }

        // podazanie za graczem

        if ((isSawLight == true || isSawPlayer == true || isRayPlayer == true || firstRespawn == 1) && Dystans >= 5 && isPathPossible == true && monsterTime > 0 && randomJumpscareScript.isPossibleTerrain == true)
        {
            monsterAgent.SetDestination(player.transform.position);
            monsterAgent.Resume();
            monsterAgent.updatePosition = true;
            monsterAgent.speed = runVelocity;
        }

        // atak potwora

        if (Dystans < 5 && healthScript.health > 0 && monsterTime > 0)
        {
            monsterAgent.SetDestination(player.transform.position);
            monsterAgent.updatePosition = true; // bylo na false
            monsterAgent.Stop();
            monsterAgent.velocity = Vector3.zero;
            isSawLight = false;
            monsterAnimator.SetBool("Atak_ok", true);
            monster.rotation = Quaternion.Slerp(monster.rotation, Quaternion.LookRotation(player.position - monster.position), rotationVelocity * Time.deltaTime); 
        }
        else
        {
            monsterAnimator.SetBool("Atak_ok", false);
        }

        // smierc gracza

        if (healthScript.health <= 0)
        {
            isSawPlayer = false;
            isRayPlayer = false;
            isSawLight = false;
        }

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
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPotokPunkt") // 1
        {

            randomPointIndex = 3;

        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster6Punkt1") // 2
        {
            randomNumber = Random.Range(1, 15);

            if (randomNumber == randomPointIndex)
            {
                randomPointIndex = randomNumber + 1;
            }
            else
            {
                randomPointIndex = randomNumber;
            }

        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterKorytoPunkt")  // 3
        {

            randomPointIndex = 10;

        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterDyniaPunkt1") // 4
        {

            randomPointIndex = 11;

        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster5Punkt1") // 5
        {

            randomPointIndex = 4;

        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wilk1Punkt5") // 6
        {

            randomPointIndex = 12;

        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wilk2Punkt3") // 7
        {

            randomPointIndex = 13;

        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wilk3Punkt1") // 8
        {

            randomPointIndex = 14;

        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster3Punkt2") // 9
        {
            randomNumber = Random.Range(1, 15);

            if (randomNumber == randomPointIndex)
            {
                randomPointIndex = randomNumber + 1;
            }
            else
            {
                randomPointIndex = randomNumber;
            }

        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterRoslinaPunkt") // 10
        {

            randomPointIndex = 13;

        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterDyniaPunkt3") // 11
        {

            randomPointIndex = 4;

        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wilk1Punkt4") // 12
        {

            randomPointIndex = 6;

        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wilk2Punkt2") // 13
        {

            randomPointIndex = 7;

        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wilk3Punkt2") // 14
        {

            randomPointIndex = 8;

        }

    }


}
