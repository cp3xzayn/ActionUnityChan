using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_cube = null;
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
            int s = Random.Range(0, m_spawnPoint.Length);
            Instantiate(m_cube, m_spawnPoint[s].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(m_generateTime);
            if (i == m_spawnLength)
            {
                yield break;
            }
        }
    }
}
