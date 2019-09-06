using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    bool pressed = true;
    public void OpenPanel()
    {
        bool pressed = _animator.GetBool("Pressed");
        print(pressed);
        _animator.SetBool("Pressed", !pressed);
        //pressed = !pressed;
    }

    private void OnEnable()
    {
        pressed = true;
        _animator.SetBool("restarted", true);
        _animator.SetBool("restarted", false);
    }

}
