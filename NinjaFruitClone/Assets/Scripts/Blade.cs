    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Blade : MonoBehaviour
{
    private Collider bladeCollider;
    private bool slicing;
    private Camera mainCamera;
    private TrailRenderer trailRenderer;
    public Vector3 direction;
    public float sliceForce;
    public float minSliceVelocity = 0.01f;
    private AudioSource audio;
    private float timeCombo = 0.5f;
    private bool isCombo = false;
    private int countCombo = 0;

    private void Awake()
    {
        bladeCollider = GetComponent<Collider>();   
        mainCamera = Camera.main;
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        audio = GetComponent<AudioSource>();    
    }

    private void OnEnable()
    {
        StopSlicing();
    }

    private void OnDisable()
    {
        StopSlicing();
    }
    private void Update()
    {
        timeCombo -= Time.deltaTime;
        if (isCombo)
        {
            timeCombo = 0.5f;
            isCombo = false;
        }   
        else if(!isCombo && timeCombo <= 0)
        {
            timeCombo = 0;
            Debug.Log(countCombo);
            countCombo = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if(slicing)
        {
            ContinueSlicing();
        }
    }
        
    private void StartSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;
        transform.position = newPosition;
        slicing = true;
        bladeCollider.enabled = true;  
        trailRenderer.enabled = true;
        trailRenderer.Clear();
    }

    private void StopSlicing()
    {
        slicing = false;
        bladeCollider.enabled = false;
        trailRenderer.enabled= false;
    }

    private void ContinueSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;
        direction = newPosition - transform.position;
        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;
        transform.position = newPosition;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            isCombo = true;
            countCombo += 1;
        }
    }
}
