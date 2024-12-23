using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    private float fCooldown = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.Instance.IsGameOver())
        {
            return;
        }

        fCooldown -= Time.deltaTime;

        if(fCooldown < 0 )
        {
            fCooldown = Manager.Instance.fObjectInterval;

            int prefabIndex = Random.Range(0, Manager.Instance.obstaclePrefabs.Count - 1);

            GameObject prefab = Manager.Instance.obstaclePrefabs[prefabIndex];
            float x = Manager.Instance.xOffset;
            float y = Random.Range(Manager.Instance.yOffset.x, Manager.Instance.yOffset.y);
            float z = 0;


            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = prefab.transform.rotation;

            Instantiate(prefab, position, rotation);   


        }
    }
}
