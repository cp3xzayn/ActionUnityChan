using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float m_rotateSpeed = 3;

    void Update()
    {
        this.transform.Rotate(0, m_rotateSpeed, 0);
    }
}
