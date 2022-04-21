using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVision : MonoBehaviour
{

    public Transform lights;
    public float speed;

    private bool reverse;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        reverse = false;
        canMove = true;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (!reverse)
            {
                lights.localEulerAngles = new Vector3(lights.localEulerAngles.x, Mathf.Lerp(lights.localEulerAngles.y, 90f, Time.deltaTime / speed), lights.localEulerAngles.z);
                if (lights.localEulerAngles.y <= 131f)
                {
                    reverse = true;
                    StartCoroutine(Pause());
                }
            }
            else
            {
                lights.localEulerAngles = new Vector3(lights.localEulerAngles.x, Mathf.Lerp(lights.localEulerAngles.y, 270f, Time.deltaTime / speed), lights.localEulerAngles.z);
                if (lights.localEulerAngles.y >= 229f)
                {
                    reverse = false;
                    StartCoroutine(Pause());
                }
            }
        }

    }

    private IEnumerator Pause()
    {
        canMove = false;
        yield return new WaitForSeconds(1f);
        canMove = true;
    }
}
