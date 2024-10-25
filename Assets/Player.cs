using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform LPos, MPos, RPos;
    private int state = 1;
    public Manager manager;
    public GameObject canvas, spawner;
    public int score=0;
    public TMP_Text text;
    public bool invincivble = false;
    float invincount = 0;
    public GameObject race;
    public bool MoveL=false, MoveR=false;
    void Start()
    {
        transform.position = MPos.position;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincivble)
        {
            Time.timeScale = 5;
            invincount += Time.deltaTime;
            transform.position = MPos.position;
            GetComponent<Renderer>().enabled = false;
            race.SetActive(true);
        }
        if (invincount>=25)
        {
            invincivble = false;
            invincount = 0;
            Time.timeScale = 1;
            race.SetActive(false);
            GetComponent<Renderer>().enabled = true;
        }
        text.text = score.ToString();
        if (MoveL&&!invincivble)
        {
            if (state > 0)
            {
                state--;
                transform.DORotate(new Vector3(0,0,30), 0.25f);
                transform.DORotate(new Vector3(0, 0, 0), 0.25f).SetDelay(0.25f);
                Move();
            }
        }
        if (MoveR&&!invincivble)
        {
            if (state < 2)
            {
                state++;
                transform.DORotate(new Vector3(0, 0, -30), 0.25f);
                transform.DORotate(new Vector3(0, 0, 0), 0.25f).SetDelay(0.25f);
                Move();
            }
        }
        
    }
    void Move()
    {
        MoveL = false;
        MoveR = false;
        if (state==0 && transform.position != LPos.position)
        {
            transform.DOMove(LPos.position, 0.5f);
        }
        if (state == 1 && transform.position != MPos.position)
        {
            transform.DOMove(MPos.position, 0.5f);
        }
        if (state == 2 && transform.position != RPos.position)
        {
            transform.DOMove(RPos.position, 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle")&& invincivble==false)
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
            spawner.SetActive(false);
        }
        if (collision.CompareTag("Gold"))
        {
            score += 1;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Super"))
        {
            invincivble = true;
            Destroy(collision.gameObject);
        }
    }
}
