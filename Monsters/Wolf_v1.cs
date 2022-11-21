using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wolf_v1 : MonoBehaviour {

    public bool isPlaySound = false; 

    private Transform player;
    public Transform playerHead;
    private Transform wolf;
    public Animator wolfAnimator;
    private NavMeshAgent wolfAgent;
    public AudioSource audioSource;
    public AudioClip woflWalkSound;
    public AudioClip wolfRunSound;
    public AudioClip wolfHowlSound;
    public AudioClip wolfAttackSound;
    private CharacterController wolfController;
    private Flashlight flashlightScript;
    private Health healthScript;
    private Crouch crouchScript;
    private RandomJumpscare randomJumpscareScript;
    private Map mapScript;
    public NavMeshPath mainPath;
    public bool isPathPossible = true;

    public bool isHowl = false;
    public bool isHowlDone = false;
    public bool isRun = false;
    public float howlTimer = 0;

    private Transform monsterPoint1;
    private Transform monsterPoint2;
    private Transform monsterPoint3;
    private Transform monsterPoint4;
    private Transform monsterPoint5;

    public bool isPoint1 = true;
    public bool isPoint2 = false;
    public bool isPoint3 = false;
    public bool isPoint4 = false;
    public bool isPoint5 = false;

    public bool isSawPlayer = false;
    public bool isRayPlayer = false;
    public bool isSawLight = false;
    public bool isAttack = false;

    public float walkVelocity = 5f;
    public float runVelocity = 10f;

    public float currentVelocity = 4.0f;
    public float rotationVelocity = 5.0f;
    public float height = 0f;

    private Ray monsterAim;
    public float rayLength = 30f;

    public bool isFastTravel = false;

    void OnEnable()
    {

        player = GameObject.Find("Player").transform;
        wolf = GameObject.Find("Wilk_v1").transform;
        monsterPoint1 = GameObject.Find("Wilk1Punkt1").transform;
        monsterPoint2 = GameObject.Find("Wilk1Punkt2").transform;
        monsterPoint3 = GameObject.Find("Wilk1Punkt3").transform;
        monsterPoint4 = GameObject.Find("Wilk1Punkt4").transform;
        monsterPoint5 = GameObject.Find("Wilk1Punkt5").transform;
        //AnimatorMonster = GetComponent<Animator>();
        //KontrolerWilk = GetComponent<CharacterController>();
        flashlightScript = GameObject.Find("Latarka").GetComponent<Flashlight>();
        healthScript = player.GetComponent<Health>();
        crouchScript = player.GetComponent<Crouch>();
        randomJumpscareScript = player.GetComponent<RandomJumpscare>();
        mapScript = GameObject.Find("Player").GetComponent<Map>();
        playerHead = GameObject.Find("GraczGora").transform;
        wolfAgent = wolf.GetComponent<NavMeshAgent>();

        isPathPossible = true;
        mainPath = new NavMeshPath();

        isFastTravel = false;

    }


    void Update()
    {

        if(isHowl == true && howlTimer < 6)
        {
            howlTimer = howlTimer += 1 * Time.deltaTime;
        }
        else if(isHowl == true && howlTimer >= 6)
        {
            isHowl = false;
            wolfAnimator.SetBool("Punkt_ok", false);
            howlTimer = 0;
        }

        // czy mozliwa szybka podroz gracza

        if (isSawPlayer == false && isRayPlayer == false && isSawLight == false && isFastTravel == false)
        {
            mapScript.isFastTravel = true;
            isFastTravel = true;
        }

        //Ray MonsterAim = MonsterCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //Ray MonsterAim = new Ray(transform.position, transform.right);

            //AnimacjaMonster();
        float Dystans = Vector3.Distance(player.position, wolf.position);
        //Vector3 ruch = new Vector3(Wilk.forward.x, Wysokosc, Wilk.forward.z);
        //Debug.DrawRay(Wilk.transform.position, Wilk.transform.forward * RayLength, Color.green);
        //Debug.Log(Dystans);

        // sprawdzanie czy cel osiagalny 

        if ((mainPath.status == NavMeshPathStatus.PathInvalid || mainPath.status == NavMeshPathStatus.PathPartial))
        {

            isPathPossible = false;
            //Debug.Log("FAILED");

        }

        else

        {
            isPathPossible = true;
            //Debug.Log("SUCCESS");
        }

        // Podazanie potwora do odpowiednich punktow

        if ((isSawPlayer == false && isRayPlayer == false && isSawLight == false) || isPathPossible == false)
        {

            

            if (isPoint5 == true && isHowl == false)
            {

                wolfAgent.speed = walkVelocity;
                wolfAgent.SetDestination(monsterPoint5.transform.position);
                wolfAgent.Resume();
                wolfAgent.updatePosition = true;
            }

            else if (isPoint1 == true && isHowl == false)
            {

                wolfAgent.speed = walkVelocity;
                wolfAgent.SetDestination(monsterPoint1.transform.position);
                wolfAgent.Resume();
                wolfAgent.updatePosition = true;
            }

            else if (isPoint2 == true && isHowl == false)
            {

                wolfAgent.speed = walkVelocity;
                wolfAgent.SetDestination(monsterPoint2.transform.position);
                wolfAgent.Resume();
                wolfAgent.updatePosition = true;
            }

            else if (isPoint3 == true && isHowl == false)
            {

                wolfAgent.speed = walkVelocity;
                wolfAgent.SetDestination(monsterPoint3.transform.position);
                wolfAgent.Resume();
                wolfAgent.updatePosition = true;
            }

            else if (isPoint4 == true && isHowl == false)
            {

                wolfAgent.speed = walkVelocity;
                wolfAgent.SetDestination(monsterPoint4.transform.position);
                wolfAgent.Resume();
                wolfAgent.updatePosition = true;
            }

        }


        // Linie odpowiedzialne za podazanie przeciwnika za graczem

        // dlugie swiatlo latarki

        if (Dystans <= 40 && Input.GetMouseButtonDown(2) && flashlightScript.isFlashlightOn == true && isSawLight == false && healthScript.health > 0)
        {
            isSawLight = true;
            wolfAgent.speed = runVelocity;
        }
        else if (Dystans >= 50 && flashlightScript.isFlashlightOn == true && healthScript.health > 0)
        {
            isSawLight = false;
            wolfAnimator.SetBool("Widzi_ok", false);
            wolfAgent.speed = walkVelocity;

        }
        else if (Dystans >= 40 && flashlightScript.isFlashlightOn == false)
        {
            isSawLight = false;
            wolfAnimator.SetBool("Widzi_ok", false);
            wolfAgent.speed = walkVelocity;

        }
        else if (Dystans >= 30 && flashlightScript.isFlashlightOn == true && crouchScript.isCrouch == true)
        {
            isSawLight = false;
            wolfAnimator.SetBool("Widzi_ok", false);
            wolfAgent.speed = walkVelocity;

        }
        else if (Dystans >= 20 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true)
        {
            isSawLight = false;
            wolfAnimator.SetBool("Widzi_ok", false);
            wolfAgent.speed = walkVelocity;

        }

        // normalnie z latarka

        if (Dystans <= 25 && isSawPlayer == false && flashlightScript.isFlashlightOn == true && healthScript.health > 0)
        {
            isSawPlayer = true;
            wolfAgent.speed = runVelocity;
        }
        else if (Dystans > 40 && flashlightScript.isFlashlightOn == true && healthScript.health > 0)
        {
            isSawPlayer = false;
            wolfAnimator.SetBool("Widzi_ok", false);
            wolfAgent.speed = walkVelocity;
        }
        else if (Dystans > 30 && flashlightScript.isFlashlightOn == false)
        {
            isSawPlayer = false;
            wolfAnimator.SetBool("Widzi_ok", false);
            wolfAgent.speed = walkVelocity;
        }
        else if (Dystans > 13 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true)
        {
            isSawPlayer = false;
            wolfAnimator.SetBool("Widzi_ok", false);
            wolfAgent.speed = walkVelocity;
        }

        // Bez wlaczonej latarki

        if (Dystans <= 11 && flashlightScript.isFlashlightOn == false && isSawPlayer == false && healthScript.health > 0)
        {
            isSawPlayer = true;
            wolfAgent.speed = runVelocity;
        }

        // gracz w zasiegu wzroku

        

        if (Dystans <= 25 && isRayPlayer == false && healthScript.health > 0)
        {
            RaycastHit hit;

            if (Physics.Raycast(wolf.transform.position, wolf.transform.forward, out hit, rayLength, 1 << 10))
            {

                if(hit.collider.gameObject.name == "Player")
                {
                    isRayPlayer = true;
                    wolfAgent.speed = runVelocity;
                    Debug.Log("Wykryl");
                }
                
            }
           
        }

        else if (Dystans > 40)
        {
            isRayPlayer = false;
            wolfAnimator.SetBool("Widzi_ok", false);
            wolfAgent.speed = walkVelocity;
        }

        // kalkulowanie czy podazac za graczem

        if(isSawLight == true || isSawPlayer == true || isRayPlayer == true)
        {
            NavMesh.CalculatePath(wolf.transform.position, player.transform.position, -1, mainPath);
        }

        // podazanie za graczem

        if ((isSawLight == true || isSawPlayer == true || isRayPlayer == true) && Dystans >= 7 && isPathPossible == true)
        {
            isHowl = false;
            wolfAnimator.SetBool("Widzi_ok", true);
            wolfAnimator.SetBool("Punkt_ok", false);
            wolfAgent.SetDestination(player.transform.position);
            wolfAgent.Resume();
            wolfAgent.updatePosition = true;
            mapScript.isFastTravel = false;
            isFastTravel = false;
        }

        // atak wilka

        if (Dystans < 7 && healthScript.health > 0)
        {
            wolfAgent.Stop();
            wolfAgent.velocity = Vector3.zero;
            isSawLight = false;
            wolfAgent.speed = runVelocity;
            wolfAnimator.SetBool("Atak_ok", true);
            wolfAgent.updatePosition = true; // bylo na false
            wolf.rotation = Quaternion.Slerp(wolf.rotation, Quaternion.LookRotation(player.position - wolf.position), rotationVelocity * Time.deltaTime);
            mapScript.isFastTravel = false;
            isFastTravel = false;
        }
        else
        {
            wolfAnimator.SetBool("Atak_ok", false);
        }

        // dzwiek ataku wilka

        if(Dystans < 8 && isAttack == false)
        {
            audioSource.clip = wolfAttackSound;
            audioSource.Play();
            isAttack = true;
            isRun = false;

        } else if (Dystans >= 8 && isAttack == true)
        {
            audioSource.clip = wolfRunSound;
            audioSource.Play();
            isAttack = false;
        }

        // dzwiek biegu wilka

        if((isSawPlayer == true || isRayPlayer == true || isSawLight == true) && Dystans > 9 && isRun == false)
        {
            audioSource.clip = wolfRunSound;
            audioSource.Play();
            isRun = true;

        } else if ((isSawPlayer == false && isRayPlayer == false && isSawLight == false) && isRun == true)
        {
            audioSource.clip = woflWalkSound;
            audioSource.Play();
            isRun = false;
        }

        // dzwiek wycie wilka

        if(isHowl == true && isHowlDone == false)
        {
            audioSource.clip = wolfHowlSound;
            audioSource.Play();
            isHowlDone = true;

        } else if (isHowl == false && isHowlDone == true)
        {
            audioSource.clip = woflWalkSound;
            audioSource.Play();
            isHowlDone = false;
        }

        // smierc gracza

        if (healthScript.health <= 0)
        {
            isSawPlayer = false;
            isRayPlayer = false;
            isSawLight = false;
            wolfAnimator.SetBool("Widzi_ok", false);
            wolfAgent.speed = walkVelocity;
        }

        // gracz na bezpiecznym terenie

      

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
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wilk1Punkt1")
        { //1.58
            isPoint1 = false;
            isPoint2 = true;
            isHowl = true;
            wolfAnimator.SetBool("Punkt_ok", true);
        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wilk1Punkt2")
        {
            isPoint2 = false;
            isPoint3 = true;
            isHowl = true;
            wolfAnimator.SetBool("Punkt_ok", true);
        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wilk1Punkt3")
        {
            isPoint3 = false;
            isPoint4 = true;
            isHowl = true;
            wolfAnimator.SetBool("Punkt_ok", true);
        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wilk1Punkt4")
        {
            isPoint4 = false;
            isPoint5 = true;
            isHowl = true;
            wolfAnimator.SetBool("Punkt_ok", true);
        }

        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Wilk1Punkt5")
        {
            isPoint5 = false;
            isPoint1 = true;
            isHowl = true;
            wolfAnimator.SetBool("Punkt_ok", true);
        }

    }


}
