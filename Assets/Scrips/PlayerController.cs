using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidBody;
    public float jumpPower = 10f;
    public float jumpInterval = 0.5f;
    private float jumpCooldown = 0;



    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        jumpCooldown -= Time.deltaTime;
        bool isGameActive = Manager.Instance.IsGameActive();
        bool bCanJump = jumpCooldown <= 0 && isGameActive;

        if (bCanJump)
        {
            bool bJumpInput = Input.GetKey(KeyCode.Space);
            if (bJumpInput)
            {
                Jump();
            }
        }

        thisRigidBody.useGravity = isGameActive;

        if (isGameActive)
        {
            if (thisRigidBody.velocity.y > 0)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 30);
            }
            else
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, -30);
            }
        }
    }

    void Jump()
    {
        jumpCooldown = jumpInterval;

        thisRigidBody.velocity = Vector3.zero;
        thisRigidBody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnCustomCollisionEnter(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCustomCollisionEnter(GameObject other)
    {
        bool isSensor = other.gameObject.CompareTag("Sensor");
        if (isSensor)
        {
            //pontuacao++
            Manager.Instance.score++;
        }
        else
        {
            //gameover
            Debug.Log("OnCollisionEnter Gameover");
            Manager.Instance.EndGame();

            StartCoroutine(ReloadScene(3));
        }
    }

    private IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene("SampleScene");

        //Debug.Log("RELOAD");
    }


}
