using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 1.0f;
    public int damage = 1;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {//当触发器碰撞时触发方法
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {//判断对象是否为PlayerCharacter
            player.Hurt(damage);
        }
        Destroy(this.gameObject);
    }
}
