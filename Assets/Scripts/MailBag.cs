using System;
using UnityEngine;
using LetterSystem;
using UnityEngine.Events;
using TMPro;
using Valve.VR.InteractionSystem;

public class MailBag : MonoBehaviour, IDetachable
{
    [SerializeField] private SetupLetter setupLetter;
    [SerializeField] private Renderer envelope;
    [SerializeField] private Renderer top_envel;
    [SerializeField] private TMP_Text[] info;
    [SerializeField] private Material mat;
    [SerializeField] private Material transMat;
    [SerializeField] private GameObject fire;
    [SerializeField] private float speed = 1f;
    [SerializeField] private bool burning = false;
    [SerializeField] private Throwable throwable;
    [SerializeField] private Interactable interactable;
    [SerializeField] private GameObject thisGameObject;

    [SerializeField] Animator animator;
    [SerializeField] RuntimeAnimatorController[] PipeAnimator;

    [HideInInspector] public DayManager dayManager;


    private Letter _letter;
    public Letter letter
    {
        set
        {
            _letter = value;
            setupLetter.Setup(value.from, value.recipient, value.title, value.text);
        }

        get
        {
            return _letter;
        }
    }

    private void Awake()
    {
        thisGameObject = this.gameObject;
        throwable = this.GetComponent<Throwable>();
        interactable = this.GetComponent<Interactable>();
    }

    private void FixedUpdate()
    {
        if (burning is true)
        {
            if (mat.color.r > 0f)
            {
                mat.color = new Color(mat.color.r - speed * Time.deltaTime, mat.color.g - speed * Time.deltaTime, mat.color.b - speed * Time.deltaTime);
            }
            else
            {
                if (transMat.color.a > 0)
                {
                    envelope.material = transMat;
                    top_envel.material = transMat;
                    transMat.color = new Color(0, 0, 0, transMat.color.a - speed * Time.deltaTime);
                    for (int i = 0; i < info.Length; i++)
                    {
                        info[i].color = new Color(0, 0, 0, info[i].color.a - speed * 2 * Time.deltaTime);
                    }
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag is "Fire")
        {
            Detach();
            dayManager.letterPass(letter, true, PassType.Wrong);
            mat.color = Color.white;
            transMat.color = Color.white;
            envelope.material = mat;
            top_envel.material = mat;
            fire.SetActive(true);
            burning = true;
        }
    }

    public void Detach()
    {
        if (interactable.attachedToHand != null)
        {
            interactable.attachedToHand.DetachObject(thisGameObject);
            Destroy(throwable);
            interactable.enabled = false;
        }
    }

    public void PipeAnimation()
    {
        animator.runtimeAnimatorController = PipeAnimator[UnityEngine.Random.Range(0, PipeAnimator.Length - 1)];
    }
}