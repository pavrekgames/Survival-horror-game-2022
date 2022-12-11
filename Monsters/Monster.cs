using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Monster : MonoBehaviour {

    protected Transform player;
    protected CharacterController monsterController;
    protected Flashlight flashlightScript;
    protected Health healthScript;
    protected Crouch crouchScript;
    protected Jumpscare jumpscareScript;
    protected Map mapScript;
    protected Ray monsterAim;

    [Header("Monster components")]
    [SerializeField] protected Transform playerHead;
    [SerializeField] protected Transform monster;
    [SerializeField] protected NavMeshAgent monsterAgent;
    [SerializeField] protected Animator monsterAnimator;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip monsterSound;
    [SerializeField] protected AudioClip monsterAttackSound;

    [Header("Monster state")]
    public bool isSawPlayer = false;
    public bool isRayPlayer = false;
    public bool isSawLight = false;
    public bool isPathPossible = true;
    [SerializeField] protected bool isAttack = false;

    [Header("Monster movement")]
    [SerializeField] protected float walkVelocity = 5f;
    [SerializeField] protected float runVelocity = 7f;
    [SerializeField] protected float currentVelocity = 4.0f;
    [SerializeField] protected float rotationVelocity = 5.0f;
    [SerializeField] protected float height = 0f;

    [Header("Monster ray")]
    [SerializeField] protected float rayLength = 30f;

    public abstract void MonsterFollowsPoint();
    public abstract void MonsterFollowsPlayer(float _distance);
    public abstract void MonsterLongLight(float _distance);
    public abstract void MonsterFlashlight(float _distance);
    public abstract void MonsterRaycast(float _distance);
    public abstract void MonsterAttack(float _distance);

}
