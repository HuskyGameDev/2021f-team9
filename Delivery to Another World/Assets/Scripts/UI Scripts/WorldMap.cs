using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldMap : MonoBehaviour
{

    public Image defaultImage;
    public Image[] roomImages;
    public Image treasureRoomImage;

    private int sizeOfGrid;
    private int sizeOfSquares;
    private Image[] children;

    // Start is called before the first frame update
    void Start()
    {
        sizeOfGrid = FindObjectOfType<ProceduralGeneration>().difficulty;
        sizeOfSquares = 850 / sizeOfGrid;
        children = new Image[sizeOfGrid * sizeOfGrid];

        int offset = 450 - (sizeOfSquares / 2);

        for (int i = 0; i < sizeOfGrid; i++)
        {
            for (int j = 0; j < sizeOfGrid; j++)
            {
                Vector3 newPosition = new Vector3(transform.position.x - offset + (j * sizeOfSquares) + (j*10), transform.position.y - offset + (i * sizeOfSquares) + (i*10), 0f);
                children[(i * sizeOfGrid) + j] = Instantiate(defaultImage, newPosition, Quaternion.identity);
                children[(i * sizeOfGrid) + j].rectTransform.sizeDelta = new Vector2(sizeOfSquares, sizeOfSquares);
                children[(i * sizeOfGrid) + j].transform.SetParent(gameObject.transform);
                children[(i * sizeOfGrid) + j].GetComponent<Image>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Image[] childrens = GetComponentsInChildren<Image>();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GetComponent<Image>().enabled = true;
            for (int i = 0; i < childrens.Length; i++)
            {
                childrens[i].enabled = true;
            }
        }
        
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            GetComponent<Image>().enabled = false;
            for (int i = 0; i < childrens.Length; i++)
            {
                childrens[i].enabled = false;
            }
        }
    }

    public void updateSquare(int[] temp)
    {
        int xPos = temp[0];
        int yPos = temp[1];
        int prefabNum = temp[2];
        int index = (yPos * sizeOfGrid) + xPos;
        Vector3 position = new Vector3(children[index].transform.position.x, children[index].transform.position.y, 0f);
        Destroy(children[index].gameObject);
        if (FindObjectOfType<ProceduralGeneration>().inTreasureRoom)
        {
            children[index] = Instantiate(treasureRoomImage, position, Quaternion.identity);
        }
        else
        {
            children[index] = Instantiate(roomImages[prefabNum], position, Quaternion.identity);
        }
        children[index].rectTransform.sizeDelta = new Vector2(sizeOfSquares, sizeOfSquares);
        children[index].transform.SetParent(gameObject.transform);
        children[index].GetComponent<Image>().enabled = false;
    }
}
