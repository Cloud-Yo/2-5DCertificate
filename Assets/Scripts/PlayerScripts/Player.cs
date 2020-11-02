using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _gravity = 1f, _tempGravity = 0f;
    [SerializeField] private float _yVel = 0f, _xVel = 0f;
    [SerializeField] private Vector3 _direction = new Vector3(), _velocity = new Vector3();
    [SerializeField] private Vector3 _ledgeTop = new Vector3();
    [SerializeField] private float _jumpHeight = 15f;
    [SerializeField] private CharacterController _myCC = null;
    [SerializeField] private Animator _myAN = null;
    [SerializeField] private bool _jumping = false;
    [SerializeField] private GameObject _playerModel = null;

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        TurnCharacter();
        _yVel = Mathf.Clamp(_yVel, -9.75f, 15f);
        ClimbLedge();
    }

    private void FixedUpdate()
    {
        if(_myCC.enabled)
        {
            _myCC.Move(_velocity);
        }
        
        if (transform.position.y <= 0f)
        {
            _yVel = 0f;
            ResetPlayer();
        }
        if (_myCC.isGrounded)
        {
            if (_jumping)
            {
                _jumping = false;
                _myAN.SetBool("Jumping", _jumping);
            }
        }
    }

    private void Movement()
    {
        _xVel = Input.GetAxisRaw("Horizontal");
        _myAN.SetFloat("Speed", Mathf.Abs(_xVel));
        _direction = new Vector3(0f, _yVel, _xVel);
        _velocity = _direction * _speed;


        if (_myCC.isGrounded)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            _yVel -= _gravity * Time.deltaTime;
            _velocity.y = _yVel;
        }

    }

    private void TurnCharacter()
    {

        if (_myCC.enabled)
        {

            if (_xVel < 0)
            {
                _playerModel.transform.rotation = Quaternion.Euler(0, 180, 0);

            }
            else if (_xVel > 0)
            {
                _playerModel.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    private void Jump()
    {
        _jumping = true;
        _yVel = 0f;
        _yVel += _jumpHeight;
         _myAN.SetBool("Jumping", _jumping);

        
    }

    private void ClimbLedge()
    {
        if(Input.GetKeyDown(KeyCode.W) && _myAN.GetBool("LedgeGrab"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.35f);
            _myAN.SetTrigger("ClimbLedge");
            _myAN.SetBool("LedgeGrab", false);
            _myAN.rootPosition = _ledgeTop;
 
        }
    }

    private void ResetPlayer()
    {
        transform.position = new Vector3(-0.5f, 72f, 100f);
       
    }

public void GrabLedge(Vector3 pos, Vector3 top)
    {
        transform.position = pos;
        _ledgeTop = top;
        _tempGravity = _gravity;
        _gravity = 0f;
        _myCC.enabled = false;
        _myAN.SetBool("LedgeGrab", true);
    }

    public void StandFromClimb(Vector3 pos)
    {
        transform.position = pos;
        _myAN.rootPosition = pos;
        _myCC.enabled = true;
        _gravity = _tempGravity;
        _myAN.SetTrigger("Standing");
        Debug.Log("called player Standing");

    }

    public bool IsPlayerRunning()
    {
        bool ipr = _xVel != 0 ? true : false;
        return ipr;
    }
}
