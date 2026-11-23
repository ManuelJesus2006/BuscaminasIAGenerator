using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject piece;
    public int width, height;
    public GameObject[][] map;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        map = new GameObject[width][];
        
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = new GameObject[height];
        }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i][j] = Instantiate(piece,new Vector2(i,j), Quaternion.identity);
            }
        }
        Camera.main.transform.position = new Vector3(((float)width/2) -0.5f, ((float)height/2) - 0.5f, -10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
