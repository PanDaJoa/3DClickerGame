using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Touch2 : MonoBehaviour
{
    public Animator _animator;
    public Touch touch;
    public GameObject prefab;
    public float scaleFactor = 1.5f; // 프리팹의 증가할 크기 배율
    public float scaleDuration = 0.5f; // 크기 변환에 걸리는 시간
    private Vector3 originalScale; // 초기 크기

    private bool isScaling = false; // 크기 조정 중인지 여부를 나타내는 플래그
    public void Start()
    {
        _animator = GetComponent<Animator>();
        originalScale = prefab.transform.localScale; // 초기 크기 저장
    }


    public void OnClickFrog()
    {
        touch.CurrentScore += touch.HitPower;

        PlayHitAnimation();

        Debug.Log("hit");
    }

    private void PlayHitAnimation()
    {
        _animator.SetTrigger("Hit");

    }

}
