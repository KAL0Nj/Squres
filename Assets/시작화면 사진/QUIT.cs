using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Do update-related tasks here if necessary
    }

    // Exit the game
    public void ExitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }

    // Handle mouse click events
    private void OnMouseDown()
    {
        Debug.Log("Mouse Clicked!"); // ����� �޽��� �߰�
        ExitGame(); // Ŭ���ϸ� ExitGame() �޼��� ����
    }
}