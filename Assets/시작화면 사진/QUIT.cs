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
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    // Handle mouse click events
    private void OnMouseDown()
    {
        Debug.Log("Mouse Clicked!"); // 디버그 메시지 추가
        ExitGame(); // 클릭하면 ExitGame() 메서드 실행
    }
}