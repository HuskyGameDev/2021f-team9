using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject[] path;
    public int moveSpeed;

    private bool canMove;
    private int currentPath;
    private bool direction;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        direction = true;
        currentPath = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (Mathf.Abs(transform.position.x - path[currentPath].transform.position.x) < 0.1f && Mathf.Abs(transform.position.z - path[currentPath].transform.position.z) < 0.1f)
            {
                if (currentPath >= path.Length - 1)
                {
                    direction = false;
                    StartCoroutine(Pause());
                }
                else if (currentPath == 0)
                {
                    direction = true;
                    StartCoroutine(Pause());
                }

                if (direction)
                {
                    currentPath++;
                }
                else
                {
                    currentPath--;
                }
            }

            // Negative X
            if (transform.position.x > path[currentPath].transform.position.x)
            {
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            // Positive X
            else if (transform.position.x < path[currentPath].transform.position.x)
            {
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }

            // Negative Z
            if (transform.position.z > path[currentPath].transform.position.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveSpeed * Time.deltaTime);
            }

            // Positive Z
            else if (transform.position.z < path[currentPath].transform.position.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator Pause()
    {
        canMove = false;
        yield return new WaitForSeconds(1f);
        canMove = true;
    }
}
