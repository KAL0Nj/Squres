using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MOVE2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void GetinGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("����ȭ��");
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("Mouse Clicked!");
        GetinGame();
    }
}
