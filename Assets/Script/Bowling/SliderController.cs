using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] Slider m_zSlider = null;
    [SerializeField] Slider m_ySlider = null;
    [SerializeField] GameObject m_ball = null;
    Ball ballController;
    bool isZIncrease = false;
    bool isYIncrease = false;
    TurnState turnState;
    private float m_zPower;
    private float m_yPower;

    public float ZPower
    {
        get { return m_zPower * 100; }
    }

    public float YPower
    {
        get { return m_yPower * 100; }
    }

    void Start()
    {
        m_zSlider.GetComponent<Slider>();
        m_ySlider.GetComponent<Slider>();
        ballController = m_ball.GetComponent<Ball>();
    }

    void Update()
    {
        switch (turnState)
        {
            case TurnState.ZDecide:
                if (isZIncrease)
                {
                    m_zSlider.value += 0.01f;
                    if (m_zSlider.value == 1)
                    {
                        isZIncrease = false;
                    }
                }
                else
                {
                    m_zSlider.value -= 0.01f;
                    if (m_zSlider.value == 0)
                    {
                        isZIncrease = true;
                    }
                }
                if (Input.GetButtonDown("Fire1"))
                {
                    m_zPower = m_zSlider.value;
                    turnState = TurnState.YDecide;
                }
                break;
            case TurnState.YDecide:
                if (isYIncrease)
                {
                    m_ySlider.value += 0.01f;
                    if (m_ySlider.value == 1)
                    {
                        isYIncrease = false;
                    }
                }
                else
                {
                    m_ySlider.value -= 0.01f;
                    if (m_ySlider.value == 0)
                    {
                        isYIncrease = true;
                    }
                }
                if (Input.GetButtonDown("Fire1"))
                {
                    m_yPower = m_ySlider.value;
                    turnState = TurnState.Decided;
                }
                break;
            case TurnState.Decided:
                ballController.Shot();
                break;
            default:
                break;
        }
    }
}

public enum TurnState
{
    ZDecide,
    YDecide,
    Decided
}
