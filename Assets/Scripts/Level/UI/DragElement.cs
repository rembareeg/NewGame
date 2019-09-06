using UnityEngine;
using UnityEngine.EventSystems;

public class DragElement : EventTrigger
{
    
    private RectTransform _bounds;

    private bool _dragging;

    private void Awake()
    {
        _bounds = transform.parent.GetComponent<RectTransform>();
    }

    public void Update()
    {
        if (_dragging && _bounds.rect.Contains(_bounds.InverseTransformPoint(Input.mousePosition)))
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        _dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _dragging = false;
    }

    
}