using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    [SerializeField] GameObject m_hitPoint = null;
    /// <summary> 発射位置を移動できるか </summary>
    bool isMoveHitPoint = true;

    /// <summary> ターゲットの位置 </summary>
    private Vector3 m_targetPos;
    /// <summary> ターゲットの位置 </summary>
    public Vector3 TargetPos{ get { return m_targetPos; }　}

    /// <summary> 発射位置が決定されたか </summary>
    private bool isDecide = false;
    /// <summary> 発射位置が決定されたか </summary>
    public bool IsDecide {　 get { return isDecide; }　}

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (isMoveHitPoint)
            {
                m_hitPoint.transform.position
                    = new Vector3(hit.point.x, hit.point.y + 0.01f, hit.point.z);
            }
            if (hit.collider.gameObject.tag == "Field")
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    m_targetPos = hit.point;
                    isDecide = true;
                    isMoveHitPoint = false;
                }
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            isDecide = false;
            isMoveHitPoint = true;
        }
    }
}
