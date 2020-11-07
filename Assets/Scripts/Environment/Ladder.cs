using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private GameObject _topOfLadder = null;
    [SerializeField] private GameObject _TopDownPos = null;


    public GameObject TopOfLadder()
    {
        return _topOfLadder;
    }
    public GameObject TopDownLadder()
    {
        return _TopDownPos;
    }
}
