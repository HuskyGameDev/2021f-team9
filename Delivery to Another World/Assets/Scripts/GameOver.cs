using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Image gameOverImage;

    private bool gameover;

    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
    }

    public void gameOverMan()
    {
        gameover = true;
    }

    void FixedUpdate()
    {
        if (gameover)
        {
            gameOverImage.color = new Color(255f, 255f, 255f, Mathf.Lerp(gameOverImage.color.a, 1f, Time.deltaTime / 3f));
        }
    }
}
