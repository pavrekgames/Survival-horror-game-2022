using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster1_v1 : MonoBehaviour {

    public bool isPlaySound = false; 

    private Transform player;
	public Transform playerHead;
	private Transform monster;
	public Animator monsterAnimator;
    private NavMeshAgent monsterAgent;
    public AudioSource audioSource;
	public AudioClip monsterSound;
	public AudioClip monsterAttackSound;
	private CharacterController monsterController;
	private Flashlight flashlightScript;
	private Health healthScript;
	private Crouch crouchScript;
    private Jumpscare jumpscareScript;
    private Map mapScript;

    private Transform monsterPoint1;
	private Transform monsterPoint2;
	private Transform monsterPoint3;
	private Transform monsterPoint4;
	private Transform monsterPoint5;
	private Transform monsterPoint6;
	private Transform monsterPoint7;

	public bool isPoint1 = true;
	public bool isPoint2 = false;
	public bool isPoint3 = false;
	public bool isPoint4 = false;
	public bool isPoint5 = false;
	public bool isPoint6 = false;
	public bool isPoint7 = false;

	public bool isSawPlayer = false;
	public bool isRayPlayer = false;
	public bool isSawLight = false;
	public bool isAttack = false;

    public float walkVelocity = 5f;
    public float runVelocity = 7f;

	public float currentVelocity = 4.0f;
	public float rotationVelocity = 5.0f;
	public float height  = 0f;

	private Ray monsterAim;
	public float rayLength = 30f;


	void OnEnable () {

		player = GameObject.Find("Player").transform;
		monster = GameObject.Find("Monster1_v1").transform;
		monsterPoint1 = GameObject.Find("MonsterPunkt1").transform;
		monsterPoint2 = GameObject.Find("MonsterPunkt2").transform;
		monsterPoint3 = GameObject.Find("MonsterPunkt3").transform;
		monsterPoint4 = GameObject.Find("MonsterPunkt4").transform;
		monsterPoint5 = GameObject.Find("MonsterPunkt5").transform;
		monsterPoint6 = GameObject.Find("MonsterPunkt6").transform;
		monsterPoint7 = GameObject.Find("MonsterPunkt7").transform;
		//AnimatorMonster = GetComponent<Animator>();
		monsterController = GetComponent<CharacterController>();
		flashlightScript = GameObject.Find ("Latarka").GetComponent<Flashlight> ();
		healthScript = player.GetComponent<Health>();
		crouchScript = player.GetComponent<Crouch>();
		playerHead = GameObject.Find ("GraczGora").transform;
        monsterAgent = monster.GetComponent<NavMeshAgent>();
        jumpscareScript = GameObject.Find("Player").GetComponent<Jumpscare>();
        mapScript = GameObject.Find("Player").GetComponent<Map>();

        isPoint1 = true;
        isPoint2 = false;
        isPoint3 = false;
        isPoint4 = false;
        isPoint5 = false;
        isPoint6 = false;
        isPoint7 = false;

}
	

	void Update () {

		//Ray MonsterAim = MonsterCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		//Ray MonsterAim = new Ray(transform.position, transform.right);

		//AnimacjaMonster();
		float Dystans = Vector3.Distance(player.position, monster.position);

        runVelocity = Random.Range(7, 11);
        mapScript.isFastTravel = false;

        //Vector3 ruch = new Vector3(Monster.forward.x, Wysokosc, Monster.forward.z);
        //Debug.DrawRay(Monster.transform.position, Monster.transform.forward * RayLength, Color.green);

        /*if (!KontrolerMonster.isGrounded){ // odpowiada za to ze przeciwnik nie lata
			Wysokosc += Physics.gravity.y * Time.deltaTime;
		}*/


        if (isSawPlayer == false && isRayPlayer == false && isSawLight == false) {

            if (isPoint7 == true) {
                monsterAgent.SetDestination(monsterPoint7.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
            }

            else if (isPoint1 == true) {
                monsterAgent.SetDestination(monsterPoint1.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
            }

            else if (isPoint2 == true) {
                monsterAgent.SetDestination(monsterPoint2.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
            }

            else if (isPoint3 == true) {
                monsterAgent.SetDestination(monsterPoint3.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
            }

            else if (isPoint4 == true) {
                monsterAgent.SetDestination(monsterPoint4.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
            }

            else if (isPoint5 == true) {
                monsterAgent.SetDestination(monsterPoint5.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
            }

            else if (isPoint6 == true) {
                monsterAgent.SetDestination(monsterPoint6.transform.position);
                monsterAgent.speed = walkVelocity;
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
            }

        }

		// Linie odpowiedzialne za podazanie przeciwnika za graczem

		// dlugie swiatlo latarki

		if(Dystans <= 40 && Input.GetMouseButtonDown(2) && flashlightScript.isFlashlightOn == true && isSawLight == false && healthScript.health > 0 && jumpscareScript.isPlayerSave == false)
        {
			isSawLight = true;
            //PredkoscPoruszania = 6f;
            //MonsterAgent.speed = PredkoscBiegania;
        }
        else if(Dystans >= 50 && flashlightScript.isFlashlightOn == true && healthScript.health > 0){
			isSawLight = false;
            //PredkoscPoruszania = 4.0f;
           // MonsterAgent.speed = PredkoscChodzenia;
        }
        else if(Dystans >= 40 && flashlightScript.isFlashlightOn == false){
			isSawLight = false;
            //PredkoscPoruszania = 4.0f;
            //MonsterAgent.speed = PredkoscChodzenia; 
        }
        else if(Dystans >= 30 && flashlightScript.isFlashlightOn == true && crouchScript.isCrouch == true){
			isSawLight = false;
            //PredkoscPoruszania = 4.0f;
           // MonsterAgent.speed = PredkoscChodzenia; 
        }
        else if(Dystans >= 20 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true){
			isSawLight = false;
            //PredkoscPoruszania = 4.0f;
            //MonsterAgent.speed = PredkoscChodzenia; 
        }  

		// normalnie z latarka

		if(Dystans <= 17 && isSawPlayer == false && flashlightScript.isFlashlightOn == true && healthScript.health > 0 && jumpscareScript.isPlayerSave == false)
        {
			isSawPlayer = true;
            //MonsterAgent.speed = PredkoscBiegania;

        }
        else if(Dystans > 30 && flashlightScript.isFlashlightOn == true && healthScript.health > 0){
			isSawPlayer = false;
            //MonsterAgent.speed = PredkoscChodzenia;
        }
        else if(Dystans > 20 && flashlightScript.isFlashlightOn == false){
			isSawPlayer = false;
           // MonsterAgent.speed = PredkoscChodzenia;
        }
        else if(Dystans > 13 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true){
			isSawPlayer = false;
            //MonsterAgent.speed = PredkoscChodzenia;
        }

        // Bez wlaczonej latarki

        if (Dystans <= 11 && flashlightScript.isFlashlightOn == false && isSawPlayer == false && healthScript.health > 0 && jumpscareScript.isPlayerSave == false)
        {
			isSawPlayer = true;
            //MonsterAgent.speed = PredkoscBiegania;
        }


        // gracz w zasiegu wzroku

        if (Dystans <= 25 && isRayPlayer == false && healthScript.health > 0)
        {
            RaycastHit hit;

            if (Physics.Raycast(monster.transform.position, monster.transform.forward, out hit, rayLength, 1 << 10))
            {

                if (hit.collider.gameObject.name == "Player" && jumpscareScript.isPlayerSave == false)
                {
                    isRayPlayer = true;
                    monsterAgent.speed = runVelocity;
                    Debug.Log("Wykryl");
                }

            }

        }

        else if (Dystans > 40)
        {
            isRayPlayer = false;
            //MonsterAgent.speed = PredkoscChodzenia;
        }

        // podazanie za graczem 

        if ((isSawLight == true || isSawPlayer == true || isRayPlayer == true) && Dystans >= 5 && jumpscareScript.isPlayerSave == false)
        {
            monsterAgent.SetDestination(player.transform.position);
            monsterAgent.Resume();
            monsterAgent.updatePosition = true;
            monsterAgent.speed = runVelocity;
        }

        // atak potwora

        if (Dystans < 5 && healthScript.health > 0 && jumpscareScript.isPlayerSave == false)
        {
            monsterAgent.Stop();
            monsterAgent.velocity = Vector3.zero;
            isSawLight = false;
            monsterAgent.speed = walkVelocity;
            monsterAnimator.SetBool("Atak_ok", true);
            monsterAgent.updatePosition = true;
            monsterAgent.SetDestination(player.transform.position);
            monster.rotation = Quaternion.Slerp(monster.rotation, Quaternion.LookRotation(player.position - monster.position), rotationVelocity * Time.deltaTime);
        }
        else{
			monsterAnimator.SetBool("Atak_ok", false);
	 }

        // smierc gracza lub w bezpiecznym miejscu

        if (healthScript.health <= 0 || jumpscareScript.isPlayerSave == true)
        {
			isSawPlayer = false;
			isRayPlayer = false;
			isSawLight = false;
            isAttack = false;
            monsterAnimator.SetBool("Atak_ok", false);
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

	void OnTriggerEnter(Collider other){
		if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPunkt1"){ //1.58
			isPoint1 = false;
			isPoint2 = true;
		}

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPunkt2"){
			isPoint2 = false;
			isPoint3 = true;
		}

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPunkt3"){
			isPoint3 = false;
			isPoint4 = true;
		}

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPunkt4"){
			isPoint4 = false;
			isPoint5 = true;
		}

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPunkt5"){
			isPoint5 = false;
			isPoint6 = true;
		}

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPunkt6"){
			isPoint6 = false;
			isPoint7 = true;
		}

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPunkt7"){
			isPoint7 = false;
			isPoint1 = true;
		}
			
	}

	void MonsterAnimation(){

		monsterAnimator.SetFloat("PredkoscPoruszania", currentVelocity);

	}
		
}
