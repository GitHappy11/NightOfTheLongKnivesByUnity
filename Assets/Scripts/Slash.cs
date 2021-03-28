using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public float attackDamage;

    //动画事件 动画播放完毕后执行 
    //打开动画窗口，右击你想要执行方法的那一帧，右边检查窗口添加即可
    //动画和方法所在的脚本必须在同一对象上
    public void EndAttack()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Enemy")
        {

            other.gameObject.GetComponent<Enemy>().TakeDamager(attackDamage);
        }
        //击退效果 反方向移动 从角色中心点【当前位置】  向敌人位置方向【目标点】移动   需要向量化
        Vector2 difference = other.transform.position - transform.position;
        other.transform.position = new Vector3(other.transform.position.x + difference.x, other.transform.position.y, +difference.y);
    }

   
}
