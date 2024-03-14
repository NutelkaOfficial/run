using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    public float runSpeed = 30f;
    private void Move()
    {
        transform.Translate(-transform.forward * runSpeed * Time.fixedDeltaTime);
    }
    private void Start()
    {
        _losePanel.SetActive(false);
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
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f)); // Преобразуем экранные координаты в мировые
                    transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z); // Перемещаем объект только по осям X и Y
                    break;
            }
        }
        Move();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "obstacle")
        {
            _losePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
