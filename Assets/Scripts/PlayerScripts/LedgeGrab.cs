using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    [SerializeField] private Player _player = null;

    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ledge") && _player.IsPlayerRunning())
        {
            
            _player.GrabLedge(other.GetComponent<Ledge>().HandPos(), other.GetComponent<Ledge>().StandPos());

        }
    }
}
