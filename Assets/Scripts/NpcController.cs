using UnityEngine;

public class NpcController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public State initialState;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        StateUpdate(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sit()
    {
        StateUpdate(State.Sitting);
    }
    public void idle()
    {
        StateUpdate(State.Idle);
    }
    public void walk()
    {
        StateUpdate(State.Walking);
    }
    public void talk()
    {
        StateUpdate(State.Talking);
    }
    public void StateUpdate(State NewState)
    {
        bool willSit = false;
        bool willTalk = false;
        bool willWalk = false;
        

        switch (NewState)
        {
            case State.Idle:

                break;

            case State.Sitting:
                willSit = true;
                break;

            case State.Walking:
                willWalk = true;
                break;

            case State.Talking:
                willTalk = true;
                break;
        }
        animator.SetBool("IsWalking", willWalk);
        animator.SetBool("IsTalking", willTalk);
        animator.SetBool("IsSitting", willSit);
    }

    public enum State
    {
        Idle,
        Sitting,
        Talking,
        Walking
    }
}
