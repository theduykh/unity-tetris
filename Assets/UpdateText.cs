using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public static Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = transform.GetComponent<Text>();
        score.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
