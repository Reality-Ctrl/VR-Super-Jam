using UnityEngine;
using LetterSystem;
using UnityEngine.Events;
using TMPro;

public class MailBag : MonoBehaviour
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

    private void FixedUpdate()
    {
        if (burning == true)
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
        if (other.tag == "Fire")
        {
            dayManager.letterPass(letter, true, PassType.Wrong);
            mat.color = Color.white;
            transMat.color = Color.white;
            envelope.material = mat;
            top_envel.material = mat;
            fire.SetActive(true);
            burning = true;
        }
    }
}
