using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public GameObject Player;

    public GameObject Crystal;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = getDistance(Player, Crystal);
    }

    private float getDistance(GameObject player, GameObject crystal)
    {
        float dist = Vector3.Distance(player.transform.position, crystal.transform.position);
        return dist;
    }
}
