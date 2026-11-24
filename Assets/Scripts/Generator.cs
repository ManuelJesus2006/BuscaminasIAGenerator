using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject piece;
    public int width, height, bombsNumber;
    public GameObject[][] tablero;
    public static Generator gen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Instanciamos el generator para poder usarlo en el piece
        gen = this;
        //Inicializamos al primera dimensión del array
        tablero = new GameObject[width][];
        
        //Inicializamos la segunda dimensión del array
        for (int i = 0; i < tablero.Length; i++)
        {
            tablero[i] = new GameObject[height];
        }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                //Referenciamos cada uno de los gameObjects para crear las bombas
                tablero[i][j] = Instantiate(piece,new Vector2(i,j), Quaternion.identity);
            }
        }

        SetBombs();
        
        //Situamos la cámara respecto a la posición del tablero creado
        Camera.main.transform.position = new Vector3(((float)width/2) -0.5f, ((float)height/2) - 0.5f, -10);
    }

    void SetBombs()
    {
        
        //Creamos las bombas
        for (int i = 0; i < bombsNumber; i++)
        {
            int filaRandom = Random.Range(0,width);
            int columnRandom = Random.Range(0,height);
            bool tieneBomba = tablero[filaRandom][columnRandom].GetComponent<Piece>().bomb;
            //Esto solo para pruebas: tablero[filaRandom][columnRandom].GetComponent<SpriteRenderer>().material.color = Color.red;
            //Asignamos el bool de bomba como true
            if (!tieneBomba)
            {
                tablero[filaRandom][columnRandom].GetComponent<Piece>().bomb = true;
            }else i--;
        }
    }

    public int GetBombsAround(int x, int y )
    {
        int cont = 0;
        if (x > 0 && y < height - 1 && tablero[x-1][y+1].GetComponent<Piece>().bomb) cont++;
        if (y < height - 1 && tablero[x][y+1].GetComponent<Piece>().bomb) cont++;
        if (x < width - 1 && x < height - 1 && tablero[x+1][y+1].GetComponent<Piece>().bomb) cont++;
        if (x > 0 && tablero[x-1][y].GetComponent<Piece>().bomb) cont++;
        if (x < width - 1 && tablero[x+1][y].GetComponent<Piece>().bomb) cont++;
        if (tablero[x-1][y-1].GetComponent<Piece>().bomb) cont++;
        if (tablero[x][y-1].GetComponent<Piece>().bomb) cont++;
        if (tablero[x+1][y-1].GetComponent<Piece>().bomb) cont++;
        return cont;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
