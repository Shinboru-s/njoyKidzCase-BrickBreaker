using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    private float maxPosition;
    void Awake()
    {
        Vector3 screenSizeByPixel = new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane);
        Vector3 screenSizeByWorld = Camera.main.ScreenToWorldPoint(screenSizeByPixel);
        maxPosition = screenSizeByWorld.x - (transform.localScale.x / 2);
    }


    void Update()
    {
        //MoveWithMouse();
        MoveWithFinger();
    }

    void MoveWithMouse()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 usablePosition = CheckMaxPosition(mousePosition);
        transform.position = usablePosition;

    }

    void MoveWithFinger()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchWorldPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 usablePosition = CheckMaxPosition(touchWorldPosition);
            transform.position = usablePosition;
        }
    }

    Vector2 CheckMaxPosition(Vector2 inputVector)
    {
        float xPosition = inputVector.x;
        float usableXPosition = Mathf.Clamp(xPosition, -maxPosition, maxPosition);
        return new Vector2(usableXPosition, transform.position.y);
    }
}
