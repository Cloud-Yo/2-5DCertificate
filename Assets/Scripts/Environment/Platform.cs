using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private GameObject _targetA = null, _targetB = null;
    [SerializeField] private Transform _targetPos = null;
    [SerializeField] private float _speed = 2f;

    
    // Start is called before the first frame update
    void Start()
    {
        _targetPos = _targetA.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position != _targetPos.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos.position, 1 * _speed * Time.deltaTime);
        }
        else
        {
            _targetPos = transform.position == _targetB.transform.position ? _targetA.transform : _targetB.transform;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Landed on Platform");
            other.transform.SetParent(this.transform);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
