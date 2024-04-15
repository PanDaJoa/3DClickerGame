using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Frog : MonoBehaviour, IPointerClickHandler
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("프로그 크릭");

        PlayHitAnimation();
    }

    private void PlayHitAnimation()
    {
        _animator.SetTrigger("Hit");

    }

    public void UpScale()
    {
        
    }
   public void DownScale()
    {

    }
}
