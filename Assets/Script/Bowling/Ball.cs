using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float m_zVelocity = 0;
    [SerializeField] float m_yVelocity = 0;
    Rigidbody rb;
    SliderController sliderController;
    [SerializeField] GameObject m_sliderController = null;

    bool isShot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sliderController = m_sliderController.GetComponent<SliderController>();
    }


    public void Shot()
    {
        if (isShot)
        {
            m_zVelocity = sliderController.ZPower;
            m_yVelocity = sliderController.YPower;
            rb.AddForce(0, m_yVelocity, m_zVelocity);
            isShot = false;
        }
    }
}
