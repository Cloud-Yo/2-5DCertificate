using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehavior : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private WaitForSeconds _floorStop = new WaitForSeconds(5f);
    [SerializeField] private Transform[] _floors;
    [SerializeField] private int _nextFloor = 1;
    [SerializeField] private bool _active = false;
    [SerializeField] private bool _directionUp = false;
    [SerializeField] private ElevatorControl _eC = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_active)
        {
            transform.position = Vector3.MoveTowards(transform.position, _floors[_nextFloor].position, _speed * Time.deltaTime);
            if(transform.position == _floors[_nextFloor].position)
            {
                StartCoroutine(WaitAtFloor());
            }
        }
    }

    IEnumerator WaitAtFloor()
    {
        _active = false;
        _eC.ElevatorLight(false);
        
        yield return _floorStop;

        if(!_directionUp)
        {
            if(_nextFloor < _floors.Length -1)
            {
                _nextFloor++;
            }
            else if(_nextFloor == _floors.Length -1)
            {
                _directionUp = true;
                _nextFloor--;
            }
        }
        else
        {
            if(_nextFloor != 0)
            {
                _nextFloor--;
            }
            else
            {
                _directionUp = false;
                _nextFloor++;
            }
        }
        _active = true;
        _eC.ElevatorLight(true);
        yield break;
    }

    public void StartElevator()
    {
        _active = true;
        _eC.ElevatorLight(true);
    }
}
