using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{

    [SerializeField] private Vector3 _handPos = new Vector3();
    [SerializeField] private Vector3 _standPos = new Vector3();

    public Vector3 HandPos()
    {
        return _handPos;
    }
    public Vector3 StandPos()
    {
        return _standPos;
    }
}
