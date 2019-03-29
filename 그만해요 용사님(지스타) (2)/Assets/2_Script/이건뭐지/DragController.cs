using UnityEngine;
using System.Collections;

public class DragController : MonoBehaviour
{

    public Vector3 m_curPos;
    public Vector3 currentVector;
    public Vector3 m_prevPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_prevPos = m_curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentVector = transform.position;
        }

        if (Input.GetMouseButton(0))
        {

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(mousePosition);

            m_curPos = mousePosition;
            Vector3 gap = m_curPos - m_prevPos;
            gameObject.transform.position += gap;
            m_prevPos = m_curPos;

        }

        if (Input.GetMouseButtonUp(0))
        {
            transform.position = currentVector;
        }
    }

}