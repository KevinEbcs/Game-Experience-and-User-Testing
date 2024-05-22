using System;
using UnityEngine;
using UnityEngine.Events;

public class SegmentTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public UnityEvent trigger = new UnityEvent();
    private SevenSegment segment;
    public int number;

    private void Start()
    {
        segment = FindAnyObjectByType<SevenSegment>();
    }

    public void OnTriggerEnter(Collider other)
    {
        //trigger.Invoke();
        //GetComponent<Collider>().enabled = false;
        if (other.CompareTag("Player"))
        {
            segment.Generate();
            number = segment.number;
            Debug.Log("Triggered");
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            segment.Reset();
            Debug.Log("Not Triggered");
        }
    }
}
