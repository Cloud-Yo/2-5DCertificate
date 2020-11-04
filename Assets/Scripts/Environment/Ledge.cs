using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{

    [SerializeField] private Vector3 _handPos = new Vector3();
    [SerializeField] private Vector3 _standPos = new Vector3();
    [SerializeField] private GameObject _HandPosGO;

    public Vector3 HandPos()
    {
        return _HandPosGO.transform.position;
    }
    public Vector3 StandPos()
    {
        return _standPos;
    }
}
