using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    public int x,y;
    public bool bomb;

    void OnMouseDown()
    {
       if (bomb)
        {
            GetComponent<SpriteRenderer>().material.color = Color.red;
        }
        else
        {
            //transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "?";
            transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Generator.gen.GetBombsAround(x,y).ToString();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
