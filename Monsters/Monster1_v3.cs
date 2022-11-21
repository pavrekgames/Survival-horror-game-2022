using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster1_v3 : MonoBehaviour {

    public bool isPlaySound = false; 

    private Transform player;
	public Transform playerHead;
	private Transform monster;
	public Animator monsterAnimator;
	public AudioSource audioSource;
	public AudioClip monsterSound;
	public AudioClip monsterAttackSound;
	private CharacterController monsterController;
	private Flashlight flashlightScript;
	private Health healthScript;
	private TaskMeat taskMeatScript;
    private Crouch crouchScript;
    private Map mapScript;
    private NavMeshAgent monsterAgent;
    public NavMeshPath mainPath;
    public bool isPathPossible = true;

    private Transform monsterPoint1;

    public bool isSawPlayer = false;
	public bool isRayPlayer = false;
	public bool isSawLight = false;
	public bool isAttack = false;

    public float walkVelocity = 6f;
    public float runVelocity = 9f;

    public float currentVelocity = 5.0f;
	public float rotationVelocity = 5.0f;
	public float height  = 0f;

	public bool isSeeMeat1 = false;
	public bool isSeeMeat2 = false;
	public bool isSeeMeat3 = false;
	public bool isAteMeat1 = false;
	public bool isAteMeat2 = false;
	public bool isAteMeat3 = false;
    public Transform meat1;
    public Transform meat2;
    public Transform meat3;

	private Ray monsterAim;
	public float rayLength = 30f;



	void OnEnable () {

		player = GameObject.Find("Player").transform;
		monster = GameObject.Find("Monster1_v3").transform;
		//AnimatorMonster = GetComponent<Animator>();
		monsterController = GetComponent<CharacterController>();
		flashlightScript = GameObject.Find ("Latarka").GetComponent<Flashlight> ();
		healthScript = player.GetComponent<Health>();
		taskMeatScript = player.GetComponent<TaskMeat>();
        crouchScript = player.GetComponent<Crouch>();
        mapScript = GameObject.Find("Player").GetComponent<Map>();
        //Mieso1 = GameObject.Find("MiesoDlaPotwora1").transform;
        //Mieso2 = GameObject.Find("MiesoDlaPotwora2").transform;
        //Mieso3 = GameObject.Find("MiesoDlaPotwora3").transform;
        playerHead = GameObject.Find ("GraczGora").transform;
        monsterPoint1 = GameObject.Find("Monster6Punkt1").transform;
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

		//Ray MonsterAim = MonsterCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		//Ray MonsterAim = new Ray(transform.position, transform.right);

		//AnimacjaMonster();
		float Dystans = Vector3.Distance(player.position, monster.position);
        mapScript.isFastTravel = false;

        //Vector3 ruch = new Vector3(Monster.forward.x, Wysokosc, Monster.forward.z);
        //Debug.DrawRay(Monster.transform.position, Monster.transform.forward * RayLength, Color.green);

        runVelocity = Random.Range(8, 12);

        // sprawdzanie czy cel osiagalny 

        NavMesh.CalculatePath(monster.transform.position, player.transform.position, -1, mainPath);

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


        if (!monsterController.isGrounded){ // odpowiada za to ze przeciwnik nie lata
			height += Physics.gravity.y * Time.deltaTime;
		}

        // Linie odpowiedzialne za podazanie przeciwnika za graczem

        if (isPathPossible == true)
        {

            if (Dystans <= 40 && Input.GetMouseButtonDown(2) && flashlightScript.isFlashlightOn == true && isSawLight == false && healthScript.health > 0)
            {
                isSawLight = true;
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

            if (((Dystans <= 17 && flashlightScript.isFlashlightOn == true) || (Dystans <= 26 && Input.GetKey("left shift"))) && isSawPlayer == false && healthScript.health > 0)
            {
                isSawPlayer = true;
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
                    }

                }

            }

            else if (Dystans > 40)
            {
                isRayPlayer = false;
            }

            // podazanie za graczem

            if ((isSawLight == true || isSawPlayer == true || isRayPlayer == true) && Dystans >= 5 && isSeeMeat1 == false && isSeeMeat2 == false && isSeeMeat3 == false)
            {
                monsterAgent.SetDestination(player.transform.position);
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                monsterAgent.speed = runVelocity;
                monsterAnimator.SetBool("Widzi_ok", true);
            }

            // atak potwora

            if (Dystans < 5 && healthScript.health > 0)
            {
                monsterAgent.Stop();
                monsterAgent.velocity = Vector3.zero;
                isSawLight = false;
                monsterAnimator.SetBool("Atak_ok", true);
                monsterAgent.updatePosition = true;
                monsterAgent.SetDestination(player.transform.position);
                monster.rotation = Quaternion.Slerp(monster.rotation, Quaternion.LookRotation(player.position - monster.position), rotationVelocity * Time.deltaTime);
            }
            else if ((Dystans >= 5 && healthScript.health > 0) || healthScript.health <= 0)
            {
                monsterAnimator.SetBool("Atak_ok", false);
            }

        }else
        {
            monsterAgent.SetDestination(monsterPoint1.transform.position);
            monsterAgent.speed = walkVelocity;
            monsterAgent.Resume();
            monsterAgent.updatePosition = true;
            monsterAnimator.SetBool("Widzi_ok", false);
        }

        // smierc gracza

        if (healthScript.health <= 0){
			isSawPlayer = false;
			isRayPlayer = false;
			isSawLight = false;
			monsterAnimator.SetBool("Widzi_ok", false);
            isAttack = false;
            monsterAnimator.SetBool("Atak_ok", false);
        }

		if(isSawPlayer == false && isSawLight == false && isRayPlayer == false){
			monsterAnimator.SetBool("Widzi_ok", false);
		}

        // dzwiek ataku potwora

        if (Dystans < 8 && isAttack == false && healthScript.health > 0 && isSeeMeat1 == false && isSeeMeat2 == false && isSeeMeat3 == false){
            audioSource.pitch = Random.Range(0.8f, 1.1f);
            audioSource.clip = monsterAttackSound;
			audioSource.Play();
			isAttack = true;
		}else if((Dystans >= 8 && isAttack == true) || healthScript.health <= 0){
            audioSource.pitch = 1;
            audioSource.clip = monsterSound;
			audioSource.Play();
			isAttack = false;
            audioSource.pitch = Random.Range(0.8f, 1.1f);
		}

        // podazanie za miesem a nie graczem

		if((isSawPlayer == true || isRayPlayer == true || isSawLight == true) && taskMeatScript.isDragMeat1 == true && taskMeatScript.meat1Condition > 0){
			isSeeMeat1 = true;
		}

		if((isSawPlayer == true || isRayPlayer == true || isSawLight == true) && taskMeatScript.isDragMeat2 == true && taskMeatScript.meat2Condition > 0){
			isSeeMeat2 = true;
		}

		if((isSawPlayer == true || isRayPlayer == true || isSawLight == true) && taskMeatScript.isDragMeat3 == true && taskMeatScript.meat3Condition > 0){
			isSeeMeat3 = true;
		}

		if(isSeeMeat1 == true){

            float DystansMieso1 = Vector3.Distance(meat1.position, monster.position);

            monsterAgent.SetDestination(meat1.transform.position);
            monsterAgent.Resume();
            monsterAgent.updatePosition = true;

            if (DystansMieso1 < 5 && isAteMeat1 == false)
            {
                isAteMeat1 = true;
            }

            if (isAteMeat1 == true && taskMeatScript.meat1Condition > 0)
            {
                taskMeatScript.meat1Condition -= 10f * Time.deltaTime;
            }

            if (taskMeatScript.meat1Condition <= 0)
            {
                isSeeMeat1 = false;
            }

        }
        else if(isSeeMeat2 == true){

            float DystansMieso2 = Vector3.Distance(meat2.position, monster.position);

            monsterAgent.SetDestination(meat2.transform.position);
            monsterAgent.Resume();
            monsterAgent.updatePosition = true;

            if (DystansMieso2 < 5 && isAteMeat2 == false)
            {
                isAteMeat2 = true;
            }

            if (isAteMeat2 == true && taskMeatScript.meat2Condition > 0)
            {
                taskMeatScript.meat2Condition -= 10f * Time.deltaTime;
            }

            if (taskMeatScript.meat2Condition <= 0)
            {
                isSeeMeat2 = false;
            }

        }
        else if(isSeeMeat3 == true){

            float DystansMieso3 = Vector3.Distance(meat3.position, monster.position);

            monsterAgent.SetDestination(meat3.transform.position);
            monsterAgent.Resume();
            monsterAgent.updatePosition = true;

            if (DystansMieso3 < 5 && isAteMeat3 == false)
            {
                isAteMeat3 = true;
            }

            if (isAteMeat3 == true && taskMeatScript.meat3Condition > 0)
            {
                taskMeatScript.meat3Condition -= 10f * Time.deltaTime;
            }

            if (taskMeatScript.meat3Condition <= 0)
            {
                isSeeMeat3 = false;
            }

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

	//void OnCollisionEnter(Collision other){

	//}

	void AnimacjaMonster(){

		monsterAnimator.SetFloat("PredkoscPoruszania", currentVelocity);

	}
}
