using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject name;
    bool play = false;
    private float count;
    public Player player;
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        count += Time.deltaTime;
        if (count >= 3) SceneManager.LoadScene("SampleScene");
        
    }
    public void PlayAgain() {
        
        SceneManager.LoadScene("SampleScene");
    }
    public void Play()
    {
        name.transform.DOMove(new Vector3(0, -10, 0), 3f);
        play = true;
    }
    public void MoveLeft()
    {
        player.MoveL = true;
    }
    public void MoveRight()
    {
        player.MoveR = true;
    }
}
