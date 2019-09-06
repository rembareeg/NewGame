using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    [SerializeField]
    public RectTransform Rect;
    private Vector3 _desiredPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rect.anchoredPosition3D = Vector3.Lerp(Rect.anchoredPosition3D, _desiredPosition, 0.1f);
    }

    public void LevelSelect()
    {
        _desiredPosition = Vector3.left * 960;
    }

}
