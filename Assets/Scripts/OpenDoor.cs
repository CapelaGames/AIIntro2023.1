using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public float WaitTime  = 3f;
    public float Speed = 5f;
    public Vector3 PositionDelta = Vector3.zero;

    private Vector3 _closedPosition;
    private Vector3 _openPosition;

    
    void Start()
    {
        _closedPosition = transform.position;
        _openPosition = _closedPosition + PositionDelta;

        StartCoroutine(OpenClose());
    }

    IEnumerator OpenClose()
    {
        Vector3 goal = _openPosition;
        bool isOpen = false;
        while(true)
        {
            if(Vector3.Distance(transform.position, goal) < 0.1f)
            {
                // ! is not
                //inverts booleans
                isOpen = !isOpen;
                if(isOpen)
                {//if door is open, close it
                    goal = _closedPosition;
                }
                else
                {//if door is closed, open it
                    goal = _openPosition;
                }
                
                yield return new WaitForSeconds(WaitTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,
                                   goal,
                                    Speed * Time.deltaTime);
                yield return null; //Wait for 1 frame
            }
        }
        
    }
}
