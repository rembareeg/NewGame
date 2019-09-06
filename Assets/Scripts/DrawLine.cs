using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawLine : MonoBehaviour
{

    /* private LineRenderer _line;
     private GameObject _lineObject;
     private Vector3 _touchPosition;
     [SerializeField]
     private Material _material;
     private int _currLines = 0;


     // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {
         if (Input.GetMouseButtonDown(0))
         {
             if (_line == null)
             {
                 CreateLine();
             }

             _touchPosition = Camera.main.ScreenToWorldPoint(Input.touchPositionition);
             _touchPosition.z = 0;
             _line.SetPosition(0, _touchPosition);
             _line.SetPosition(1, _touchPosition);
         }
         else if (Input.GetMouseButtonUp(0) && _line)
         {
             _touchPosition = Camera.main.ScreenToWorldPoint(Input.touchPositionition);
             _touchPosition.z = 0;
             _line.SetPosition(1, _touchPosition);
             _lineObject.AddComponent<PolygonCollider2D>();
             _line = null;
             _lineObject = null;
             _currLines++;
         } else if (Input.GetMouseButton(0) && _line)
         {
             _touchPosition = Camera.main.ScreenToWorldPoint(Input.touchPositionition);
             _touchPosition.z = 0;
             _line.SetPosition(1, _touchPosition);
         }
     }

     void CreateLine()
     {
         _lineObject = new GameObject("Line" + _currLines);
         _line = _lineObject.AddComponent<LineRenderer>();        
         _line.material = _material;
         _line.positionCount = 2;
         _line.startWidth = 0.20f;
         _line.endWidth = 0.20f;
         _line.useWorldSpace = true;
         _line.numCapVertices = 80;
     }


 
 */

    private LineRenderer line; // Reference to LineRenderer
    private Vector3 touchPosition;
    private Vector3 startPos;    // Start position of line
    private Vector3 endPos;    // End position of line
    private Touch touch;
    [SerializeField]
    private Material _material;
    void Update()
    {
        
        // On mouse down new line will be created 
        if (Input.touchCount > 0 && GameLogic.Instance.GameState == GameStates.GameState.Paused)
        {
            touch = Input.GetTouch(0);               

            if (touch.phase == TouchPhase.Began && !IsPointerOverUIObject())
            {
                if (line == null)
                    createLine();
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                line.SetPosition(0, touchPosition);
                line.SetPosition(1, touchPosition);
                startPos = touchPosition;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (line)
                {
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0;
                    line.SetPosition(1, touchPosition);
                    endPos = touchPosition;
                    addColliderToLine();
                    line = null;
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (line)
                {
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0;
                    line.SetPosition(1, touchPosition);
                }
            }
        }
    }
    // Following method creates line runtime using Line Renderer component
    private void createLine()
    {
        line = new GameObject("Line").AddComponent<LineRenderer>();
        line.material = _material;
        line.positionCount = 2;
        line.startWidth = 0.20f;
        line.endWidth = 0.20f;
        line.useWorldSpace = true;
        line.numCapVertices = 150;
    }
    // Following method adds collider to created line
    private void addColliderToLine()
    {
        BoxCollider2D col = new GameObject("Collider").AddComponent<BoxCollider2D>();
        col.transform.parent = line.transform; // Collider is added as child object of line
        float lineLength = Vector3.Distance(startPos, endPos); // length of line
        col.size = new Vector3(lineLength, 0.2f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
        Vector3 midPoint = (startPos + endPos) / 2;
        col.transform.position = midPoint; // setting position of collider object
        // Following lines calculate the angle between startPos and endPos
        float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
        if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
        {
            angle *= -1;
        }
        angle = Mathf.Rad2Deg * Mathf.Atan(angle);
        

        col.transform.Rotate(0, 0, angle);
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}