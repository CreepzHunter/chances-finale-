using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camerachangescr : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera overworldCam;
    [SerializeField] CinemachineVirtualCamera closeCam;

    private void OnEnable()
    {
        CameraSwitcher.Register(overworldCam);
        CameraSwitcher.Register(closeCam);
        CameraSwitcher.SwitchCamera(overworldCam);
    }
    private void OnDisable()
    {
        CameraSwitcher.Unregister(overworldCam);
        CameraSwitcher.Unregister(closeCam);
    }

   private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag ("Player"))
        {
            if(CameraSwitcher.IsActiveCamera(overworldCam))
            {
                CameraSwitcher.SwitchCamera(closeCam);
            }
            else if(CameraSwitcher.IsActiveCamera(closeCam))
            {
                CameraSwitcher.SwitchCamera(overworldCam);
            }
        }
    }
}
