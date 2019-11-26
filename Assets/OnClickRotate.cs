using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OnClickRotate : MonoBehaviour
{
    public static bool  pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = transform.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick()
    {
        pressed = true;
        //FindObjectOfType<TetrisBlock>().Rotate();
    }
}
