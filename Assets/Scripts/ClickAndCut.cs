using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class ClickAndCut : MonoBehaviour
{
    private GameManager gameManager;
    private Camera cam;
    private Vector3 mousePos;

    private TrailRenderer trail;
    private BoxCollider col;
    private bool swiping = false;

    private void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        trail.enabled = false;
        col.enabled = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void UpdateMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }
    void UpdateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }


    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponents();
            }
            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Target") || collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy the target
            collision.gameObject.transform.GetComponent<ObjectRotationScript>().DestroyTarget();
        }
    }




}
