using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RainSpawner : MonoBehaviour
{
    private float timer = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isLive) return;
        timer += Time.deltaTime;
        if (timer > GameManager.instance.spawnRate)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject rain = GameManager.instance.rainManager.Get(0);
        rain.transform.position = new Vector3(Random.Range(-9f, 9f), 6, 0);
        
    }
    
}
