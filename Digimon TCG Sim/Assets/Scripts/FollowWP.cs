using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

public class FollowWP : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] waypoints;
    [SerializeField]
    private int currentWP = 10;
    
    public float speed = 2f;// change this to a fast speed maybe 
    public Button MoveUP;
    public Button MoveDOWN;


    void Start()
    {
        this.transform.position = waypoints[10].transform.position; // put marble to the position of waypoint 10 which is zero  

        MoveUP.onClick.AddListener(Increment);
        MoveDOWN.onClick.AddListener(Decrement);
        
    }

    void Update()
    {
        Move();

        
    }

    void Move()
    {
        this.transform.position = Vector2.MoveTowards(transform.position,
                                                waypoints[currentWP].transform.position,
                                                speed * Time.deltaTime); // Movement

    }
     void Increment() // add int num for the card play number
    {
         currentWP++; 
        if(currentWP > 20)
        {
            currentWP = 10;
        }
       
    }
    void Decrement() // decrement maybe for player 2 Element 20 is 10  
    {
        currentWP--;
        if(currentWP < 0)
        {
            currentWP = 10;
        }

    }
    
}
