using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Elevator Action", menuName ="ScriptableActions/ElevatorSO")]
public class ElevatorSciptableAction : ScriptableAction
{
    [SerializeField] private GameObject _platform = null;
    [SerializeField] private GameObject[] _floors = new GameObject[0];
    [SerializeField] private int _floorIndex = 0;
    [SerializeField] private ElevatorControl _myEC = null;
    
    public override void Action()
    {
        throw new System.NotImplementedException();
    }

    public Transform ReturnFloor()
    {
        return _floors[_floorIndex].transform;
    }

}
