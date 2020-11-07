using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderInteraction : MonoBehaviour
{
    [SerializeField] private Animator _playerAN = null;
    [SerializeField] private Player _player = null;
    [SerializeField] private bool _onLadder = false;
    
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LadderBottom"))
        {
            _onLadder = true;
            _player.OnLadder(_onLadder, other.transform);
        }
        else if(other.CompareTag("LadderTop"))
        {
            //_onLadder = true;
            _player.TopOfLadder(other.GetComponent<Ladder>().TopOfLadder(), other.GetComponent<Ladder>().TopDownLadder());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LadderTop") || other.CompareTag("LadderBottom"))
        {
            _onLadder = false;
        }
    }
}
