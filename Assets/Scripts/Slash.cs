using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    //随机伤害
    [SerializeField]
    private float minDamage;
    [SerializeField]
    private float maxDamage; 

    //最终确定的伤害
    [HideInInspector]  
    public float attackDamage;

    //显示伤害的画布
    public GameObject damagerCanvas;
    //攻击次数
    private int attackCount;
    //动画事件 动画播放完毕后执行 
    //打开动画窗口，右击你想要执行方法的那一帧，右边检查窗口添加即可
    //动画和方法所在的脚本必须在同一对象上
    private bool isAttacked;
    public void EndAttack()
    {
        gameObject.SetActive(false);
        isAttacked = false;
        attackCount++;
        Debug.LogWarning(attackCount);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //敌人标签为Enemy且不处于不能被攻击状态
        if (other.gameObject.tag=="Enemy" && isAttacked==false)
        {
            //造成伤害后禁止重复造成伤害
            //isAttacked = true;
            //随机化伤害
            attackDamage = Random.Range(minDamage, maxDamage);
            other.gameObject.GetComponent<Enemy>().TakeDamager(attackDamage);

            //显示伤害UI
            DamagerNum damagerNum = Instantiate(damagerCanvas, other.transform.position, Quaternion.identity).GetComponent<DamagerNum>();
            //显示Text 整数显示
            damagerNum.ShouUI(Mathf.RoundToInt(attackDamage));

            //击退效果 反方向移动 从角色中心点【当前位置】  向敌人位置方向【目标点】移动   
            Vector2 difference = other.transform.position - transform.position;
            ////向量化
            difference.Normalize();
            
            other.transform.position = new Vector3(other.transform.position.x + difference.x, other.transform.position.y, +difference.y);
        }
        
    }

   
}
