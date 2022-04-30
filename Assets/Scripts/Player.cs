using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public class Player : MonoBehaviour
{

    [Header("Mvt Setup")]
    [Tooltip("unit: m/s")]
    float m_TranslationSpeed;
    [Tooltip("unit: °/s")]
    float m_RotationSpeed;


    public Vector2 positionInMaze;

    private int lives;
    Rigidbody m_Rigidbody;
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_RotationSpeed = 120;
        m_TranslationSpeed = 20;
    }

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        print(lives);
       
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {//Dynamique

        float vInput = Input.GetAxis("Vertical"); // entre -1 et 1
        float hInput = Input.GetAxisRaw("Horizontal"); // entre -1 et 1

        // MODE VELOCITY
        Vector3 targetVelocity = vInput * m_TranslationSpeed * Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;
        Vector3 velocityChange = targetVelocity - m_Rigidbody.velocity;
        m_Rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

        Vector3 targetAngularVelocity = hInput * m_RotationSpeed * transform.up;
        Vector3 angularVelocityChange = targetAngularVelocity - m_Rigidbody.angularVelocity;
        m_Rigidbody.AddTorque(angularVelocityChange, ForceMode.VelocityChange);

        Quaternion qRotUpright = Quaternion.FromToRotation(transform.up, Vector3.up);
        Quaternion qOrientSlightlyUpright = Quaternion.Slerp(transform.rotation, qRotUpright * transform.rotation, Time.fixedDeltaTime * 4);
        m_Rigidbody.MoveRotation(qOrientSlightlyUpright);

    }
    public void SetPosition(float x, float y)
    {

    }
    public int GetLives()
    {
        return lives;
    }
    public void SetLives(int newLives)
    {
        lives=newLives;
    }
    public void setPosInMaze(float halfGround)
    {
        Vector3 posPlayer = gameObject.GetComponent<Transform>().position;
        positionInMaze= new Vector2((int)posPlayer.x + halfGround, (int)posPlayer.z + halfGround);
    }
   
}
