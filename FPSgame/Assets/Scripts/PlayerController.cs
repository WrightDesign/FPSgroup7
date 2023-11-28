using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//wright shane
//10-2023
public class PlayerController : MonoBehaviour
{
    public float coinsCollected = 0;
    public float jumpForce = 10f;
    public float speed = 18f;
    private Rigidbody rigidbody;

    public int lives = 3;
    public int fallDepth;
    private Vector3 startPos;

    private bool stunned = false;
    public bool attackState = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s") && stunned == false)
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        if (Input.GetKey("w") && stunned == false)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey("a") && stunned == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey("d") && stunned == false)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey("e"))
        {
            StartCoroutine(AttackTimer());
        }

        HandleJumping();

        if (transform.position.y < fallDepth)
        {
            Respawn();
        }
    }

    private void CheckForDanger()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.up, out hit, 1f))
        {
            if (hit.collider.tag == "Thwomp")
            {
                Respawn();
            }
        }
    }

    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;

            Debug.DrawLine(transform.position, transform.position + Vector3.up * 1f, Color.red);
            Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.5f, Color.red);
           
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                Debug.Log("Touching Grass");
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinsCollected++;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Enemy" && attackState == false)
        {
            Respawn();
        }

        if (other.gameObject.tag == "Enemy" && attackState == true)
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Portal")
        {
            startPos = other.gameObject.GetComponent<Portal>().spawnPoint.transform.position;

            transform.position = startPos;
        }

        if (other.gameObject.tag == "")
        {
            StartCoroutine(StunnedTimer());
        }

        if (other.gameObject.tag == "Crate" && attackState == true)
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Spikes")
        {
            Respawn();
        }
    }

    IEnumerator StunnedTimer()
    {
        stunned = true;
        yield return new WaitForSeconds(2f);
        stunned = false;
    }

    IEnumerator AttackTimer()
    {
        attackState = true;
        yield return new WaitForSeconds(1f);
        attackState = false;
    }

    private void Respawn()
    {
        lives--;
        transform.position = startPos;

        if (lives == 0)
        {
            SceneManager.LoadScene(1);
        }
    }

}
