using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareTetris : MonoBehaviour
{
    private static GameObject previousObject;
    public GameObject[] Tetroes;
    public static int Index = 0;
    // Start is called before the first frame update
    void Start()
    {
        NewTetro();
    }

    public void NewTetro()
    {
        Destroy(previousObject); 
        Index = Random.Range(0, Tetroes.Length);
        previousObject = Instantiate(Tetroes[Index], transform.position, Quaternion.identity);

    }
}
