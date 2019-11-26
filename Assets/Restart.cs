using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Restart : MonoBehaviour
{
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
