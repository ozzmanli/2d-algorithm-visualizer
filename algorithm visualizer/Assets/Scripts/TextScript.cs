using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    Text val;
    public Transform spawnPos;
    public GameObject Square;
    private Vector3 scaleChange;
    float thickness;
    float height;
    int n = 0;
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
        height = Random.Range(0, 5.0F);
        scaleChange = new Vector3(thickness, height, 1f);
        Square.transform.localScale = scaleChange;
        Instantiate(Square, new Vector3(n * 0.5F - 9, height/2 - 2, 0), Quaternion.identity);
    }


    public void swapSquare()
    {



    }
}