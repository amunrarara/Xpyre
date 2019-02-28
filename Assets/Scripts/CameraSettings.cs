using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Xpyre
{
    public class CameraSettings : MonoBehaviour
    {
        public enum InputChoice
        {
            KeyboardAndMouse, Controller,
        }

        [Serializable]
        public struct InvertSettings
        {
            public bool invertX;
            public bool invertY;
        }


        public Transform follow;
        public Transform lookAt;
        public CinemachineFreeLook keyboardAndMouseCamera;
        public CinemachineFreeLook controllerCamera;
        public InputChoice inputChoice;
        public InvertSettings keyboardAndMouseInvertSettings;
        public InvertSettings controllerInvertSettings;
        public bool allowRuntimeCameraSettingsChanges;

        public CinemachineFreeLook Current
        {
            get { return inputChoice == InputChoice.KeyboardAndMouse ? keyboardAndMouseCamera : controllerCamera; }
        }

        void Reset()
        {
            Transform keyboardAndMouseCameraTransform = transform.Find("KeyboardAndMouseFreeLookRig");
            if (keyboardAndMouseCameraTransform != null)
                keyboardAndMouseCamera = keyboardAndMouseCameraTransform.GetComponent<CinemachineFreeLook>();

            Transform controllerCameraTransform = transform.Find("ControllerFreeLookRig");
            if (controllerCameraTransform != null)
                controllerCamera = controllerCameraTransform.GetComponent<CinemachineFreeLook>();

            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null && playerController.name == "Ellen")
            {
                follow = playerController.transform;

                lookAt = follow.Find("HeadTarget");

                if (playerController.cameraSettings == null)
                    playerController.cameraSettings = this;
            }
        }

        void Awake()
        {
            UpdateCameraSettings();
        }

        void Update()
        {
            if (allowRuntimeCameraSettingsChanges)
            {
                UpdateCameraSettings();
            }
        }

        void UpdateCameraSettings()
        {
            keyboardAndMouseCamera.Follow = follow;
            keyboardAndMouseCamera.LookAt = lookAt;

            controllerCamera.Follow = follow;
            controllerCamera.LookAt = lookAt;

            keyboardAndMouseCamera.Priority = inputChoice == InputChoice.KeyboardAndMouse ? 1 : 0;
            controllerCamera.Priority = inputChoice == InputChoice.Controller ? 1 : 0;
        }
    }
}
