using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TetrisBlock : MonoBehaviour
{
    public Vector3 rotatePoint;
    private float previousTime;
    private float previousTimeL;
    private float previousTimeR;
    public float fallTime = 10f;

    public static int height = 20;
    public static int width = 10;

    private static Transform[,] grid = new Transform[width, height + 3];

    // Start is called before the first frame update
    void Awake()
    {
        if (!ValidMove())
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || OnClickLeft.pressing)
        {
            if (Time.time - previousTimeL > fallTime / 10)
            {
                MoveLeft();
                previousTimeL = Time.time;
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow) || OnClickRight.pressing)
        {
            if (Time.time - previousTimeR > fallTime / 10)
            {
                MoveRight();
                previousTimeR = Time.time;
            }

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || OnClickRotate.pressed)
        {
            Rotate();
            OnClickRotate.pressed = false;
        }

        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) || OnClickDown.pressing ? fallTime / 30 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                this.enabled = false;
                AudioController.acInstance.PlayDownSound();
                CheckForLines();
                FindObjectOfType<SpawnElement>().NewTetro(PrepareTetris.Index);
                FindObjectOfType<PrepareTetris>().NewTetro();
                //SpawnElement.Blocks[SpawnElement.Size] = gameObject;
                //SpawnElement.Size++;
                //Debug.Log(transform.childCount);
            }
            previousTime = Time.time;
        }
    }

    public void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0);
        if (!ValidMove())
        {
            transform.position -= new Vector3(-1, 0, 0);
        }
    }

    public void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0);
        if (!ValidMove())
        {
            transform.position -= new Vector3(1, 0, 0);
        }
    }

    public void MoveDown()
    {
        transform.position += new Vector3(0, -1, 0);
        if (!ValidMove())
        {
            transform.position -= new Vector3(0, -1, 0);
            AddToGrid();
            this.enabled = false;
            CheckForLines();
            FindObjectOfType<SpawnElement>().NewTetro();
        }
        previousTime = Time.time;
    }

    public void Rotate()
    {
        AudioController.acInstance.PlayRotateSound();
        transform.RotateAround(transform.TransformPoint(rotatePoint), new Vector3(0, 0, 1), 90);
        if (!ValidMove())
        {
            transform.RotateAround(transform.TransformPoint(rotatePoint), new Vector3(0, 0, 1), -90);
        }
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
        }
    }

    void CheckForLines()
    {
        int index = 0;
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                index++;
                DeleteLine(i);
                //AudioController.acInstance.PlayEarnSound();
                RowDown(i);
            }
        }
        int scor = 0;
        if (index == 1)
            scor = 10;
        if (index == 2)
            scor = 20;
        if (index == 3)
            scor = 40;
        if (index == 4)
            scor = 60;
        AddScore(scor*100);
    }

    bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null)
                return false;
        }

        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
            AudioController.acInstance.PlayEarnSound();
        }
    }

    void AddScore(int score)
    {
        int current = int.Parse(UpdateText.score.text);
        current += score;
        UpdateText.score.text = current.ToString();
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            grid[roundedX, roundedY] = children;
        }
    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY > height+3)
            {
                return false;
            }
            if (grid[roundedX, roundedY] != null)
                return false;
        }
        return true;
    }
}
