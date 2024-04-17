using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickEffect : MonoBehaviour
{
    public TextMeshProUGUI PowerText;
    public FeverGauge _FeverGauge;

    public GameObject canvas;
    public int x, y, z;

    public float Timer;
    public int speed;

    private Frog frog;
    private float _lastHitPower;
    void Start()
    {
        Timer = 0;

        frog = FindObjectOfType<Frog>();

        canvas = GameObject.Find("Canvas");
        transform.SetParent(canvas.transform);

        x = Random.Range(-250, 200);
        y = Random.Range(-200, 200);
        gameObject.transform.Rotate(new Vector3(0, 0, 0));
        transform.localPosition = new Vector3(x, y, z);

        // 텍스트 메시 컴포넌트 가져오기
        PowerText = GetComponent<TextMeshProUGUI>();

        // 텍스트 메시 레이캐스트 비활성화
        if (PowerText != null)
        {
            PowerText.raycastTarget = false;
        }
        _lastHitPower = frog.HitPower;
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= 1f) 
        { 
            Destroy(this.gameObject);
        }

        PowerText.text = "+ " + frog.HitPower;

         


         transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed, 0);
        
    }
}
