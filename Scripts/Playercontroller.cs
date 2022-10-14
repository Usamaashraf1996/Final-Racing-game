using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private AudioSource playerAudio;
    public TextMeshProUGUI youWonText;
    public TextMeshProUGUI youLoseText;
    public AudioClip runSound;
    public AudioClip boostSound;
    public AudioClip idleSound;
    public float speed;
    private Rigidbody rb;
    public static Playercontroller instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb =GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameActive)
        {

            CarController();
        }
        
    }
    void CarController()
    {
        
        
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(Vector3.forward * speed, ForceMode.Force);
               // playerAudio.PlayOneShot(runSound, 1.0f);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(Vector3.back * speed, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(Vector3.right * speed, ForceMode.Force);

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(-Vector3.right * speed, ForceMode.Force);

            }
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.back * speed * 2, ForceMode.Force);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(Vector3.forward * speed * 2, ForceMode.Force);
               // playerAudio.PlayOneShot(boostSound, 1.0f);

            }
            else
            {
              //  playerAudio.PlayOneShot(idleSound, 1.0f);
            }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {

            GameManager.instance.GameOver();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish")) {

            youWonText.gameObject.SetActive(true);
            GameManager.instance.restartButton.gameObject.SetActive(true);
        }
        else
         { 
        
        youLoseText.gameObject.SetActive(true);
        }
    }
}
