using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance; // 게임 매니저를 외부에서 접근할 수 있게 싱글톤 
    public GameObject normalCat;
    public GameObject retryBtn;

    // 싱글톤
    private void Awake() { // start보다 빨리 호출되는 awake
        if (Instance == null) {
            Instance = this;
            // Instance가 비어있을 때 자기 자신을 넣어 준다
        }            
        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeCat", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeCat () {
        Instantiate(normalCat);
    }

    public void GameOver() {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }
}
