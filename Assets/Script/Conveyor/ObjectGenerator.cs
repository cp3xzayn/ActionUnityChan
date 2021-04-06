using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_cube = null;
    [SerializeField] GameObject m_sphere = null;
    [SerializeField] GameObject[] m_spawnPoint = null;
    [SerializeField] int m_spawnLength = 10;
    [SerializeField] float m_generateTime = 1.0f;

    private void Start()
    {
        StartCoroutine("StartGenerate");
    }

    IEnumerator StartGenerate()
    {
        for (int i = 0; i < m_spawnLength; i++)
        {
            int spawnIndex = Random.Range(0, m_spawnPoint.Length);
            int a = Random.Range(0, 10);
            if (a >= 0 && a <= 8)
            {
                Instantiate(m_cube, m_spawnPoint[spawnIndex].transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(m_sphere, m_spawnPoint[spawnIndex].transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(m_generateTime);
            if (i == m_spawnLength)
            {
                yield break;
            }
        }
    }
}
