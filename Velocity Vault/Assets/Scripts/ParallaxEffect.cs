using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private Transform _followTarget;

    private Vector2 _startingPositon;
    private float _startingZ;

    Vector2 camMoveSinceStart => (Vector2)_camera.transform.position - _startingPositon;

    float distanceFromTarget => transform.position.z - _followTarget.transform.position.z;

    float clippingPlane => (_camera.transform.position.z + (distanceFromTarget > 0 ? _camera.farClipPlane : _camera.nearClipPlane));
    float ParallaxFactor => Mathf.Abs(distanceFromTarget) / clippingPlane;
    void Start()
    {
        _startingPositon = transform.position;
        _startingZ= transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPositon = _startingPositon + camMoveSinceStart * ParallaxFactor;

        transform.position = new Vector3(newPositon.x, newPositon.y, _startingZ);
    }
}
