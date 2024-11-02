using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
     
     [SerializeField] PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
         player=GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Player" && this.tag=="Clock")
        {
            Destroy(this.gameObject);
            Timer.Instance.AddPowerUpTime();
        }
    }
}