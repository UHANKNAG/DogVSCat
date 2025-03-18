using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 게임 매니저를 외부에서 접근할 수 있게 싱글톤

    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;

    public GameObject retryBtn;

    public RectTransform levelFront;

    public Text levelTxt;

    int level = 0;
    int score = 0;

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

        if(level == 1) {
            // lv.1 20% 확률로 고양이 더 생산
            int p = Random.Range(0, 10);
            if (p < 2)
                Instantiate(normalCat);
        } else if (level == 2) {
            // lv.2 50% 확률로 고양이 더 생산
            int p = Random.Range(0, 10);
            if (p < 5)
                Instantiate(normalCat);
        } else if (level == 3) {
            // lv.3 뚱뚱한 고양이 생산
            Instantiate(fatCat);
        } else if (level == 4) {
            Instantiate(pirateCat);
        }
        
        
    }

    public void GameOver() {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddScore() {
        score++;
        level = score / 5;
        levelTxt.text = level.ToString();
        levelFront.localScale = new Vector3((score - level * 5) / 5.0f, 1f, 1f);
    }
}
