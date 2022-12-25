using UnityEngine;

public class CueController : MonoBehaviour
{
    [SerializeField] private GameObject CueBall;

    private bool _isCueMovable = false;
    private Vector3 _previousMousePosition;
    private float _distanceFromCueToCueBall = 5;
    
    void Start()
    {
        // gameObject.SetActive(true);
        ResetCue();
        _previousMousePosition = Input.mousePosition;
    }

    void Update()
    {
        ProcessInput();

        if (_isCueMovable)
        {
            UpdateCuePosition(Input.mousePosition);
        }
    }

    private void ProcessInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCueMovable = true;
            _previousMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isCueMovable = false;
        }
    }

    private void UpdateCuePosition(Vector3 currentPosition)
    {
        if (_previousMousePosition.Equals(currentPosition))
        {
            return;
        }

        Vector3 translateTo = (_previousMousePosition - currentPosition) * 0.001f;
        float magnitude = translateTo.magnitude;
        if (translateTo.x < 0) magnitude *= -1;
        Vector3 cueBallPosition = CueBall.transform.position;
        Transform gameObjectTransform = gameObject.transform;

        gameObjectTransform.position = new Vector3(cueBallPosition.x, cueBallPosition.y, cueBallPosition.z - 1);
        float tiltAroundZ = gameObject.transform.eulerAngles.z + magnitude;
        gameObject.transform.eulerAngles = new Vector3(-87f, 0, tiltAroundZ);
    }

    private void ResetCue()
    {
        Transform gameObjectTransform = gameObject.transform;
        Vector3 cueBallPosition = CueBall.transform.position;
        Vector3 currentPosition = gameObjectTransform.position;
        gameObjectTransform.position = new Vector3(cueBallPosition.x, currentPosition.y, cueBallPosition.z - _distanceFromCueToCueBall);
    }
}
