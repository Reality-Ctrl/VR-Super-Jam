using System.Diagnostics.Contracts;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerMovementTest : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] [Range(0f, 1f)] private float procentOfHeight;
    [SerializeField] private SteamVR_Action_Vector2 joystickInput;
    [SerializeField] private Transform camera;
    [SerializeField] private CapsuleCollider capsuleCollider;
    private float maxPlayerHeight;

    //private CharacterController characterController;
    private Vector3 startPos;
    private Quaternion startRot;

    private void Awake()
    {
        startPos = this.transform.position;
        startRot = this.transform.rotation;
        maxPlayerHeight = Player.instance.eyeHeight;
    }

    private void FixedUpdate()
    {
        if (maxPlayerHeight < Player.instance.eyeHeight)
        {
            maxPlayerHeight = Player.instance.eyeHeight;
        }

        if (maxPlayerHeight * procentOfHeight <= Player.instance.eyeHeight)
        {
            capsuleCollider.enabled = true;
            Vector3 moveDirection = Player.instance.hmdTransform.TransformDirection(new Vector3(-joystickInput.axis.y, 0, joystickInput.axis.x));
            capsuleCollider.height = Player.instance.eyeHeight;

            float distToFloor = Vector3.Dot(camera.localPosition, Vector3.up);
            capsuleCollider.center = (camera.localPosition - 0.5f * (distToFloor - 0.5f) * Vector3.up) - Player.instance.hmdTransform.right * -0.19f;
            transform.Translate(Vector3.ProjectOnPlane(moveDirection, Vector3.up) * speed);
        }
        else
        {
            capsuleCollider.enabled = false;
        }
    }

    public void Spawn()
    {
        this.transform.position = startPos;
        this.transform.rotation = startRot;
    }
}
