using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private SteamVR_Action_Vector2 joystickInput;
    [SerializeField] private Transform camera;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(joystickInput.axis.x, 0, joystickInput.axis.y));
        characterController.Move(Vector3.ProjectOnPlane(direction, Vector3.up) * speed);

        float distToFloor = Vector3.Dot(camera.localPosition, Vector3.up);
        characterController.center = camera.localPosition - 0.5f * distToFloor * Vector3.up;
    }
}
