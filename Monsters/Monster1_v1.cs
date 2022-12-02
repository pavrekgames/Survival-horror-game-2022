using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster1_v1 : Monster {

    public bool isPlaySound = false; 

    private Transform monsterPoint1;
	private Transform monsterPoint2;
	private Transform monsterPoint3;
	private Transform monsterPoint4;
	private Transform monsterPoint5;
	private Transform monsterPoint6;
	private Transform monsterPoint7;

    public enum ActualPoint
    {
        Point1,
        Point2,
        Point3,
        Point4,
        Point5,
        Point6,
        Point7
    }

    public ActualPoint actualPoint;

	void OnEnable () {

		player = GameObject.Find("Player").transform;
		monster = GameObject.Find("Monster1_v1").transform;
		monsterPoint1 = GameObject.Find("MonsterPoint1").transform;
		monsterPoint2 = GameObject.Find("MonsterPoint2").transform;
		monsterPoint3 = GameObject.Find("MonsterPoint3").transform;
		monsterPoint4 = GameObject.Find("MonsterPoint4").transform;
		monsterPoint5 = GameObject.Find("MonsterPoint5").transform;
		monsterPoint6 = GameObject.Find("MonsterPoint6").transform;
		monsterPoint7 = GameObject.Find("MonsterPoint7").transform;
		monsterController = GetComponent<CharacterController>();
		flashlightScript = GameObject.Find ("Flashlight").GetComponent<Flashlight> ();
		healthScript = player.GetComponent<Health>();
		crouchScript = player.GetComponent<Crouch>();
		playerHead = GameObject.Find ("PlayerHead").transform;
        monsterAgent = monster.GetComponent<NavMeshAgent>();
        jumpscareScript = GameObject.Find("Player").GetComponent<Jumpscare>();
        mapScript = GameObject.Find("Player").GetComponent<Map>();

        actualPoint = ActualPoint.Point1;

}
	
	void Update () {

		float distance = Vector3.Distance(player.position, monster.position);

        runVelocity = Random.Range(7, 11);
        mapScript.isFastTravel = false;

        MonsterFollowsPoint();
        MonsterFollowsPlayer(distance);
        MonsterLongLight(distance);
        MonsterFlashlight(distance);
        MonsterRaycast(distance);
        MonsterAttack(distance);

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

   public override void MonsterFollowsPoint()
    {
        if (isSawPlayer == false && isRayPlayer == false && isSawLight == false)
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
                    SetPoint(monsterPoint4);
                    break;
                case ActualPoint.Point5:
                    SetPoint(monsterPoint5);
                    break;
                case ActualPoint.Point6:
                    SetPoint(monsterPoint6);
                    break;
                case ActualPoint.Point7:
                    SetPoint(monsterPoint7);
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
        if ((isSawLight == true || isSawPlayer == true || isRayPlayer == true) && _distance >= 5 && jumpscareScript.isPlayerSave == false)
        {
            monsterAgent.SetDestination(player.transform.position);
            monsterAgent.Resume();
            monsterAgent.updatePosition = true;
            monsterAgent.speed = runVelocity;
        }

        if (healthScript.health <= 0 || jumpscareScript.isPlayerSave == true)
        {
            isSawPlayer = false;
            isRayPlayer = false;
            isSawLight = false;
            isAttack = false;
            monsterAnimator.SetBool("Attack", false);
        }
    }

    public override void MonsterLongLight(float _distance)
    {
        if (_distance <= 40 && Input.GetMouseButtonDown(2) && flashlightScript.isFlashlightOn == true && isSawLight == false && healthScript.health > 0 && jumpscareScript.isPlayerSave == false)
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

        if (_distance <= 17 && isSawPlayer == false && flashlightScript.isFlashlightOn == true && healthScript.health > 0 && jumpscareScript.isPlayerSave == false)
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

        if (_distance <= 11 && flashlightScript.isFlashlightOn == false && isSawPlayer == false && healthScript.health > 0 && jumpscareScript.isPlayerSave == false)
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

                if (hit.collider.gameObject.name == "Player" && jumpscareScript.isPlayerSave == false)
                {
                    isRayPlayer = true;
                    monsterAgent.speed = runVelocity;
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
        if (_distance < 5 && healthScript.health > 0 && jumpscareScript.isPlayerSave == false)
        {
            monsterAgent.Stop();
            monsterAgent.velocity = Vector3.zero;
            isSawLight = false;
            monsterAgent.speed = walkVelocity;
            monsterAnimator.SetBool("Attack", true);
            monsterAgent.updatePosition = true;
            monsterAgent.SetDestination(player.transform.position);
            monster.rotation = Quaternion.Slerp(monster.rotation, Quaternion.LookRotation(player.position - monster.position), rotationVelocity * Time.deltaTime);
        }
        else
        {
            monsterAnimator.SetBool("Attack", false);
        }
    }

	void OnTriggerEnter(Collider other){

		if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPoint1"){ 
            actualPoint = ActualPoint.Point2;
		}

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPoint2"){
            actualPoint = ActualPoint.Point3;
        }

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPoint3"){
            actualPoint = ActualPoint.Point4;
        }

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPoint4"){
            actualPoint = ActualPoint.Point5;
        }

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPoint5"){
            actualPoint = ActualPoint.Point6;
        }

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPoint6"){
            actualPoint = ActualPoint.Point7;
        }

		else if(other.gameObject.GetComponent<Collider>().gameObject.name == "MonsterPoint7"){
            actualPoint = ActualPoint.Point1;
        }	
	}	
}
