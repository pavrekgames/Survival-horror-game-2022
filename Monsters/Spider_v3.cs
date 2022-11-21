using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider_v3 : MonoBehaviour {

    public bool isPlaySound = false; 

    private Transform player;
    public Transform playerHead;
    private Transform spider;
    public Animator spideranimator;
    private NavMeshAgent spiderAgent;
    public AudioSource audioSource;
    public AudioClip spiderWalkSound;
    public AudioClip spiderRunSound;
    public AudioClip spiderAttackSound;
    private CharacterController spiderController;
    private Flashlight flashlihtScript;
    private Health healthScript;
    private Crouch crouchScript;
    private Map mapScript;
    public NavMeshPath mainPath;
    public bool isPathPossible = true;

    public bool isRun = false;

    private Transform monsterPoint1;
    private Transform monsterPoint2;
    private Transform monsterPoint3;

    public bool isPoint1 = true;
    public bool isPoint2 = false;
    public bool isPoint3 = false;

    public bool isSawPlayer = false;
    public bool isRayPlayer = false;
    public bool isSawLight = false;
    public bool isAttack = false;

    public bool isSpiderOff = false;
    public bool isSpiderOffConfirmed = false;

    public float walkVelocity = 5f;
    public float runVelocity = 10f;

    public float currentVelocity = 4.0f;
    public float rotationVelocity = 5.0f;
    public float height = 0f;

    private Ray monsterAim;
    public float rayLength = 30f;



    void Start()
    {

        player = GameObject.Find("Player").transform;
        spider = GameObject.Find("Pajak_v3").transform;
        monsterPoint1 = GameObject.Find("Pajak3Punkt1").transform;
        monsterPoint2 = GameObject.Find("Pajak3Punkt2").transform;
        monsterPoint3 = GameObject.Find("Pajak3Punkt3").transform;
        //AnimatorMonster = GetComponent<Animator>();
        //KontrolerWilk = GetComponent<CharacterController>();
        flashlihtScript = GameObject.Find("Latarka").GetComponent<Flashlight>();
        healthScript = player.GetComponent<Health>();
        crouchScript = player.GetComponent<Crouch>();
        mapScript = GameObject.Find("Player").GetComponent<Map>();
        playerHead = GameObject.Find("GraczGora").transform;
        spiderAgent = spider.GetComponent<NavMeshAgent>();
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

        //Ray MonsterAim = MonsterCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //Ray MonsterAim = new Ray(transform.position, transform.right);

        //AnimacjaMonster();
        float Dystans = Vector3.Distance(player.position, spider.position);
        mapScript.isFastTravel = false;
        //Vector3 ruch = new Vector3(Pajak.forward.x, Wysokosc, Pajak.forward.z);
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

        // Wylaczanie pajaka

        if (isSpiderOff == true && isSpiderOffConfirmed == false)
        {

            isSawPlayer = false;
            isRayPlayer = false;
            isSawLight = false;
            spideranimator.SetBool("Widzi_ok", true);
            spideranimator.SetBool("Atak_ok", false);
            isSpiderOffConfirmed = true;
            spiderAgent.speed = runVelocity;
            spiderAgent.SetDestination(monsterPoint2.transform.position);
            spiderAgent.Resume();
            spiderAgent.updatePosition = true;

        }

        // podazanie pajaka do punktow

        if ((isSawPlayer == false && isRayPlayer == false && isSawLight == false && isSpiderOff == false) || isPathPossible == false) {

            if (isPoint3 == true)
            {

                spiderAgent.speed = walkVelocity;
                spiderAgent.SetDestination(monsterPoint3.transform.position);
                spiderAgent.Resume();
                spiderAgent.updatePosition = true;
            }

            else if (isPoint1 == true)
            {

                spiderAgent.speed = walkVelocity;
                spiderAgent.SetDestination(monsterPoint1.transform.position);
                spiderAgent.Resume();
                spiderAgent.updatePosition = true;
            }

            else if (isPoint2 == true)
            {

                spiderAgent.speed = walkVelocity;
                spiderAgent.SetDestination(monsterPoint2.transform.position);
                spiderAgent.Resume();
                spiderAgent.updatePosition = true;
            }

        }

        // Linie odpowiedzialne za podazanie przeciwnika za graczem

        // dlugie swiatlo latarki

        if (Dystans <= 40 && Input.GetMouseButtonDown(2) && flashlihtScript.isFlashlightOn == true && isSawLight == false && healthScript.health > 0 && isSpiderOff == false)
        {
            isSawLight = true;
            spiderAgent.speed = runVelocity;
        }
        else if (Dystans >= 50 && flashlihtScript.isFlashlightOn == true && healthScript.health > 0 && isSpiderOff == false)
        {
            isSawLight = false;
            spideranimator.SetBool("Widzi_ok", false);

        }
        else if (Dystans >= 40 && flashlihtScript.isFlashlightOn == false && isSpiderOff == false)
        {
            isSawLight = false;
            spideranimator.SetBool("Widzi_ok", false);

        }
        else if (Dystans >= 30 && flashlihtScript.isFlashlightOn == true && crouchScript.isCrouch == true && isSpiderOff == false)
        {
            isSawLight = false;
            spideranimator.SetBool("Widzi_ok", false);

        }
        else if (Dystans >= 20 && flashlihtScript.isFlashlightOn == false && crouchScript.isCrouch == true && isSpiderOff == false)
        {
            isSawLight = false;
            spideranimator.SetBool("Widzi_ok", false);

        }

        // normalnie z latarka

        if (Dystans <= 25 && isSawPlayer == false && flashlihtScript.isFlashlightOn == true && healthScript.health > 0 && isSpiderOff == false)
        {
            isSawPlayer = true;
            spiderAgent.speed = runVelocity;
        }
        else if (Dystans > 40 && flashlihtScript.isFlashlightOn == true && healthScript.health > 0 && isSpiderOff == false)
        {
            isSawPlayer = false;
            spideranimator.SetBool("Widzi_ok", false);
        }
        else if (Dystans > 30 && flashlihtScript.isFlashlightOn == false && isSpiderOff == false)
        {
            isSawPlayer = false;
            spideranimator.SetBool("Widzi_ok", false);
        }
        else if (Dystans > 13 && flashlihtScript.isFlashlightOn == false && crouchScript.isCrouch == true && isSpiderOff == false)
        {
            isSawPlayer = false;
            spideranimator.SetBool("Widzi_ok", false);
        }

        // Bez wlaczonej latarki

        if (Dystans <= 11 && flashlihtScript.isFlashlightOn == false && isSawPlayer == false && healthScript.health > 0 && isSpiderOff == false)
        {
            isSawPlayer = true;
            spiderAgent.speed = runVelocity;
        }

        // gracz w zasiegu wzroku

        if (Dystans <= 25 && isRayPlayer == false && healthScript.health > 0 && isSpiderOff == false)
        {
            RaycastHit hit;

            if (Physics.Raycast(spider.transform.position, spider.transform.forward, out hit, rayLength, 1 << 10))
            {

                if (hit.collider.gameObject.name == "Player")
                {
                    isRayPlayer = true;
                    spiderAgent.speed = runVelocity;
                    Debug.Log("Wykryl");
                }

            }

        }

        else if (Dystans > 40)
        {
            isRayPlayer = false;
            spideranimator.SetBool("Widzi_ok", false);
        }

        // kalkulowanie czy podazac za graczem

        if (isSawLight == true || isSawPlayer == true || isRayPlayer == true)
        {
            NavMesh.CalculatePath(spider.transform.position, player.transform.position, -1, mainPath);
        }

        // podazanie za graczem

        if ((isSawLight == true || isSawPlayer == true || isRayPlayer == true) && Dystans >= 5 && isPathPossible == true && isSpiderOff == false)
        {
            spideranimator.SetBool("Widzi_ok", true);
            spideranimator.SetBool("Punkt_ok", false);
            spiderAgent.SetDestination(player.transform.position);
            spiderAgent.Resume();
            spiderAgent.updatePosition = true;
        }

        // atak pajaka

        if (Dystans < 5 && healthScript.health > 0 && isSpiderOff == false)
        {
            spiderAgent.Stop();
            spiderAgent.velocity = Vector3.zero;
            isSawLight = false;
            spiderAgent.speed = runVelocity;
            spideranimator.SetBool("Atak_ok", true);
            spiderAgent.updatePosition = true; // bylo na false
            spider.rotation = Quaternion.Slerp(spider.rotation, Quaternion.LookRotation(player.position - spider.position), rotationVelocity * Time.deltaTime);
        }
        else
        {
            spideranimator.SetBool("Atak_ok", false);
        }

        // dzwiek ataku pajaka

        if (Dystans < 6 && isAttack == false && healthScript.health > 0)
        {
            audioSource.clip = spiderAttackSound;
            audioSource.pitch = 1;
            audioSource.Play();
            isAttack = true;
            isRun = false;

        }
        else if (Dystans >= 6 && isAttack == true && healthScript.health > 0)
        {
            audioSource.clip = spiderRunSound;
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.Play();
            isAttack = false;
        }

        // dzwiek biegu pajaka

        if ((isSawPlayer == true || isRayPlayer == true || isSawLight == true) && Dystans > 7 && isRun == false)
        {
            audioSource.clip = spiderRunSound;
            audioSource.pitch = Random.Range(0.8f, 1.5f);
            audioSource.Play();
            isRun = true;

        }
        else if ((isSawPlayer == false && isRayPlayer == false && isSawLight == false) && isRun == true)
        {
            audioSource.clip = spiderWalkSound;
            audioSource.pitch = 1;
            audioSource.Play();
            isRun = false;
        }

        // smierc gracza

        if (healthScript.health <= 0)
        {
            isSawPlayer = false;
            isRayPlayer = false;
            isSawLight = false;
            spideranimator.SetBool("Widzi_ok", false);
            spiderAgent.speed = walkVelocity;
            isAttack = false;
            spideranimator.SetBool("Atak_ok", false);
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
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Pajak3Punkt1")
        {
            isPoint1 = false;
            isPoint2 = true;
        }

       else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Pajak3Punkt2" && isSpiderOff == false)
        {
            isPoint2 = false;
            isPoint3 = true;
        }

       else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Pajak3Punkt3")
        {
            isPoint3 = false;
            isPoint1 = true;
        }

       else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Pajak3Punkt2" && isSpiderOff == true)
        {
            spider.gameObject.SetActive(false);
            spider.gameObject.GetComponent<Spider_v3>().enabled = false;
            mapScript.isFastTravel = true;
        }

    }


}
