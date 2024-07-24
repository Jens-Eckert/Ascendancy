using UnityEngine;

public class PlayerController : MonoBehaviour {
    private InputSystem_Actions m_actions;
    private CharacterController m_characterController;
    private Vector3 m_velocity = Vector3.zero;
    [SerializeField] private float accelerationTime;
    [SerializeField] private float decelerationTime;
    [SerializeField] private float speed;
    [SerializeField] private float maxLookAngle;
    private Transform m_lookAt;
    private Vector2 m_rv;
    private float m_lookAngle = 0.0f;
    
    private void Start() {
        m_actions ??= new InputSystem_Actions();

        m_actions.Player.Look.performed += _ => OnLook();
        
        m_actions.UI.Disable();
        m_actions.Player.Enable();
        
        m_characterController = gameObject.GetComponent<CharacterController>();

        m_lookAt = transform.Find("LookAt");
    }

    private void Awake() {
        
    }
    
    private void Update() {
        OnMove(m_actions.Player.Move.ReadValue<Vector2>());

        var move = transform.right * m_velocity.x + transform.forward * m_velocity.z;

        m_characterController.Move(move * (Time.deltaTime * speed));
    }

    private void OnMove(Vector2 input) {
        if (input != Vector2.zero) {
            m_velocity.x = Mathf.SmoothDamp(m_velocity.x, input.x, ref m_rv.x, accelerationTime);
            m_velocity.z = Mathf.SmoothDamp(m_velocity.z, input.y, ref m_rv.y, accelerationTime);
        } else {
            m_velocity.x = Mathf.SmoothDamp(m_velocity.x, input.x, ref m_rv.x, decelerationTime);
            m_velocity.z = Mathf.SmoothDamp(m_velocity.z, input.y, ref m_rv.y, decelerationTime);
        }
    }

    private void OnLook() {
        var input = m_actions.Player.Look.ReadValue<Vector2>();
        
        transform.Rotate(Vector3.up, input.x);
        m_lookAngle += input.y;
        m_lookAngle = Mathf.Clamp(m_lookAngle, -maxLookAngle, maxLookAngle);
        
        // Debug.Log(m_lookAngle);

        if (m_lookAngle <= -maxLookAngle || m_lookAngle >= maxLookAngle)
            return;
        
        m_lookAt.RotateAround(transform.position, transform.right, -input.y);
    }

    private Vector3 ClampV3(Vector3 v, float min, float max) {
        v.x = Mathf.Clamp(v.x, min, max);
        v.y = Mathf.Clamp(v.y, min, max);
        v.z = Mathf.Clamp(v.z, min, max);

        return v;
    }
}
