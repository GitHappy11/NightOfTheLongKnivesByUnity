using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//这里的知识点很简单，关键还是Canvas画布的设置
public class DamagerNum : MonoBehaviour
{
    public Text txtDamager;
    //字体存在时间
    public float lifeTime;
    //向上浮动的速度
    public float upSpeed;

    private void Start()
    {
        //这里如果使用动画，可以用动画事件
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position += new Vector3(0, upSpeed * Time.deltaTime,0);
    }

    public void ShouUI(float amount)
    {
        txtDamager.text = amount.ToString();
    }
}
