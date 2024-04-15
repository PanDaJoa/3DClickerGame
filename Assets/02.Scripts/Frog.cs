using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Frog : MonoBehaviour, IPointerClickHandler
{
    private Animator _animator;

    // Clicker
    public TextMeshProUGUI ScoreText;
    public float CurrentScore;
    public float HitPower;
    public float ScoreIncreasedPerSecond;
    public float PerSecondPlus;



    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Update()
    {
        // Clicker
        ScoreText.text = "Score: $ " + (int)CurrentScore;
        ScoreIncreasedPerSecond = PerSecondPlus * Time.deltaTime;
        CurrentScore = CurrentScore + ScoreIncreasedPerSecond;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("프로그 클릭");

        // 1. 애니메이션 실행
        PlayHitAnimation();

        // 2. 정해진 시간 안에 커졌다가 작아져야합니다.
        StartCoroutine(ScaleUpDown_Coroutine());

        CurrentScore += HitPower;
    }

    private float _upDurtioan = 0.1f;
    private float _downDuration = 0.1f;
    private Vector3 UP_VECTOR = new Vector3(12f, 12f, 12f);
    private Vector3 DOWN_VECTOR = new Vector3(10f, 10f, 10f);

    private IEnumerator ScaleUpDown_Coroutine()
    {
        float timer = 0f;
        float progress = 0;

        while(progress <= 1f)
        {
            timer += Time.deltaTime;
            progress = timer / _upDurtioan;

            Vector3 value = Vector3.Lerp(DOWN_VECTOR, UP_VECTOR, progress);
            transform.localScale = value;

            yield return null;
        }

        progress = 0f;
        while (progress <= 1f)
        {
            timer += Time.deltaTime;
            progress =  timer / _downDuration;

            Vector3 value = Vector3.Lerp(UP_VECTOR, DOWN_VECTOR, progress);
            transform.localScale = value;

            yield return null;
        }
    }
    private void PlayHitAnimation()
    {
        _animator.SetTrigger("Hit");
    }

 
}
