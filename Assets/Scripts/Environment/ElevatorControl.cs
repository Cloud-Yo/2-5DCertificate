using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ElevatorControl : MonoBehaviour
{
    [SerializeField] private Light _ElevatorLight = null;
    [SerializeField] private Color _onCol = Color.white, _offCol = Color.white;
    [SerializeField] private MeshRenderer _lightMat = null;
    [SerializeField] private ElevatorBehavior _eB = null;
    [SerializeField] private GameObject _promptText = null;
    [SerializeField] private Animator _txtAN = null;
    [SerializeField] private BoxCollider _myBC = null;

    private bool _playerAccess = false;


    private void Start()
    {
        _ElevatorLight.color = _offCol;
        _lightMat.material.SetColor("_EmissionColor", _offCol);
        _promptText.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _playerAccess)
        {
            Debug.Log("Elevator Moving");
            _ElevatorLight.color = _onCol;
            _lightMat.material.SetColor("_EmissionColor", _onCol);
            _promptText.SetActive(false);
            _eB.StartElevator();
            _myBC.enabled = false;
            _playerAccess = false;
            
            //set bool to true
            //start movement coroutine
            //disable button.
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _promptText.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //_ElevatorLight.color = _offCol;
            //_lightMat.material.SetColor("_EmissionColor", _offCol);
            _promptText.SetActive(false);
            _playerAccess = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _playerAccess = true;
        }
    }

    public void ElevatorLight(bool on)
    {
        if(on)
        {
            _lightMat.material.SetColor("_EmissionColor", _onCol);
            _ElevatorLight.color = _onCol;
        }
        else
        {
            _lightMat.material.SetColor("_EmissionColor", _offCol);
            _ElevatorLight.color = _offCol;
        }
    }



}
