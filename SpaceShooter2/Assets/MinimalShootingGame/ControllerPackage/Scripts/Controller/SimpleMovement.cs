using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

namespace MinimalShooting.ControllerPackage
{
    public class SimpleMovement : MonoBehaviour
    {
        // Player movement speed by joystick.
        [SerializeField]
        float joystickMovementSpeed;

        // Player movement speed by keyboard.
        [SerializeField]
        float keyboardMovementSpeed;

        [SerializeField]
        private GameObject thrusterEffectPrefab;

        // Reference to the instantiated thruster effect
        private GameObject thrusterEffect;
        
        [SerializeField]
        private float thrusterOffset = 1f; // Adjust this value to set the desired offset along the -Z axis

        // Private variables.
        Vector3 firstTouchDistance;

        [SerializeField] float thrusterLingerDuration = 1.0f;

        private float thrusterLingerTimer = 0.0f;
        private bool isThrusterActive = false;

        public float KeyboardMovementSpeed
        {
            get { return keyboardMovementSpeed; }
            set { keyboardMovementSpeed = value; }
        }

        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontal, 0f, vertical);
            transform.position += movement * keyboardMovementSpeed * Time.deltaTime;
            Movement();

            UpdateThrusterEffect();
        }

        void UpdateThrusterEffect()
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (movement != Vector3.zero)
            {
                if (!isThrusterActive)
                {
                    Vector3 effectPosition = transform.position - new Vector3(0f, 0f, thrusterOffset);
                    thrusterEffect = Instantiate(thrusterEffectPrefab, effectPosition, Quaternion.LookRotation(-movement));
                    thrusterEffect.transform.SetParent(transform);
                    isThrusterActive = true;
                }
                else
                {
                    thrusterEffect.transform.rotation = Quaternion.LookRotation(-movement);
                }

                // Reset the thruster linger timer
                thrusterLingerTimer = thrusterLingerDuration;
            }
            else
            {
                // Check if the thruster effect should be destroyed
                if (isThrusterActive)
                {
                    thrusterLingerTimer -= Time.deltaTime;
                    if (thrusterLingerTimer <= 0f)
                    {
                        Destroy(thrusterEffect);
                        thrusterEffect = null;
                        isThrusterActive = false;
                    }
                }
            }
        }


        void JoystickMovement()
        {
            Vector3 velocity = GameControllerSetting.Instance.joystick.InputVector * this.joystickMovementSpeed;
            transform.position = transform.position + Time.deltaTime * velocity;

            if (GameControllerSetting.Instance.lookAtByDirection)
            {
                if (velocity.magnitude > 0)
                {
                    Quaternion to = Quaternion.LookRotation(velocity.normalized);
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, to, Time.deltaTime * GameControllerSetting.Instance.turnSpeed);
                }
            }
        }


        void HorizontalJoystickMovement()
        {
            Vector3 targetPosition = GameControllerSetting.Instance.horizonJoystick.InputVector;
            Vector3 myPosition = transform.position;

            targetPosition.y = myPosition.y;
            targetPosition.z = myPosition.z;

            if (GameControllerSetting.Instance.allowTeleport)
            {
                myPosition.x = targetPosition.x;
                transform.position = myPosition;
            }
            else
            {
                Vector3 velocity = Vector3.zero;

                if ((targetPosition - myPosition).magnitude < 0.1f)
                {
                    velocity = Vector3.zero;
                }
                else
                {
                    velocity = (targetPosition - myPosition).normalized * this.joystickMovementSpeed;
                }

                if (GameControllerSetting.Instance.horizonJoystick.isStop)
                {
                    velocity = Vector3.zero;
                }

                transform.position = transform.position + Time.deltaTime * velocity;
            }
        }


        void TouchAndDragMovement()
        {
            if (GameControllerSetting.Instance.touchDragController.touchState == TouchDragController.TouchState.PointerDown)
            {
                Vector3 touchPosition = GameControllerSetting.Instance.touchDragController.touchPosition;
                Vector3 myPosition = transform.position;
                myPosition.y = 0;

                this.firstTouchDistance = (myPosition - touchPosition);
            }
            else if (GameControllerSetting.Instance.touchDragController.touchState == TouchDragController.TouchState.PointerDrag)
            {
                Vector3 input = GameControllerSetting.Instance.touchDragController.InputVector;
                Vector3 myPosition = transform.position;
                Vector3 newPosition = input + this.firstTouchDistance;

                if (GameControllerSetting.Instance.onlyXMovement)
                {
                    newPosition.z = myPosition.z;
                }
                transform.position = newPosition;
            }
        }


        void KeyboardMovement()
        {
            // Make the speed same for each direction straight and diagonal.
            Vector3 input = Vector3.ClampMagnitude(GameControllerSetting.Instance.keyboardController.InputVector, 1.0f);
            Vector3 velocity = input * this.keyboardMovementSpeed;
            transform.position += Time.deltaTime * velocity;
        }


        void Movement()
        {
            switch (GameControllerSetting.Instance.controllerType)
            {
                case ControllerType.Keyboard:
                    KeyboardMovement();
                    break;

                case ControllerType.VirtualJoystick:
                    JoystickMovement();
                    break;

                case ControllerType.VirtualJoystickHorizontal:
                    HorizontalJoystickMovement();
                    break;

                case ControllerType.TouchAndDrag:
                    TouchAndDragMovement();
                    break;
            }

            ClampBoundary();
        }


        void ClampBoundary()
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, -5.0f, 5.0f);
            pos.z = Mathf.Clamp(pos.z, -9.5f, 9.5f);
            transform.position = pos;
        }
    }
}
