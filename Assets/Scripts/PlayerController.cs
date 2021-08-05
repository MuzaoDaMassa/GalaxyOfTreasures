using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float _speed;
    public float _turnSmoothTime = 0.1f;
    public bool _inPlanetOrbit = false;
    public bool _mobile = false;

    public GameObject player;
    public FixedJoystick joystick;
    public FixedTouchField touchField;
    public Transform cam;

    private float _turnSmoothVelocity;
    private float _horizontal, _vertical;

    private Vector3 _direction;
    private CharacterController controller;

    protected float _cameraAngle;
    protected float _cameraAngleSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_mobile)
        {
            _horizontal = joystick.Horizontal;
            _vertical = joystick.Vertical;
            _direction = new Vector3(_horizontal, 0.0f, _vertical).normalized;
        }
        else
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _direction = new Vector3(_horizontal, 0.0f, _vertical).normalized;
        }
        if (_direction.magnitude >=0.1f && !_inPlanetOrbit)
        {
            CalculateMovement(_direction);
        }

        _cameraAngle += touchField.TouchDist.x * _cameraAngleSpeed;

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(_cameraAngle, Vector3.up) * new Vector3(0f, 0.75f, -1.1f);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position, Vector3.up);


    }

    private void CalculateMovement(Vector3 _direction)
    {
        float _targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
        transform.rotation = Quaternion.Euler(0.0f, _angle, 0.0f);
        Vector3 _moveDir = Quaternion.Euler(0.0f, _targetAngle, 0.0f) * Vector3.forward;
        controller.Move(_moveDir.normalized * _speed * Time.deltaTime);
    }
}
