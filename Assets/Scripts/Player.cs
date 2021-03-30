using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //此声明可以强制让依赖对象拥有Rigidbody2D组件，如果没有则会强制添加上去
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField]
    private float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveH = Input.GetAxis("Horizontal")*moveSpeed;
        moveV = Input.GetAxis("Vertical")*moveSpeed;
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV);
    }

    private void Flip()
    {
        //利用向量进行翻转图片进行转向
        //if (moveH>0)
        //{
        //    transform.eulerAngles = new Vector3(0, 0, 0);
        //}
        //if (moveH<0)
        //{
        //    transform.eulerAngles = new Vector3(0, 180, 0);
        //}

        //利用鼠标位置进行翻转图片转向
        //根据人物位置的x轴和鼠标位置的x轴的大小对比  进行翻转
        if (transform.position.x<Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
