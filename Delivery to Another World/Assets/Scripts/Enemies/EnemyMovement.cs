using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject[] path;
    public int moveSpeed;

    private bool canMove;
    private int currentPath;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
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
                    currentPath = 0;
                }
                else
                {
                    currentPath++;
                }
                
                StartCoroutine(Pause());
            }

            // Negative X
            if (transform.position.x > path[currentPath].transform.position.x + 0.1f)
            {
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                // Face in the negative X direction
                transform.eulerAngles = new Vector3(0f, -90f, 0f);
            }
            // Positive X
            else if (transform.position.x < path[currentPath].transform.position.x - 0.1f)
            {
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                // Face in the positive X direction
                transform.eulerAngles = new Vector3(0f, 90f, 0f);
            }

            // Negative Z
            if (transform.position.z > path[currentPath].transform.position.z + .1f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveSpeed * Time.deltaTime);
            }

            // Positive Z
            else if (transform.position.z < path[currentPath].transform.position.z - 0.1f)
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
