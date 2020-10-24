using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private const string DEATH="Death_b";
    private const string JUMP="Jump_trig";
    private const string SPEED="Speed_multiplier";
    private bool IsDeath=false;
    private Rigidbody playerRb;
    private float jumpForce=10;
    public float gravityMultiplier;
    public bool isOnGround = true;
    private float horizontalMove;
    private bool _gameOver = false;
    public bool gameOver { get => _gameOver; }
    public ParticleSystem explosion;
    public ParticleSystem walkExplosion;
    public AudioClip jumpSound, crashSound;
    private AudioSource _audioSource;
    private float speedMultiplier=1;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = gravityMultiplier * new Vector3(0, -9.81f, 0);
        _animator=GetComponent<Animator>();
        _audioSource=GetComponent<AudioSource>();
        _animator.SetBool(DEATH,IsDeath);
        _animator.SetFloat("Speed_f",1);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        speedMultiplier+=Time.deltaTime/20;
        _animator.SetFloat(SPEED,speedMultiplier);
        playerRb.AddForce(Vector3.right * horizontalMove, ForceMode.Acceleration);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !_gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _animator.SetTrigger(JUMP);
            isOnGround = false;
            walkExplosion.Stop();
            _audioSource.PlayOneShot(jumpSound,1);
            
        }
       
       
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            walkExplosion.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle") )

        {
            explosion.Play();
            walkExplosion.Stop();
            _gameOver = true;
            _animator.SetBool(DEATH,!IsDeath);
            _animator.SetInteger("DeathType_int",Random.Range(1,3));
            _audioSource.PlayOneShot(crashSound,1);
            Invoke("RestartGame",1);

        }

    }

    void RestartGame()
    {
        speedMultiplier=1;
        SceneManager.LoadSceneAsync("Prototype 3", LoadSceneMode.Single);
    }
}
