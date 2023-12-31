using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody fruitRigidbody;
    private Collider fruitCollider;
    private ParticleSystem fruitParticleSystem;
    private AudioSource audio;


    private void Awake()
    {
        fruitRigidbody = GetComponent<Rigidbody>(); 
        fruitCollider = GetComponent<Collider>();   
        fruitParticleSystem = GetComponentInChildren<ParticleSystem>();
        audio = GetComponent<AudioSource>();
    }


    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        FindObjectOfType<GameManager>().IncreaseScore();
        whole.SetActive(false);
        sliced.SetActive(true);
        fruitCollider.enabled = false;
        fruitParticleSystem.Play();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f,0f,angle);
        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody r in slices)
        {
           /* r.velocity = fruitRigidbody.velocity;*/
            r.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.direction, blade.transform.position, blade.sliceForce);
            audio.Play();
        }
    }
}
