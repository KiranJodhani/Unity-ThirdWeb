using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public string MySpawner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y < -10)
        {
            if(!string.IsNullOrEmpty(MySpawner))
            {
                GameObject Spawner = GameObject.Find(MySpawner);
                Spawner.GetComponent<EnemySpawner>().SpawnEnemy();
            }
            Destroy(gameObject);
        }
    }

     
}
