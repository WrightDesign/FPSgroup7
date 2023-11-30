using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//shane wright
//10-2023
public class Enemy : MonoBehaviour
{
    public GameObject trackPoint;
/*     public GameObject trackPoint; */

    private Vector3 trackPos;
    /* private Vector3 trackPos; */

    public float speed;

    public bool goingLeft;
    public bool goingBack;

    private Rigidbody rigidbody;

    private int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        trackPos = trackPoint.transform.position;
        trackPos = trackPoint.transform.position;
        rigidbody = GetComponent<Rigidbody>();       
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Debug.Log("laserHit");
            other.gameObject.SetActive(false);
            i++;
            if (i == 5)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void EnemyMove()
    {

        transform.position = Vector3.MoveTowards(transform.position, trackPoint.transform.position, speed * Time.deltaTime);
        
       /*  if (goingBack == true)
        {
            if (transform.position.z <= trackPos.z)
            {
                goingBack = false;
            }
            else
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
        }

        else
        {
            if (transform.position.z >= trackPos.z)
            {
                goingBack = true;
            }
            else
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
        }
        
        if (goingLeft == true)
        {
            if (transform.position.x <= trackPos.x)
            {
                goingLeft = false;
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }

        else
        {
            if (transform.position.x >= trackPos.x)
            {
                goingLeft = true;
            }
            else
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        } */
    }


}
