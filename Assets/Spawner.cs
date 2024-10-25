using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] arrayPos;
    private float LogSpawn=0, BoardSpawn=0, CoinSpawn=0, superSpawn=0;
    private int logRandom = 0, boardRandom = 0, coinRandom = 0, superRandom = 0;
    public GameObject Log, Board, coin, super;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LogSpawn += Time.deltaTime;
        BoardSpawn += Time.deltaTime;
        CoinSpawn += Time.deltaTime;
        superSpawn += Time.deltaTime;

        if (LogSpawn >= 4)
        {
            
            LogSpawn = 0;
            logRandom = Random.Range(0,2);
            if (BoardSpawn >= 5)
            {
                BoardSpawn = 0;
                if (logRandom == 2) boardRandom = 1;
                else boardRandom = logRandom + 1;
                Instantiate(Board, arrayPos[boardRandom].position, arrayPos[boardRandom].rotation);
            }
            Instantiate(Log, arrayPos[logRandom].position, arrayPos[logRandom].rotation);
        }
        if (BoardSpawn >= 6)
        {
            BoardSpawn = 0;
            boardRandom = Random.Range(0, 2);
            Instantiate(Board, arrayPos[boardRandom].position, arrayPos[boardRandom].rotation);
        }
        if (CoinSpawn >= 1)
        {
            CoinSpawn = 0;
            coinRandom = Random.Range(0, 2);
            Instantiate(coin, arrayPos[coinRandom].position, arrayPos[coinRandom].rotation);
        }
        if (superSpawn >= 100)
        {
            superSpawn = 0;
            superRandom = Random.Range(0, 2);
            Instantiate(super, arrayPos[superRandom].position, arrayPos[superRandom].rotation);
        }
    }
}
