using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    //序列化私有变量
    private GameObject _fireball;

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    bool _alive;
    private void Start()
    {
        _alive = true;
    }
    private void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                //获取射线碰到的物体的实例
                if (hitObject.GetComponent<PlayerCharacter>())
                {//检测物体上的脚本组件
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        //实例化子弹预设体
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        //子弹方向与物体前进方向相同
                        _fireball.transform.rotation = transform.rotation;
                        //旋转方式跟物体旋转方式一样
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
