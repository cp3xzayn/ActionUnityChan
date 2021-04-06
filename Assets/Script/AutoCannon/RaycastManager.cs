using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    [SerializeField] GameObject m_hitPoint = null;
    bool isMoveHitPoint = true;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (isMoveHitPoint)
            {
                m_hitPoint.transform.position = hit.point;
            }
            if (hit.collider.gameObject.tag == "Field")
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    isMoveHitPoint = false;
                }
            }
        }
    }
}
