using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_enemy = null;
    
    [SerializeField] float m_enemyGenerateTime = 3;

    void Start()
    {
        StartCoroutine("InstantiateEnemy");
    }

    IEnumerator InstantiateEnemy()
    {
        while (true)
        {
            float x = Random.Range(-5f, 5f);
            float z = Random.Range(-5f, 5f);
            if (x > 1 || x < -1)
            {
                if (z > 1 || z < -1)
                {
                    Vector3 vec = new Vector3(x, 0.5f, z);
                    Instantiate(m_enemy, vec, Quaternion.identity);
                }
            }
            else
            {
                Debug.Log("生成範囲外です。");
            }
            yield return new WaitForSeconds(m_enemyGenerateTime);
        }
    }
}
