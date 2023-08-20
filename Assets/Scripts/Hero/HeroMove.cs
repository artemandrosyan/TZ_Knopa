using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    private const float MIN_VALUE = 0.0001f;
    [SerializeField] private CharacterController _characterController;
	[SerializeField] private float _movementSpeed;
	private InputService _inputService;
	private Camera _camera;
	private float magnitude= 0f;
	
	public void Construct(InputService inputService)
    {
		_inputService = inputService;

	}
	private void Start()
    {
		_camera = Camera.main;
		_camera.GetComponent<CameraFollow>().Follow(gameObject);
	}
	 

	private void Update()
	{
		Vector3 movementVector = Vector3.zero;
		magnitude = _inputService.GetAxis().sqrMagnitude;
		if (magnitude > MIN_VALUE)
		{
			movementVector = _camera.transform.TransformDirection(_inputService.GetAxis());
			movementVector.y = 0;
			movementVector.Normalize();

			transform.forward = movementVector;
		}

		_characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
	}

	public float GetMagnitude()
    {
		return magnitude;
    }
}
	
