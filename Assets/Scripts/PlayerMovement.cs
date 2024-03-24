using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip[] audioClip;
    public AudioSource audioSource;
    [SerializeField] private GameObject _losePanel;
    public float runSpeed = 30f;
    private void Move()
    {
        if (transform.position.z < 250)
        {
            runSpeed = Mathf.MoveTowards(runSpeed, 40, 1f * Time.deltaTime);
        }
        else
        {
            runSpeed = Mathf.MoveTowards(runSpeed, 120, 0.3f * Time.deltaTime);
        }

        transform.Translate(-transform.forward * runSpeed * Time.deltaTime);
    }
    private void Start()
    {
        audioSource.clip = audioClip[0];
        audioSource.loop = true;
        audioSource.Play();
        _losePanel.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        if (runSpeed > 4.99)
        {
            Move();
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                    case TouchPhase.Moved:
                        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                        transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
                        break;
                }
            }
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "obstacle")
        {
            runSpeed = 0;
            _losePanel.SetActive(true);
            audioSource.loop = false;
            audioSource.clip = audioClip[1];
            audioSource.Play();
            runSpeed = 0;
            _losePanel.SetActive(true);
        }
    }
}
