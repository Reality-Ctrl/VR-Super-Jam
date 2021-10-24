using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    public void Open()
    {
        animator.SetBool("isOpen", true);
    }

    public void Close()
    {
        animator.SetBool("isOpen", false);
    }

    public bool isDoorOpen()
    {
        return animator.GetBool("isOpen");
    }
}
