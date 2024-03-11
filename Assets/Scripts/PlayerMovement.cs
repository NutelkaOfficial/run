using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 500f;

    void Awake()
    {

    }
    void Update()
    {
        
    }

    private void Move()
    {
        transform.Translate(-transform.forward * runSpeed * Time.fixedDeltaTime);
    }


    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                case TouchPhase.Moved:
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f)); // ����������� �������� ���������� � �������
                    transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z); // ���������� ������ ������ �� ���� X � Y
                    break;
            }
        }
        Move();

    }
}
