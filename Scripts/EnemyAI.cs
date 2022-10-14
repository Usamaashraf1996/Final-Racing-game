using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody enemyrb;
   [SerializeField]private float speed;
   
    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameActive)
        {

            EnemyAi();
            
        }
        Debug.Log(GameManager.instance.isGameActive);
        
    }
    void EnemyAi()
    {
        

            enemyrb.AddForce(Vector3.forward * speed, ForceMode.Force);
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish")) {

            Playercontroller.instance.youLoseText.gameObject.SetActive(true);
            Playercontroller.instance.youWonText.gameObject.SetActive(false);
        }
    }
}
