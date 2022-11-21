using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomJumpscare : MonoBehaviour {

    public AudioClip[] sounds;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private AudioSource audioSource3;
    private Transform player;
    private Tasks tasksScript;
    public int randomSoundIndex;
    public int randomPosition1;
    public int randomPosition2;
    public int randomMonsterPosition1;
    public int randomMonsterPosition2;
    public int randomDuration;
    public float counter;
    public bool isOn = false;

    public Transform monster;
    public Transform monster2;
    public Transform monster3;
    private RandomMonster monster1_Script;
    private RandomMonster2 monster2_Script;
    private RandomMonster3 monster3_Script;
    private AudioSource monster1_AudioSource;
    private AudioSource monster2_AudioSource;
    private AudioSource monster3_AudioSource;
    private SkinnedMeshRenderer monster1_MeshRender;
    private SkinnedMeshRenderer monster2_MeshRender;
    private SkinnedMeshRenderer monster3_MeshRender;

    private Player platerScript;
    public bool isPossibleTerrain = true;

    public float terrainY;
    public float playerX;
    public float playerZ;
    public int intPlayerX;
    public int intPlayerZ;

    public bool isPlaySound = false;

    void OnEnable () {

        audioSource1 = GameObject.Find("LosowyStraszak1_s").GetComponent<AudioSource>();
        audioSource2 = GameObject.Find("LosowyStraszak2_s").GetComponent<AudioSource>();
        audioSource3 = GameObject.Find("LosowyStraszak3_s").GetComponent<AudioSource>();
        player = GameObject.Find("Player").transform;

        monster = GameObject.Find("Monster1_Losowy").transform;
        monster2 = GameObject.Find("Monster1_Losowy2").transform;
        monster3 = GameObject.Find("Monster1_Losowy3").transform;
        monster1_Script = GameObject.Find("Monster1_Losowy").GetComponent<RandomMonster>();
        monster2_Script = GameObject.Find("Monster1_Losowy2").GetComponent<RandomMonster2>();
        monster3_Script = GameObject.Find("Monster1_Losowy3").GetComponent<RandomMonster3>();
        monster1_AudioSource = GameObject.Find("Monster1_Losowy_cialo").GetComponent<AudioSource>();
        monster2_AudioSource = GameObject.Find("Monster1_Losowy2_cialo").GetComponent<AudioSource>();
        monster3_AudioSource = GameObject.Find("Monster1_Losowy3_cialo").GetComponent<AudioSource>();
        monster1_MeshRender = GameObject.Find("Monster1_Losowy_mesh").GetComponent<SkinnedMeshRenderer>();
        monster2_MeshRender = GameObject.Find("Monster1_Losowy2_mesh").GetComponent<SkinnedMeshRenderer>();
        monster3_MeshRender = GameObject.Find("Monster1_Losowy3_mesh").GetComponent<SkinnedMeshRenderer>();

        platerScript = GameObject.Find("Player").GetComponent<Player>();
        tasksScript = GameObject.Find("Player").GetComponent<Tasks>();

        randomDuration = Random.Range(40, 121);
        monster.gameObject.SetActive(false);
        monster2.gameObject.SetActive(false);
        monster3.gameObject.SetActive(false);

    }
	
	
	void Update () {

     /*    if (Input.GetKeyDown("n"))
         {

            //WlaczMonsterStraszak();
            WlaczStraszak();

         }  */

        if (counter < randomDuration)
        {
            isOn = false;
            counter += 1 * Time.deltaTime;

        }

        else if (counter >= randomDuration && isOn == false && isPossibleTerrain == true && tasksScript.isGoToAliceTask == false)
        {

            EnableSmallJumpscare();

        }

        else if (counter >= randomDuration && isOn == false && isPossibleTerrain == true && tasksScript.isGoToAliceTask == true && tasksScript.isStevenSearchTask == false) // wczesniej bylo steven grzyb
        {

            EnableJumpscare();

        }

        else if (counter >= randomDuration && isOn == false && isPossibleTerrain == true && tasksScript.isGoToAliceTask == true && tasksScript.isStevenSearchTask == true && tasksScript.isStevenShedTask == false) // wczesniej bylo stevengrzyb zamiast info
        {

            EnableMonsterJumpscare();

        }

        else if (counter >= randomDuration && isOn == false && isPossibleTerrain == true && tasksScript.isGoToAliceTask == true && tasksScript.isStevenSearchTask == true && tasksScript.isStevenShedTask == true) // wczesniej bylo stevengrzyb zamiast info
        {

            EnableMonsterJumpscare();

        }



        if (Time.timeScale == 0 && isPlaySound == false)
        {
            audioSource1.Pause();
            audioSource2.Pause();
            audioSource3.Pause();

            isPlaySound = true;
        }

        else if(Time.timeScale == 1 && isPlaySound == true)
        {

            audioSource1.UnPause();
            audioSource2.UnPause();
            audioSource3.UnPause();

            isPlaySound = false;
        }


	}


    void EnableJumpscare()
    {
        randomSoundIndex = Random.Range(0, 17); 
        randomPosition1 = Random.Range(-18, 21);
        randomPosition2 = Random.Range(-18, 21);

        if (randomSoundIndex < 6)
        {
            audioSource1.pitch = Random.Range(0.8f, 1.1f);
            audioSource1.clip = sounds[randomSoundIndex];
            audioSource1.Play();
            audioSource1.transform.position = new Vector3(player.transform.position.x + randomPosition1, player.transform.position.y, player.transform.position.z + randomPosition2);

            randomDuration = Random.Range(40, 121);
            counter = 0;
            isOn = true;
        }

        else if (randomSoundIndex >= 6 && randomSoundIndex < 8) { // bylo < 14

            audioSource2.pitch = Random.Range(0.8f, 1.1f);
            audioSource2.clip = sounds[randomSoundIndex];
            audioSource2.Play();
            audioSource2.transform.position = new Vector3(player.transform.position.x + randomPosition1, player.transform.position.y, player.transform.position.z + randomPosition2);

            randomDuration = Random.Range(40, 121);
            counter = 0;
            isOn = true;

        }

        else if (randomSoundIndex >= 8 && (tasksScript.isVictorBrookTask == false || tasksScript.isVictorBrookTaskRemoved == true)) // bylo >= 8
        {

            MonsterJumpscare1();  

        }

    }

    void EnableSmallJumpscare() {

        randomSoundIndex = Random.Range(0, 14);
        randomPosition1 = Random.Range(-18, 21);
        randomPosition2 = Random.Range(-18, 21);

        if (randomSoundIndex < 6)
        {
            audioSource1.pitch = Random.Range(0.8f, 1.1f);
            audioSource1.clip = sounds[randomSoundIndex];
            audioSource1.Play();
            audioSource1.transform.position = new Vector3(player.transform.position.x + randomPosition1, player.transform.position.y, player.transform.position.z + randomPosition2);
        }

        else if (randomSoundIndex >= 6 && randomSoundIndex < 14)
        {

            audioSource2.pitch = Random.Range(0.8f, 1.1f);
            audioSource2.clip = sounds[randomSoundIndex];
            audioSource2.Play();
            audioSource2.transform.position = new Vector3(player.transform.position.x + randomPosition1, player.transform.position.y, player.transform.position.z + randomPosition2);
        }

        randomDuration = Random.Range(40, 121);
        counter = 0;
        isOn = true;

    }

    void EnableMonsterJumpscare()
    {
        randomSoundIndex = Random.Range(11, 19); // wczesniej bylo 16,19
        randomPosition1 = Random.Range(-18, 21);
        randomPosition2 = Random.Range(-18, 21);

        if (randomSoundIndex >= 14 && randomSoundIndex < 17)
        {

            MonsterJumpscare1();

        }
        else if (randomSoundIndex == 11 || randomSoundIndex == 12 ||randomSoundIndex == 17)
        {

            MonsterJumpscare2();

        }
        else if (randomSoundIndex == 13 || randomSoundIndex == 18)
        {
            MonsterJumpscare3();

        }

        counter = 0;
        isOn = true;

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("TerenStraszak_trigger"))
        { 
            isPossibleTerrain = false;
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TerenStraszak_trigger"))
        { 
            isPossibleTerrain = true;
        }

    }

    public void DisableMonsters()
    {

        monster.gameObject.SetActive(false);
        monster1_Script.enabled = false;
        monster2.gameObject.SetActive(false);
        monster2_Script.enabled = false;
        monster3.gameObject.SetActive(false);
        monster3_Script.enabled = false;
        counter = 0;

    }

    void MonsterJumpscare1()
    {
        StartCoroutine(MonsterJumpscare1_IE());
    }

    IEnumerator MonsterJumpscare1_IE()
    {
        RandomMonster1Position();
        yield return new WaitForSeconds(1f);
        CheckMonster1Position();

    }


    void RandomMonster1Position()
    {
        randomMonsterPosition1 = Random.Range(-30, 30);
        randomMonsterPosition2 = Random.Range(-30, 30);

        if (randomMonsterPosition1 > -15 && randomMonsterPosition1 <= 0)
        {
            randomMonsterPosition1 -= 10;
        }
        else if (randomMonsterPosition1 > 0 && randomMonsterPosition1 <= 15)
        {
            randomMonsterPosition1 += 10;
        }

        if (randomMonsterPosition2 > -15 && randomMonsterPosition2 <= 0)
        {
            randomMonsterPosition2 -= 10;
        }
        else if (randomMonsterPosition2 > 0 && randomMonsterPosition2 <= 15)
        {
            randomMonsterPosition2 += 10;
        }

        audioSource3.transform.position = new Vector3(player.transform.position.x + randomMonsterPosition1, player.transform.position.y, player.transform.position.z + randomMonsterPosition2);
        playerX = player.transform.position.x;
        playerZ = player.transform.position.z;
        intPlayerX = (int)playerX + randomMonsterPosition1; // LosPoz1
        intPlayerZ = (int)playerZ + randomMonsterPosition2; // LosPoz2
        //TerenY = Terrain.activeTerrain.terrainData.GetHeight(IntPlayerX, IntPlayerZ);
        terrainY = Terrain.activeTerrain.SampleHeight(audioSource3.transform.position);
        monster.transform.position = new Vector3(intPlayerX, terrainY, intPlayerZ);
        monster.gameObject.SetActive(true);
        monster1_Script.enabled = true;
    }

    void CheckMonster1Position()
    {

        if(monster1_Script.isPathPossible == true)
        {
            ExecuteMonster1Jumspcare();
            Debug.Log("Monster_OK");
            StopAllCoroutines();
            counter = 0;
        }else
        {
            Debug.Log("ProbaNieudana");
            MonsterJumpscare1();
            counter = 0;
        }


    }

    void ExecuteMonster1Jumspcare()
    {

        audioSource3.transform.position = new Vector3(player.transform.position.x + randomMonsterPosition1, player.transform.position.y, player.transform.position.z + randomMonsterPosition2);
        audioSource3.pitch = Random.Range(0.8f, 1.1f);
        audioSource3.clip = sounds[randomSoundIndex];
        audioSource3.Play();
        monster.gameObject.SetActive(true);
        monster1_Script.enabled = true;
        monster1_AudioSource.enabled = true;
        monster1_MeshRender.enabled = true;

        randomDuration = Random.Range(40, 121);
        counter = 0;
        isOn = true;

    }

    void MonsterJumpscare2()
    {
        StartCoroutine(MonsterJumpscare2_IE());
    }

    IEnumerator MonsterJumpscare2_IE()
    {
        RandomMonster2Position();
        yield return new WaitForSeconds(1f);
        CheckMonster2Position();

    }


    void RandomMonster2Position()
    {
        randomMonsterPosition1 = Random.Range(-30, 30);
        randomMonsterPosition2 = Random.Range(-30, 30);

        if (randomMonsterPosition1 > -15 && randomMonsterPosition1 <= 0)
        {
            randomMonsterPosition1 -= 10;
        }
        else if (randomMonsterPosition1 > 0 && randomMonsterPosition1 <= 15)
        {
            randomMonsterPosition1 += 10;
        }

        if (randomMonsterPosition2 > -15 && randomMonsterPosition2 <= 0)
        {
            randomMonsterPosition2 -= 10;
        }
        else if (randomMonsterPosition2 > 0 && randomMonsterPosition2 <= 15)
        {
            randomMonsterPosition2 += 10;
        }

        audioSource3.transform.position = new Vector3(player.transform.position.x + randomMonsterPosition1, player.transform.position.y, player.transform.position.z + randomMonsterPosition2);
        playerX = player.transform.position.x;
        playerZ = player.transform.position.z;
        intPlayerX = (int)playerX + randomMonsterPosition1; // LosPoz1
        intPlayerZ = (int)playerZ + randomMonsterPosition2; // LosPoz2                                          
        //TerenY = Terrain.activeTerrain.terrainData.GetHeight(IntPlayerX, IntPlayerZ);
        terrainY = Terrain.activeTerrain.SampleHeight(audioSource3.transform.position);
        monster2.transform.position = new Vector3(intPlayerX, terrainY, intPlayerZ);
        monster2.gameObject.SetActive(true);
        monster2_Script.enabled = true;
        
    }

    void CheckMonster2Position()
    {

        if (monster2_Script.isPathPossible == true)
        {
            ExecuteMonster2Jumspcare();
            Debug.Log("Monster_OK");
            StopAllCoroutines();
        }
        else
        {
            Debug.Log("ProbaNieudana");
            MonsterJumpscare2();
            counter = 0;
        }


    }

    void ExecuteMonster2Jumspcare()
    {

        audioSource3.transform.position = new Vector3(player.transform.position.x + randomMonsterPosition1, player.transform.position.y, player.transform.position.z + randomMonsterPosition2);
        audioSource3.pitch = Random.Range(0.8f, 1.1f);
        audioSource3.clip = sounds[randomSoundIndex];
        audioSource3.Play();
        monster2.gameObject.SetActive(true);
        monster2_Script.enabled = true;
        monster2_AudioSource.enabled = true;
        monster2_MeshRender.enabled = true;

        randomDuration = Random.Range(40, 121);
        counter = 0;
        isOn = true;

    }

    void MonsterJumpscare3()
    {
        StartCoroutine(MonsterJumpscare3_IE());
    }

    IEnumerator MonsterJumpscare3_IE()
    {
        RandomMonster3Position();
        yield return new WaitForSeconds(1f);
        CheckMonster3Position();

    }


    void RandomMonster3Position()
    {
        randomMonsterPosition1 = Random.Range(-30, 30);
        randomMonsterPosition2 = Random.Range(-30, 30);

        if (randomMonsterPosition1 > -15 && randomMonsterPosition1 <= 0)
        {
            randomMonsterPosition1 -= 10;
        }
        else if (randomMonsterPosition1 > 0 && randomMonsterPosition1 <= 15)
        {
            randomMonsterPosition1 += 10;
        }

        if (randomMonsterPosition2 > -15 && randomMonsterPosition2 <= 0)
        {
            randomMonsterPosition2 -= 10;
        }
        else if (randomMonsterPosition2 > 0 && randomMonsterPosition2 <= 15)
        {
            randomMonsterPosition2 += 10;
        }

        audioSource3.transform.position = new Vector3(player.transform.position.x + randomMonsterPosition1, player.transform.position.y, player.transform.position.z + randomMonsterPosition2);
        playerX = player.transform.position.x;
        playerZ = player.transform.position.z;
        intPlayerX = (int)playerX + randomMonsterPosition1; // LosPoz1
        intPlayerZ = (int)playerZ + randomMonsterPosition2; // LosPoz2                                          
        //TerenY = Terrain.activeTerrain.terrainData.GetHeight(IntPlayerX, IntPlayerZ);
        terrainY = Terrain.activeTerrain.SampleHeight(audioSource3.transform.position);
        monster3.transform.position = new Vector3(intPlayerX, terrainY, intPlayerZ);
        monster3.gameObject.SetActive(true);
        monster3_Script.enabled = true;

    }

    void CheckMonster3Position()
    {

        if (monster3_Script.isPathPossible == true)
        {
            ExecuteMonster3Jumspcare();
            Debug.Log("Monster_OK");
            StopAllCoroutines();
        }
        else
        {
            Debug.Log("ProbaNieudana");
            MonsterJumpscare3();
            counter = 0;
        }


    }

    void ExecuteMonster3Jumspcare()
    {

        audioSource3.transform.position = new Vector3(player.transform.position.x + randomMonsterPosition1, player.transform.position.y, player.transform.position.z + randomMonsterPosition2);
        audioSource3.pitch = Random.Range(0.8f, 1.1f);
        audioSource3.clip = sounds[randomSoundIndex];
        audioSource3.Play();
        monster3.gameObject.SetActive(true);
        monster3_Script.enabled = true;
        monster3_AudioSource.enabled = true;
        monster3_MeshRender.enabled = true;

        randomDuration = Random.Range(40, 121);
        counter = 0;
        isOn = true;

    }


}
