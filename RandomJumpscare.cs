using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomJumpscare : MonoBehaviour {

    private Transform player;
    private Tasks tasksScript;

    [Header("Audio")]
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioSource audioSource3;

    [Header("Random values")]
    [SerializeField] private int randomSoundIndex;
    private int randomPosition1;
    private int randomPosition2;
    private int randomMonsterPosition1;
    private int randomMonsterPosition2;
    private int randomDuration;
    private float counter;
    private bool isOn = false;

    [Header("Terrain position")]
    public bool isPossibleTerrain = true;
    private float terrainY;
    private float playerX;
    private float playerZ;
    private int intPlayerX;
    private int intPlayerZ;

    struct RandomMonsters
    {
        public Transform monster;
        public Monster monsterScript;
        public AudioSource monsterAudioSource;
        public SkinnedMeshRenderer monsterMeshRender;
    }

    [Header("Monsters")]
    [SerializeField] private RandomMonsters[] randomMonsters;

    public bool isPlaySound = false;

    void OnEnable () {

        audioSource1 = GameObject.Find("RandomJumpscare1_s").GetComponent<AudioSource>();
        audioSource2 = GameObject.Find("RandomJumpscare2_s").GetComponent<AudioSource>();
        audioSource3 = GameObject.Find("RandomJumpscare3_s").GetComponent<AudioSource>();
        player = GameObject.Find("Player").transform;
        tasksScript = GameObject.Find("Player").GetComponent<Tasks>();
        randomDuration = Random.Range(40, 121);

    }
	
	
	void Update () {

        if (counter < randomDuration)
        {
            isOn = false;
            counter += 1 * Time.deltaTime;
        }
        else if (counter >= randomDuration && isOn == false && isPossibleTerrain == true && tasksScript.isGoToAliceTask == false)
        {
            EnableSmallJumpscare();
        }
        else if (counter >= randomDuration && isOn == false && isPossibleTerrain == true && tasksScript.isGoToAliceTask == true && tasksScript.isStevenSearchTask == false) 
        {
            EnableJumpscare();
        }
        else if (counter >= randomDuration && isOn == false && isPossibleTerrain == true && tasksScript.isGoToAliceTask == true && tasksScript.isStevenSearchTask == true && tasksScript.isStevenShedTask == false) 
        {
            EnableMonsterJumpscare();
        }
        else if (counter >= randomDuration && isOn == false && isPossibleTerrain == true && tasksScript.isGoToAliceTask == true && tasksScript.isStevenSearchTask == true && tasksScript.isStevenShedTask == true) 
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

    void SetAudioSource(AudioSource audioSource)
    {
        audioSource.pitch = Random.Range(0.8f, 1.1f);
        audioSource.clip = sounds[randomSoundIndex];
        audioSource.Play();
        audioSource.transform.position = new Vector3(player.transform.position.x + randomPosition1, player.transform.position.y, player.transform.position.z + randomPosition2);
        randomDuration = Random.Range(40, 121);
        counter = 0;
        isOn = true;
    }

    void EnableJumpscare()
    {
        randomSoundIndex = Random.Range(0, 17); 
        randomPosition1 = Random.Range(-18, 21);
        randomPosition2 = Random.Range(-18, 21);

        if (randomSoundIndex < 6)
        {
            SetAudioSource(audioSource1);
        }

        else if (randomSoundIndex >= 6 && randomSoundIndex < 8) { 

            SetAudioSource(audioSource2);
        }
        else if (randomSoundIndex >= 8 && tasksScript.isVictorBrookTask == false) 
        {
            MonsterJumpscare(randomMonsters[0]);
        }
    }

    void EnableSmallJumpscare() {

        randomSoundIndex = Random.Range(0, 14);
        randomPosition1 = Random.Range(-18, 21);
        randomPosition2 = Random.Range(-18, 21);

        if (randomSoundIndex < 6)
        {
            SetAudioSource(audioSource1);
        }

        else if (randomSoundIndex >= 6 && randomSoundIndex < 14)
        {

            SetAudioSource(audioSource2);
        }
    }

    void EnableMonsterJumpscare()
    {
        randomSoundIndex = Random.Range(11, 19); 
        randomPosition1 = Random.Range(-18, 21);
        randomPosition2 = Random.Range(-18, 21);

        if (randomSoundIndex >= 14 && randomSoundIndex < 17)
        {
            MonsterJumpscare(randomMonsters[0]);
        }
        else if (randomSoundIndex == 11 || randomSoundIndex == 12 ||randomSoundIndex == 17)
        {
            MonsterJumpscare(randomMonsters[1]);
        }
        else if (randomSoundIndex == 13 || randomSoundIndex == 18)
        {
            MonsterJumpscare(randomMonsters[2]);
        }

        counter = 0;
        isOn = true;

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("JumpscareArea"))
        { 
            isPossibleTerrain = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("JumpscareArea"))
        { 
            isPossibleTerrain = true;
        }
    }

    public void DisableMonsters()
    {

        foreach(var monster in randomMonsters)
        {
            monster.monster.gameObject.SetActive(false);
            monster.monsterScript.enabled = false;
        }

        counter = 0;

    }

    void MonsterJumpscare(RandomMonsters randomMonster)
    {
        StartCoroutine(MonsterJumpscare_IE(randomMonster));
    }

    IEnumerator MonsterJumpscare_IE(RandomMonsters randomMonster)
    {
        RandomMonsterPosition(randomMonster);
        yield return new WaitForEndOfFrame();
        CheckMonsterPosition(randomMonster);

    }

    void RandomMonsterPosition(RandomMonsters randomMonster)
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
        intPlayerX = (int)playerX + randomMonsterPosition1; 
        intPlayerZ = (int)playerZ + randomMonsterPosition2; 
        terrainY = Terrain.activeTerrain.SampleHeight(audioSource3.transform.position);
        randomMonster.monster.transform.position = new Vector3(intPlayerX, terrainY, intPlayerZ);
        randomMonster.monster.gameObject.SetActive(true);
        randomMonster.monsterScript.enabled = true;
    }

    void CheckMonsterPosition(RandomMonsters randomMonster)
    {

        if (randomMonster.monsterScript.isPathPossible == true)
        {
            ExecuteMonsterJumspcare(randomMonster);
            StopAllCoroutines();
            counter = 0;
        }
        else
        {
            MonsterJumpscare(randomMonster);
            counter = 0;
        }
    }

    void ExecuteMonsterJumspcare(RandomMonsters randomMonster)
    {

        audioSource3.transform.position = new Vector3(player.transform.position.x + randomMonsterPosition1, player.transform.position.y, player.transform.position.z + randomMonsterPosition2);
        audioSource3.pitch = Random.Range(0.8f, 1.1f);
        audioSource3.clip = sounds[randomSoundIndex];
        audioSource3.Play();
        randomMonster.monster.gameObject.SetActive(true);
        randomMonster.monsterScript.enabled = true;
        randomMonster.monsterAudioSource.enabled = true;
        randomMonster.monsterMeshRender.enabled = true;

        randomDuration = Random.Range(40, 121);
        counter = 0;
        isOn = true;

    }

}
