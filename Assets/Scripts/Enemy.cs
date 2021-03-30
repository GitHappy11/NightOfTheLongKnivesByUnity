using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //目标（玩家）位置
    private Transform target;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float maxHP;
    public float hp;

    ////敌人是否收到伤害（无敌模式）
    //[HideInInspector]
    //public bool isAttacked;

    //死亡后产生爆炸效果
    public GameObject explosionEffect;

    //材质
    private SpriteRenderer sp;
    //受伤时间（颜色变化时间）
    public float hurtLength;
    //受伤计时器
    private float hurtCounter;
    //受伤次数
    private int hurtCount;

    public Rigidbody2D rb;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        hp = maxHP;
        //设定追踪目标
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        FollowPlayer();
        //计数受伤次数，用处就是受伤材质的显示长度 别老一直播放 一直是白色
        if (hurtCounter<=0)
        {
            sp.material.SetFloat("_FlashAmount", 0);
        }
        else
        {
            hurtCounter -= Time.deltaTime;
        }

    }

    private void FollowPlayer()
    {
        //追踪目标【当前位置，目标位置，追踪速度】
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    public void TakeDamager(float amount)
    {
        hp -= amount;
        HurtShader();
        hurtCount++;
        Debug.Log(hurtCount);
        if (hp<=0)
        {
            //生成死亡特效
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }

    //受伤后调整材质
    private void HurtShader()
    {
        sp.material.SetFloat("_FlashAmount", 1);
        hurtCounter = hurtLength;
    }
}
