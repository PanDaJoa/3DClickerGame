using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickEffect : MonoBehaviour
{
    public TextMeshProUGUI DamageText;
    

    public GameObject canvas;
    public int x, y;

    public float Timer;
    public int speed;

    private Frog frog;
    void Start()
    {
        Timer = 0;

        canvas = GameObject.Find("Canvas");
        transform.SetParent(canvas.transform);

        x = Random.Range(-150, 151);
        x = Random.Range(-150, 151);

        transform.localPosition = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= 1f)
        {
            Destroy(this.gameObject);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed, 0);
        DamageText.text = "+ " + frog.HitPower;

    }
}
