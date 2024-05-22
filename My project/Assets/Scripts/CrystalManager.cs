using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrystalManager : MonoBehaviour
{
    private List<PlayerTrigger> triggerList = new List<PlayerTrigger>();

    [HideInInspector] public UnityEvent crystalMoveEvent = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        foreach (PlayerTrigger pt in GetComponentsInChildren<PlayerTrigger>())
        {
            triggerList.Add(pt);
            pt.playerTrigger.AddListener(InvokeCrystalMover);
        }
    }

    public void InvokeCrystalMover()
    {
        crystalMoveEvent.Invoke();
    }

}
