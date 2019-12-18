using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]private GameObject enemyPrefab;//序列化
    private GameObject _enemy;

    void Update()
    {
        if (_enemy == null)//先判断是否存在敌人对象
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            //复制预设体
            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
