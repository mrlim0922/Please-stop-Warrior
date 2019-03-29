using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Vector3 MousePosition;

    void Start () {
        
	}
	
	void Update () {
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        MousePosition = /*Camera.main.ScreenToWorldPoint*/(Input.mousePosition);

        //MousePosition.z += 10;
        MousePosition.x -= 500;
        MousePosition.y -= 970;

        Debug.Log(MousePosition);

        transform.localPosition = MousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        transform.position = startPosition;
    }
}
