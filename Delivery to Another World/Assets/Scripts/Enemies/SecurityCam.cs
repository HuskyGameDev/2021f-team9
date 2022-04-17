using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCam : MonoBehaviour
{

    public Transform lights;
    public MeshRenderer glow;
    public float speed;
    public Material camGlow;
    public Material camGlowReverse;
    public Animator animator;

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
                lights.localEulerAngles = new Vector3(lights.localEulerAngles.x, Mathf.Lerp(lights.localEulerAngles.y, 130f, Time.deltaTime / speed), lights.localEulerAngles.z);
                if (lights.localEulerAngles.y <= 131f)
                {
                    reverse = true;
                    StartCoroutine(Pause());
                }

                if (lights.localEulerAngles.y < 180f)
                {
                    glow.material = camGlowReverse;
                }
            }
            else
            {
                lights.localEulerAngles = new Vector3(lights.localEulerAngles.x, Mathf.Lerp(lights.localEulerAngles.y, 230f, Time.deltaTime / speed), lights.localEulerAngles.z);
                if (lights.eulerAngles.y >= 229f)
                {
                    reverse = false;
                    StartCoroutine(Pause());
                }

                if (lights.localEulerAngles.y > 180f)
                {
                    glow.material = camGlow;
                }
            }
        }
        
    }

    private IEnumerator Pause()
    {
        canMove = false;
        yield return new WaitForSeconds(1f);
        canMove = true;
        if (!reverse)
        {
            animator.Play("Base Layer.CameraAnimation");
        }
        else
        {
            animator.Play("Base Layer.CameraBackAnimation");
        }
    }
}
