using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FeverGauge : MonoBehaviour
{
    public float increaseRate = 0.1f;  // 게이지가 증가하는 속도
    public float decreaseRate = 0.05f; // 게이지가 감소하는 속도
    public float GaugeValue = 0f;   // 현재 게이지 값
    public float maxGaugeValue = 1.0f; // 게이지 최대 값
    public float PowerDouble = 0.9f;

    bool isHitPowerDouble = false; // 게이지 두배 확인
    public Slider FeverUI;

    public Frog _frog;
    private Shop _shop;

    private void Start()
    {
        _frog = FindObjectOfType<Frog>();
    }
    void Update()
    {
        FeverUI.value = GaugeValue / 1; // 피버게이지 0 ~ 1로 만듬
        if (Input.GetMouseButtonDown(0))
        {
            IncreaseGauge();
        }

            DecreaseGauge();




        void IncreaseGauge() // 증가
        {
            GaugeValue += increaseRate;
            GaugeValue = Mathf.Clamp01(GaugeValue); // 0 ~ 1 사이로 클램프

            // 게이지가 0.95 미만인 경우에는 _frog.HitPower가 이미 2배가 되었다면 원래대로 돌아오도록 합니다.
            if (GaugeValue < PowerDouble && isHitPowerDouble)
            {
                _frog.HitPower /= 2f;

                isHitPowerDouble = false;
            }

        }

        void DecreaseGauge() // 감소
        {
            GaugeValue -= decreaseRate * Time.deltaTime;
            GaugeValue = Mathf.Clamp(GaugeValue, 0.0f, maxGaugeValue); // 0 ~ 1 0이하 1이상 넘어가지 않게 만듬

            if (GaugeValue < PowerDouble)
            {
                if (isHitPowerDouble)
                {
                    _frog.HitPower /= 2f;
                    isHitPowerDouble = false;
                }
            }
            else if (GaugeValue > PowerDouble && !isHitPowerDouble)
            {
                _frog.HitPower *= 2f;
                isHitPowerDouble = true;
            }

        }
    }
}
