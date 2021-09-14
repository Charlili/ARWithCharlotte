using UnityEngine;
using UnityEngine.AI;

public class NavAgentController : MonoBehaviour
{
    public float JumpHeight = 2f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public string GroundTag = "Ground";

    private NavMeshAgent _agent;
    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private float _speed = 5f;
    private bool _isGrounded = true;
    private bool _isInTheAir = false;


    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _speed = _agent.speed;
    }

    void Update()
    {

        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        if (_inputs != Vector3.zero)
            transform.forward = _inputs;

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _isGrounded = false;
            _agent.enabled = false;
            _body.isKinematic = false;
            _body.AddRelativeForce(Vector3.up * Mathf.Sqrt(JumpHeight), ForceMode.VelocityChange);

        }
        /*if (Input.GetButtonDown("Dash"))
        {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime)));
            _body.AddForce(dashVelocity, ForceMode.VelocityChange);
        }*/
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!_isGrounded)
        {
            _isInTheAir = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == GroundTag && !_isGrounded && _isInTheAir)
        {
            _isGrounded = true;
            _agent.enabled = true;
            _body.isKinematic = true;
            _isInTheAir = false;
        }
    }


    void FixedUpdate()
    {
        if (_agent.isActiveAndEnabled)
        {
            _agent.Move(_inputs * _speed * Time.fixedDeltaTime);
        }
        else
        {
            _body.MovePosition(_body.position + _inputs * _speed * Time.fixedDeltaTime);
        }
    }
}
