using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeFood", 0f, 0.2f);
    }

    void Update() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = mousePos.x;
        if (x > 8.5f) {
            x = 8.5f;
        }
        if (x < -8.5f) {
            x = -8.5f;
        }

        transform.position = new Vector2(x, transform.position.y);
    }

    void MakeFood() {
        float x = transform.position.x;
        float y = transform.position.y + 2.0f;
        Instantiate(food, new Vector2(x, y), Quaternion.identity);
        // Quaternion.Identity 별도의 회전값을 주지 않겠다. 생성한 그대로 사용하겠다는 뜻
        // identity는 소문자였다... 대문자로 썼다가 한참 찾았네
    }
}
