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

    public GameObject plusObject;
    private FeverGauge feverGauge;
    // public TextMeshProUGUI plusText;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        feverGauge = FindObjectOfType<FeverGauge>();
    }
    public void Update()
    {
        // Clicker
        ScoreText.text = "Score: $ " + (int)CurrentScore;
        ScoreIncreasedPerSecond = PerSecondPlus * Time.deltaTime;
        CurrentScore = CurrentScore + ScoreIncreasedPerSecond;

        //plusText.text = "+ " + HitPower;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Hit();
    }

    public void Hit()
    {
        // 1. 애니메이션 실행
        PlayHitAnimation();

        // 2. 정해진 시간 안에 커졌다가 작아져야합니다.
        StartCoroutine(ScaleUpDown_Coroutine());

        CurrentScore += HitPower;

        Quaternion rotatedRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180f, transform.rotation.eulerAngles.z);
        Instantiate(plusObject, transform.position, rotatedRotation);
    }

    IEnumerator Fly()
    {
        for(int i = 0; i <= 19; i++)
        {
            yield return new WaitForSeconds(0.01f);

            plusObject.transform.position = new Vector3(plusObject.transform.position.x, plusObject.transform.position.y +2, 0);
        }
        plusObject.SetActive(false);
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
