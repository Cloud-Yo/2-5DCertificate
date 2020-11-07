using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{
    public enum LedgeType
    {
        notMoving,
        moving
    }

    [SerializeField] private GameObject _standPos  = null;
    [SerializeField] private GameObject _handPosGO = null;
    [SerializeField] private GameObject _UIPrompt = null;
    [SerializeField] private GameObject _parent = null;
    [SerializeField] private Player _player = null;
    [SerializeField] private LedgeType _myLT;


    private void Start()
    {
        HideToolTip();
        _player = FindObjectOfType<Player>();
    }

    public Vector3 HandPos()
    {
        ShowTooltip();
        return _handPosGO.transform.position;
    }

    public bool MovingPlatform()
    {
        bool type = _myLT == LedgeType.moving ? true : false;
        return type;
    }
    public GameObject StandPos()
    {
        return _standPos;
    }

    public void ShowTooltip()
    {
        if (_UIPrompt != null)
        {
            _UIPrompt.SetActive(true);
        }
    }
    public void HideToolTip()
    {
        if(_UIPrompt != null)
        {
            _UIPrompt.SetActive(false);
        }
    }

    public void LedgeGrab()
    {
        _player.GrabLedge(HandPos(), StandPos(), this.gameObject);
        if (MovingPlatform())
        {
            _player.transform.SetParent(_parent.transform);
        }
    }

}
