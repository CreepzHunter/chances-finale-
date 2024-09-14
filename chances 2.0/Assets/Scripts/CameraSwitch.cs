using System.Collections;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Transform subject;
    public Camera mainCamera;

    // Define different target positions and rotations
    private Vector3 initialPosition = new Vector3(2.32114005f, 6.25f, 0.201140016f);
    private Quaternion initialRotation = Quaternion.Euler(27.4999905f, 348.989838f, 0f);

    private Vector3 frontPosition = new Vector3(1.10000002f, 6.1500001f, 3.3599999f);
    private Quaternion frontRotation = Quaternion.Euler(27.4999619f, 179.438126f, -9.68544373e-06f);

    private Vector3 otherPosition = new Vector3(2.240000009536743f, -0.14000000059604646f, -17.030000686645509f);
    private Quaternion otherRotation = new Quaternion(-0.016535433009266855f, -0.009995606727898121f, 0.005415328312665224f, 0.9997986555099487f);

    private Vector3 enemyPosition = new Vector3(2.71000004f, 6.25f, 1.76999998f);
    private Quaternion enemyRotation = new Quaternion(0.23752692f, -0.03549642f, 0.00868592f, 0.97069335f);

    private Vector3 lustGaemplayPos = new Vector3(0.38f, 4.30f, -22.07f);
    private Quaternion lustGaemplayRot = new Quaternion(0.00f, 0.00f, 0.00f, -1.00f);

    // New PrideLustCameraMiniGame position and rotation
    private Vector3 prideLustPosition = new Vector3(-3.1500000953674318f, 2.049999952316284f, -13.8100004196167f);
    private Quaternion prideLustRotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);

    public float transitionDuration = .3f;

    void Awake()
    {
        // Set initial camera position and rotation when the script starts
        mainCamera.transform.position = initialPosition;
        mainCamera.transform.rotation = initialRotation;
    }

    public void FightScene()
    {
        MoveCamera(initialPosition, initialRotation);
    }

    public void LustGameplay()
    {
        MoveCamera(lustGaemplayPos, lustGaemplayRot);
    }

    public void PlayerView()
    {
        MoveCamera(frontPosition, frontRotation);
    }

    public void SlothGame()
    {
        MoveCamera(otherPosition, otherRotation);
    }

    public void EnemyPosition()
    {
        MoveCamera(enemyPosition, enemyRotation);
    }

    // New method for PrideLustCameraMiniGame
    public void PrideLustCameraMiniGame()
    {
        MoveCamera(prideLustPosition, prideLustRotation);
    }

    void MoveCamera(Vector3 targetPosition, Quaternion targetRotation)
    {
        StartCoroutine(SmoothTransition(targetPosition, targetRotation));
    }

    IEnumerator SmoothTransition(Vector3 targetPosition, Quaternion targetRotation)
    {
        Vector3 startPosition = mainCamera.transform.position;
        Quaternion startRotation = mainCamera.transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            mainCamera.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / transitionDuration);
            mainCamera.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = targetPosition;
        mainCamera.transform.rotation = targetRotation;
    }
}
