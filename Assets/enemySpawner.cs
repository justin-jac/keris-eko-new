using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    private Transform[] pos;
    public GameObject enemyPrefabs;
    public GameObject player;
    public float interval;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = interval;
        pos = new Transform[8];
        for(int i = 0; i < pos.Length; i++)
        {
            pos[i] = this.gameObject.transform.GetChild(i).gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            spawn();
            time = interval;
        }
    }

    void spawn()
    {
        int indPos = Random.Range(0, pos.Length);
        Instantiate(enemyPrefabs, pos[indPos].position, transform.rotation);
    }
}
