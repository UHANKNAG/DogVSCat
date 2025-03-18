using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public RectTransform front;
    public GameObject hungryCat;
    public GameObject fullCat;
    
    float full = 5.0f;
    float energy = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-9.9f, 9.0f);
        float y = 30.0f;
        transform.position = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < full) {
            transform.position += Vector3.down * 0.05f;
            if (transform.position.y < -16.0f) {
                GameManager.Instance.GameOver();
            }
        }
        else {
            if (transform.position.x > 0) {
                transform.position += Vector3.right * 0.05f;
            }
            else {
                transform.position += Vector3.left * 0.05f;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Food")) {
            if (energy < full) {
                energy += 1.0f;
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f);
                // front 게이지에 반영
                Destroy(collision.gameObject);
                // 충돌한 food는 삭제
                if (energy == 5.0f) {
                    hungryCat.SetActive(false);
                    fullCat.SetActive(true);
                    Destroy(gameObject, 3.0f);
                }
            }
            // SetActive를 바꿔 주는 함수를 if문 밖에 else로 처리했을 때는 게이지가 다 차도 바로 바뀌지 않았음
            // 게이지가 다 차고도 한 번 더 맞았을 때 바뀌는 걸로 처리되기 때문임
            // 그러한 현상 수정을 위해 if문 안에 if문으로 처리하여 문제 해결
        }        
    }
}
