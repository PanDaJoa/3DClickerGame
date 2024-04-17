using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FeverGauge : MonoBehaviour
{
    public float increaseRate = 0.1f;  // 게이지가 증가하는 속도
    public float decreaseRate = 0.05f; // 게이지가 감소하는 속도
    private float GaugeValue  = 0f;   // 현재 게이지 값
    public float maxGaugeValue = 1.0f; // 게이지 최대 값
   
    bool isHitPowerDoubled = false; // 게이지 두배 확인
    private bool hasClicked = false; // 마우스 클릭 확인
    public Slider FeverUI;

    public Frog _frog;

    private void Start()
    {
        _frog = FindObjectOfType<Frog>();
    }
    void Update()
    {
        FeverUI.value = GaugeValue / maxGaugeValue;
        if (Input.GetMouseButton(0))
        {
           IncreaseGauge();
        }
        else
        {
            DecreaseGauge();
        }
    }

    void IncreaseGauge() // 증가
    {
        if (GaugeValue < 0.95f && GaugeValue + increaseRate * Time.deltaTime >= 0.95f)
        {
            _frog.HitPower *= 2f;
            isHitPowerDoubled = true; 
        }

        // 게이지 증가
        GaugeValue += increaseRate * Time.deltaTime;
        GaugeValue = Mathf.Clamp(GaugeValue, 0.0f, maxGaugeValue);
        Debug.Log("게이지 증가: " + GaugeValue);

        if (isHitPowerDoubled && GaugeValue < 0.95f)
        {
            _frog.HitPower /= 2f;
            isHitPowerDoubled = false;
        }
    }

    void DecreaseGauge() // 감소
    {
        GaugeValue -= decreaseRate * Time.deltaTime;
        GaugeValue = Mathf.Clamp(GaugeValue, 0.0f, maxGaugeValue);
        Debug.Log("게이지 감소: " + GaugeValue);
    }
}
