using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject[] path;
    public int moveSpeed;
    public bool isReverse;

    private bool canMove;
    private int currentPath;
    private bool dimensionActive;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        currentPath = 1;
    }

    // Update is called once per frame
    void Update()
    {
        dimensionActive = FindObjectOfType<RotationGravity>().dimensionActive;
        MeshRenderer[] meshes = GetComponentsInChildren<MeshRenderer>();
        Collider[] colliders = GetComponentsInChildren<MeshCollider>();

        if (dimensionActive && isReverse)
        {
            for (int i = 0; i < meshes.Length; i++)
            {
                meshes[i].enabled = true;
            }
            for(int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = true;
            }
        }
        else if(!dimensionActive && !isReverse)
        {
            for (int i = 0; i < meshes.Length; i++)
            {
                meshes[i].enabled = true;
            }
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < meshes.Length; i++)
            {
                meshes[i].enabled = false;
            }
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (Vector3.Distance(transform.position, path[currentPath].transform.position) < 0.2f)
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
                if (!isReverse)
                {
                    transform.eulerAngles = new Vector3(0f, -90f, 0f);
                    //transform.eulerAngles = new Vector3(0f, Mathf.Lerp(transform.eulerAngles.y, 270f, Time.deltaTime), 0f);
                }
            }
            // Positive X
            else if (transform.position.x < path[currentPath].transform.position.x - 0.1f)
            {
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                // Face in the positive X direction
                if (!isReverse)
                {
                    transform.eulerAngles = new Vector3(0f, 90f, 0f);
                    //transform.eulerAngles = new Vector3(0f, Mathf.Lerp(transform.eulerAngles.y, 90f, Time.deltaTime), 0f);
                }
            }

            // Negative Z
            if (transform.position.z > path[currentPath].transform.position.z + .1f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveSpeed * Time.deltaTime);
                if (isReverse)
                {
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                    //transform.eulerAngles = new Vector3(0f, Mathf.Lerp(transform.eulerAngles.y, 180f, Time.deltaTime), 0f);
                }
            }

            // Positive Z
            else if (transform.position.z < path[currentPath].transform.position.z - 0.1f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed * Time.deltaTime);
                if (isReverse)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    //transform.eulerAngles = new Vector3(0f, Mathf.Lerp(transform.eulerAngles.y, 0f, Time.deltaTime), 0f);
                }
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
