using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody rb;
    private int pickUpCount;
    private Timer timer;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Get the number of pick ups in our scene
        pickUpCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        //Run the Check Pickups Function
        CheckPickUps(); 
        //Get the timer object and start the timer
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pick Up")
        {
            Destroy(other.gameObject);
            //Decrement the pick up count
            pickUpCount--;
            //Run the checkpickups function
            CheckPickUps();

        }
        
    }

    void CheckPickUps()
    {
        print("Pick Ups Left" + pickUpCount);
        if(pickUpCount == 0)
        {
            timer.StopTimer();
            print("Completed Level 1! Your time was: " + timer.GetTime());
   
        }
    }
}
