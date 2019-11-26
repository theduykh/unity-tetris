using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElement : MonoBehaviour
{
    public static int Size = 0;
    public GameObject[] Tetroes;
    // Start is called before the first frame update
    void Start()
    {
        NewTetro();
    }

    public void NewTetro()
    {
        Instantiate(Tetroes[Random.Range(0, Tetroes.Length)], transform.position, Quaternion.identity);

    }
    public void NewTetro(int index)
    {
        Instantiate(Tetroes[index], transform.position, Quaternion.identity);
    }
}
