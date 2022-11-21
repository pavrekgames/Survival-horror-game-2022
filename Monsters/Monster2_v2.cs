using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster2_v2 : MonoBehaviour {

    public bool isPlaySound = false; 

    private Transform player;
	public Transform playerHead;
	private Transform monster;
    private NavMeshAgent monsterAgent;
    public Animator monsterAnimator;
	public AudioSource audioSource;
    public AudioSource hitAudioSource;
    public AudioClip monsterSound;
	public AudioClip monsterAttackSound;
    public AudioClip hitDoorSound;
    private CharacterController monsterController;
	private Flashlight flashlightScript;
	private Health healthScript;
    private Crouch crouchScript;
    private Map mapScript;
    public NavMeshPath mainPath;
    public bool isPathPossible = true;

    private Transform monsterStartPoint; 
    private Transform monsterPoint1;
	private Transform monsterPoint2;
	private Transform monsterPoint3;

	public bool isStartPoint = false;
    public bool isPoint1 = true;
    public bool isPoint2 = false;
    public bool isPoint3 = false;

    public bool isSawPlayer = false;
	public bool isRayPlayer = false;
	public bool isSawLight = false;
	public bool isAttack = false;

    public float walkVelocity = 6f;
    public float runVelocity = 9f;

    public float currentVelocity = 4.0f;
	public float rotationVelocity = 5.0f;
	public float heaigh  = 0f;

    // monster drzwi

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

    private Ray monsterAim;
	public float rayLength = 30f;



	void OnEnable () {

		player = GameObject.Find("Player").transform;
		monster = GameObject.Find("Monster2_v2").transform;
		monsterStartPoint = GameObject.Find("Monster4PunktStart").transform;
        monsterPoint1 = GameObject.Find("Monster4Punkt1").transform;
        monsterPoint2 = GameObject.Find("Monster4Punkt2").transform;
        monsterPoint2 = GameObject.Find("Monster4Punkt3").transform;
        monsterController = GetComponent<CharacterController>();
		flashlightScript = GameObject.Find ("Latarka").GetComponent<Flashlight> ();
		healthScript = player.GetComponent<Health>();
        crouchScript = player.GetComponent<Crouch>();
        monsterAgent = monster.GetComponent<NavMeshAgent>();
		playerHead = GameObject.Find ("Głowa").transform;
        mapScript = GameObject.Find("Player").GetComponent<Map>();

        kitchenDoor = GameObject.Find("DrzwiKuchnia").gameObject;
        uncleDoor = GameObject.Find("DrzwiPokojW").gameObject;
        bathroomDoor = GameObject.Find("DrzwiLazienka").gameObject;
        toiletDoor = GameObject.Find("DrzwiToaleta").gameObject;
        nicheDoor = GameObject.Find("DrzwiWneka").gameObject;
        stableDoor = GameObject.Find("DrzwiStajnia").gameObject;
        smallShedDoor = GameObject.Find("DrzwiDrewutnia").gameObject;
        toolShedDoor = GameObject.Find("DrzwiSzopaNarzedzia").gameObject;
        secretRoomDoor = GameObject.Find("DrzwiKamping").gameObject;
        cornfieldDoor = GameObject.Find("DrzwiKukurydza").gameObject;
        gardenDoor = GameObject.Find("DrzwiOgrod").gameObject;
        houseDoor = GameObject.Find("DrzwiDom").gameObject;

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
        isPoint1 = true;
        isPoint2 = false;
        isPoint3 = false;

        isPathPossible = true;
        mainPath = new NavMeshPath();

        hitAudioSource.clip = null;
        audioSource.pitch = 1;

    }


	void Update () {

		//Ray MonsterAim = MonsterCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		//Ray MonsterAim = new Ray(transform.position, transform.right);

		//AnimacjaMonster();
		float Dystans = Vector3.Distance(player.position, monster.position);
        //Vector3 ruch = new Vector3(Monster.forward.x, Wysokosc, Monster.forward.z);
        //Debug.DrawRay(Monster.transform.position, Monster.transform.forward * RayLength, Color.green);
        //Debug.Log(Dystans);

        runVelocity = Random.Range(8, 12);
        mapScript.isFastTravel = false;

        // pierwszy wymagany punkt potwora

        if (isStartPoint == false)
        {
            monsterAgent.updatePosition = true;
            monsterAgent.SetDestination(monsterStartPoint.transform.position);
        }

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

        if (!monsterController.isGrounded){ // odpowiada za to ze przeciwnik nie lata
			heaigh += Physics.gravity.y * Time.deltaTime;
		}	


        // podazanie do odpowiednich punktow

        if ((isSawPlayer == false && isRayPlayer == false && isSawLight == false && isStartPoint == true) ||(isStartPoint == true && isPathPossible == false)) {

            if (isPoint1 == true)
            {
                monsterAgent.updatePosition = true;
                monsterAgent.SetDestination(monsterPoint1.transform.position);
                monsterAgent.Resume();
                monsterAgent.speed = walkVelocity;
                monsterAnimator.SetBool("Widzi_ok", false);
            }

            else if (isPoint2 == true)

            {
                monsterAgent.updatePosition = true;
                monsterAgent.SetDestination(monsterPoint2.transform.position);
                monsterAgent.Resume();
                monsterAgent.speed = walkVelocity;
                monsterAnimator.SetBool("Widzi_ok", false);
            }

            else if (isPoint3 == true)

            {
                monsterAgent.updatePosition = true;
                monsterAgent.SetDestination(monsterPoint3.transform.position);
                monsterAgent.Resume();
                monsterAgent.speed = walkVelocity;
                monsterAnimator.SetBool("Widzi_ok", false);
            }

        }


        // Linie odpowiedzialne za podazanie przeciwnika za graczem

            if (Dystans <= 100 && Input.GetMouseButtonDown(2) && flashlightScript.isFlashlightOn == true && isSawLight == false && healthScript.health > 0 && isStartPoint == true)
            {
                isSawLight = true;
                //MonsterAgent.speed = PredkoscBiegania;
            }
            else if (Dystans >= 80 && flashlightScript.isFlashlightOn == true && healthScript.health > 0 && isStartPoint == true)
            {
                isSawLight = false;
               // MonsterAgent.speed = PredkoscChodzenia;
            }
            else if (Dystans >= 70 && flashlightScript.isFlashlightOn == false && isStartPoint == true)
            {
                isSawLight = false;
                //MonsterAgent.speed = PredkoscChodzenia;
            }
            else if (Dystans >= 40 && flashlightScript.isFlashlightOn == true && crouchScript.isCrouch == true && isStartPoint == true)
            {
                isSawLight = false;
                //MonsterAgent.speed = PredkoscChodzenia;
            }
            else if (Dystans >= 30 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true && isStartPoint == true)
            {
                isSawLight = false;
                //MonsterAgent.speed = PredkoscChodzenia;
            }

            // normalnie z latarka

            if (Dystans <= 27 && isSawPlayer == false && flashlightScript.isFlashlightOn == true && healthScript.health > 0 && isStartPoint == true)
            {
                isSawPlayer = true;
                //MonsterAgent.speed = PredkoscBiegania;
            }
            else if (Dystans > 40 && flashlightScript.isFlashlightOn == true && healthScript.health > 0 && isStartPoint == true)
            {
                isSawPlayer = false;
               // MonsterAgent.speed = PredkoscChodzenia;
            }
            else if (Dystans > 30 && flashlightScript.isFlashlightOn == false && isStartPoint == true)
            {
                isSawPlayer = false;
                //MonsterAgent.speed = PredkoscChodzenia;
            }
            else if (Dystans > 13 && flashlightScript.isFlashlightOn == false && crouchScript.isCrouch == true && isStartPoint == true)
            {
                isSawPlayer = false;
                //MonsterAgent.speed = PredkoscChodzenia;
            }

            // Bez wlaczonej latarki

            if (Dystans <= 21 && flashlightScript.isFlashlightOn == false && isSawPlayer == false && healthScript.health > 0 && isStartPoint == true)
            {
                isSawPlayer = true;
               // MonsterAgent.speed = PredkoscBiegania;
            }

            // gracz w zasiegu wzroku

            if (Dystans <= 35 && isRayPlayer == false && healthScript.health > 0 && isStartPoint == true)
            {
                RaycastHit hit;

                if (Physics.Raycast(monster.transform.position, monster.transform.forward, out hit, rayLength, 1 << 10))
                {

                    if (hit.collider.gameObject.name == "Player")
                    {
                        isRayPlayer = true;
                        Debug.Log("Wykryl");
                        //MonsterAgent.speed = PredkoscBiegania;
                    }

                }

            }

            else if (Dystans > 50 && isStartPoint == true)
            {
                isRayPlayer = false;
                //MonsterAgent.speed = PredkoscChodzenia;
            }

            // kalkulowanie czy podazac za graczem

            if (isSawLight == true || isSawPlayer == true || isRayPlayer == true)
            {
                NavMesh.CalculatePath(monster.transform.position, player.transform.position, -1, mainPath);
            }

            // podazanie za graczem

            if ((isSawLight == true || isSawPlayer == true || isRayPlayer == true) && Dystans >= 5 && isStartPoint == true && isPathPossible == true)
            {
                monsterAgent.SetDestination(player.transform.position);
                monsterAgent.Resume();
                monsterAgent.updatePosition = true;
                monsterAgent.speed = runVelocity;
                monsterAnimator.SetBool("Widzi_ok", true);
        }

            // atak potwora

            if (Dystans < 5 && healthScript.health > 0 && isStartPoint == true)
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

		if(healthScript.health <= 0){
			isSawPlayer = false;
			isRayPlayer = false;
			isSawLight = false;
            isAttack = false;
            monsterAnimator.SetBool("Atak_ok", false);
        }

		if(isSawPlayer == false && isSawLight == false && isRayPlayer == false && isStartPoint == true){
			monsterAnimator.SetBool("Widzi_ok", false);
		}

        // dzwiek ataku potwora

        if (Dystans < 8 && isAttack == false && isStartPoint == true && healthScript.health > 0){
            audioSource.pitch = Random.Range(0.8f, 1.1f);
            audioSource.clip = monsterAttackSound;
			audioSource.Play();
			isAttack = true;
		}else if(Dystans >= 8 && isAttack == true && isStartPoint == true && healthScript.health > 0)
        {
            audioSource.pitch = 1;
			audioSource.clip = monsterSound;
			audioSource.Play();
			isAttack = false;
		}

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
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster4PunktStart")
        { //1.58
            isStartPoint = true;
        }else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster4Punkt1")
        {
            isPoint1 = false;
            isPoint2 = true;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster4Punkt2")
        {
            isPoint2 = false;
            isPoint3 = true;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "Monster4Punkt3")
        {
            isPoint3 = false;
            isPoint1 = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.GetComponent<Collider>().gameObject.name == "DrzwiKuchnia" && isKitchenDoor == false)
        {
            kitchenDoor.tag = "Move2";
            hitAudioSource.clip = hitDoorSound;
            hitAudioSource.Play();
            Destroy(kitchenDoor.GetComponent<HingeJoint>());
            isKitchenDoor = true;
            kitchenDoor.gameObject.GetComponent<Door>().isDestroyed = true;
        }
        else if(other.gameObject.GetComponent<Collider>().gameObject.name == "DrzwiPokojW" && isUncleDoor == false)
        {
            uncleDoor.tag = "Move2";
            hitAudioSource.clip = hitDoorSound;
            hitAudioSource.Play();
            Destroy(uncleDoor.GetComponent<HingeJoint>());
            isUncleDoor = true;
            uncleDoor.gameObject.GetComponent<Door>().isDestroyed = true;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DrzwiLazienka" && isBathroomDoor == false)
        {
            bathroomDoor.tag = "Move2";
            hitAudioSource.clip = hitDoorSound;
            hitAudioSource.Play();
            Destroy(bathroomDoor.GetComponent<HingeJoint>());
            isBathroomDoor = true;
            bathroomDoor.gameObject.GetComponent<Door>().isDestroyed = true;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DrzwiToaleta" && isToiletDoor == false)
        {
            toiletDoor.tag = "Move2";
            hitAudioSource.clip = hitDoorSound;
            hitAudioSource.Play();
            Destroy(toiletDoor.GetComponent<HingeJoint>());
            isToiletDoor = true;
            toiletDoor.gameObject.GetComponent<Door>().isDestroyed = true;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DrzwiWneka" && isNicheDoor == false)
        {
            nicheDoor.tag = "Move2";
            hitAudioSource.clip = hitDoorSound;
            hitAudioSource.Play();
            Destroy(nicheDoor.GetComponent<HingeJoint>());
            isNicheDoor = true;
            nicheDoor.gameObject.GetComponent<Door>().isDestroyed = true;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DrzwiStajnia" && isStableDoor == false)
        {
            stableDoor.tag = "Move2";
            hitAudioSource.clip = hitDoorSound;
            hitAudioSource.Play();
            Destroy(stableDoor.GetComponent<HingeJoint>());
            isStableDoor = true;
            stableDoor.gameObject.GetComponent<Door>().isDestroyed = true;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DrzwiDrewutnia" && isSmallShedDoor == false)
        {
            smallShedDoor.tag = "Move2";
            hitAudioSource.clip = hitDoorSound;
            hitAudioSource.Play();
            Destroy(smallShedDoor.GetComponent<HingeJoint>());
            isSmallShedDoor = true;
            smallShedDoor.gameObject.GetComponent<Door>().isDestroyed = true;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DrzwiSzopaNarzedzia" && isToolShedDoor == false)
        {
            toolShedDoor.tag = "Move2";
            hitAudioSource.clip = hitDoorSound;
            hitAudioSource.Play();
            Destroy(toolShedDoor.GetComponent<HingeJoint>());
            isToolShedDoor = true;
            toolShedDoor.gameObject.GetComponent<Door>().isDestroyed = true;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DrzwiKamping" && isSecretRoomDoor == false)
        {
            secretRoomDoor.tag = "Move2";
            hitAudioSource.clip = hitDoorSound;
            hitAudioSource.Play();
            Destroy(secretRoomDoor.GetComponent<HingeJoint>());
            isSecretRoomDoor = true;
            secretRoomDoor.gameObject.GetComponent<Door>().isDestroyed = true;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DrzwiKukurydza" && isCornfieldDoor == false)
        {
            cornfieldDoor.tag = "Move2";
            hitAudioSource.clip = hitDoorSound;
            hitAudioSource.Play();
            Destroy(cornfieldDoor.GetComponent<HingeJoint>());
            isCornfieldDoor = true;
            cornfieldDoor.gameObject.GetComponent<Door>().isDestroyed = true;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DrzwiOgrod" && isGardenDoor == false)
        {
            gardenDoor.tag = "Move2";
            hitAudioSource.clip = hitDoorSound;
            hitAudioSource.Play();
            Destroy(gardenDoor.GetComponent<HingeJoint>());
            isGardenDoor = true;
            gardenDoor.gameObject.GetComponent<Door>().isDestroyed = true;
        }
        else if (other.gameObject.GetComponent<Collider>().gameObject.name == "DrzwiDom" && isHouseDoor == false)
        {
            houseDoor.tag = "Move2";
            hitAudioSource.clip = hitDoorSound;
            hitAudioSource.Play();
            Destroy(houseDoor.GetComponent<HingeJoint>());
            isHouseDoor = true;
            houseDoor.gameObject.GetComponent<Door>().isDestroyed = true;
        }

    }

    void monsterAnimation(){

		monsterAnimator.SetFloat("PredkoscPoruszania", currentVelocity);

	}


}
