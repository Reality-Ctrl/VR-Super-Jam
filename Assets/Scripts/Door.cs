using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    Animator animator;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip openClip;
    [SerializeField] AudioClip closeClip;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    public void Open()
    {
        animator.SetBool("isOpen", true);
        source.PlayOneShot(openClip, 0.7f);
    }

    public void Close()
    {
        animator.SetBool("isOpen", false);
        source.PlayOneShot(closeClip, 0.7f);
    }

    public bool isDoorOpen()
    {
        return animator.GetBool("isOpen");
    }
}
