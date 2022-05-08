using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [Header("Mvt Setup")]
    [Tooltip("unit: m/s")]
    float m_TranslationSpeed;
    [Tooltip("unit: °/s")]
    float m_RotationSpeed;


<<<<<<< Updated upstream
    public Vector3 positionInMaze;

    private int lives;
    private int MaxLives = 3;
    public static Player instance;
    Rigidbody m_Rigidbody;

    public GameObject prefabLives;
    private GameObject Lives;

    float vitesse;
    private void Awake()
    {
        instance = this;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_RotationSpeed = 120;
        m_TranslationSpeed = 20;
        vitesse = 0.2f;
=======
    public Vector2 positionInMaze;

    private int lives;
    Rigidbody m_Rigidbody;
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_RotationSpeed = 120;
        m_TranslationSpeed = 20;
>>>>>>> Stashed changes
    }

    // Start is called before the first frame update
    void Start()
    {
        lives = MaxLives;
        Lives = Instantiate(prefabLives, new Vector3(0, 0, 0), Quaternion.identity);
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {//Dynamique
<<<<<<< Updated upstream

=======

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
>>>>>>> Stashed changes

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

       /* if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.Translate(new Vector3(-vitesse, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.Translate(new Vector3(vitesse, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.transform.Translate(new Vector3(0, 0, vitesse));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.transform.Translate(new Vector3(0, 0, -vitesse));
        }*/


    }
    public void SetPosition(Vector3 vec)
    {
        positionInMaze = vec;
        this.transform.position = positionInMaze;
    }
    public Vector3 GetPosition()
    {
        return positionInMaze;
    }
    public int GetLives()
    {
        return lives;
    }
    public void SetLives(int newLives)
    {
        lives=newLives;
        print("Lives :" + lives);
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
        positionInMaze= new Vector3((int)posPlayer.x + halfGround,0, (int)posPlayer.z + halfGround);
    }
   
}
