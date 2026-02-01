using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    public static HandAnimator instance;

    [SerializeField] Animator _handAnimator;

    void Awake()
    {
        instance = this;
    }

    public void triggerHands(bool state)
    {
        if (state)
        {
            _handAnimator.SetTrigger("talkStart");
        }
        else
        {
            _handAnimator.SetTrigger("talkEnd");
        }

    }
}
