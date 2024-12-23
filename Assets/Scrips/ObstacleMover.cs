using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Manager.Instance.IsGameOver())
        {
            return;
        }

        float x = Manager.Instance.fObstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        if (transform.position.x < -10)
        {
            Destroy(this.gameObject);
            //Debug.Log("DESTROY");
        }
        
    }
}
