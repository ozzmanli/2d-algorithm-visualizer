using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    Text val;
    public Transform spawnPos;
    private Vector3 scaleChange;
    List<GameObject> squareList = new List<GameObject>();
    public GameObject Square;
    float thickness;
    float height;
    int n = 0;
    int squareIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        val = GetComponent<Text>();
        thickness = Square.transform.localScale.x;
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
        n = Mathf.RoundToInt(value);
        val.text = "number of elements : " + Mathf.RoundToInt(value);

        if (n < squareIndex)
        {
            for (int i = squareIndex; i > n; i--)
            {
                Destroy(squareList[i - 1]);
                squareList.RemoveAt(i - 1);
                squareIndex--;
            }
        }
        else
        {
            for (int j = squareIndex; j < n; j++)
            {
                height = Random.Range(0, 5.0F);
                scaleChange = new Vector3(thickness, height, 1f);
                Square.transform.localScale = scaleChange;
                GameObject newSquareObject = Instantiate(Square, new Vector3(j * 0.5F - 9, (height / 2) - 2, 0), Quaternion.identity);
                squareList.Add(newSquareObject);
                squareIndex++;
            }
        }
    }

    public void onButtonPressed()
    {
        StartCoroutine(bubbleSort(0.1f));
    }

    private IEnumerator bubbleSort(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);
        for (int i = 0; i < squareList.Count; i++)
        {
            //Debug.Log("i: " + i + " heigth: " + squareList[i].GetComponent<Renderer>().bounds.extents.y * 2);
            for (int j = 0; j < squareList.Count - (1 + i); j++)
            {
                float height1 = squareList[j].GetComponent<Renderer>().bounds.extents.y * 2;
                float height2 = squareList[j + 1].GetComponent<Renderer>().bounds.extents.y * 2;
                if (height1 > height2)
                {
                    Vector3 tempLocalScale = new Vector3(squareList[j + 1].transform.localScale.x, squareList[j].transform.localScale.y, squareList[j + 1].transform.localScale.z);
                    squareList[j].transform.localScale = new Vector3(squareList[j].transform.localScale.x, squareList[j + 1].transform.localScale.y, squareList[j ].transform.localScale.z);
                    squareList[j + 1].transform.localScale = tempLocalScale;

                    Vector3 tempPosition = new Vector3(squareList[j + 1].transform.position.x, squareList[j].transform.position.y, 0);
                    squareList[j].transform.position = new Vector3(squareList[j].transform.position.x, squareList[j + 1].transform.position.y, 0);
                    squareList[j + 1].transform.position = new Vector3(tempPosition.x, tempPosition.y, 0);

                }
            }
            yield return wait;
        }
    }
}