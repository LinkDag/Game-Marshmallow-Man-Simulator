using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum RobotStates { Counting, Inspecting }

public class Robot : MonoBehaviour
{
    [SerializeField] private float startInspectionTime = 2f;
    [SerializeField] private AudioSource jingleSource,shotMp3;

    private float currentInspectionTime;
    private RobotStates currentState = RobotStates.Inspecting;

    public delegate void OnStartCountingDelegate();
    public OnStartCountingDelegate OnStartCounting;

    public delegate void OnStopCountingDelegate();
    public OnStopCountingDelegate OnStopCounting;

    private Animator animator;
    /*private List<CharacterMovement> characters = new List<CharacterMovement>();*/
    private Playing character;
    private Movement move;

    // Start is called before the first frame update
    void Start()
    {
        currentInspectionTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        character = FindObjectOfType<Playing>();
        move = FindObjectOfType<Movement>();
        animator = GetComponentInChildren<Animator>();
        if (character == null)
            return;

        if (character.IsPlaying == true)
        {
            StateMachine();
        }

    }

    private void StateMachine()
    {
        switch (currentState)
        {
            case RobotStates.Counting:
                Count();
                break;
            case RobotStates.Inspecting:
                Inspect();
                break;
            default:
                break;
        }
    }

    private void Count()
    {
        if (!jingleSource.isPlaying)
        {
            animator.SetBool("Look", true);
            currentState = RobotStates.Inspecting;
            OnStopCounting?.Invoke();
        }
    }
    private void Inspect()
    {
        if (currentInspectionTime > 0)
        {
            currentInspectionTime -= Time.deltaTime;
            if (move.IsMoving() && character.IsInvulnerable == false)
            {
                
                character.IsPlaying = false;
                StartCoroutine(Wait());
                currentInspectionTime = 0;
                character.Die();
            }
        }
        else
        {
            currentInspectionTime = startInspectionTime;
            animator.SetBool("Look", false);
            jingleSource.Play();
            currentState = RobotStates.Counting;
            OnStartCounting?.Invoke();
        }
    }
    IEnumerator Wait()
    {
        shotMp3.Play();
        yield return new WaitForSeconds(4f);
        animator.SetBool("Look", false);
    }
}
