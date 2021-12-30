// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

	// Create public variables for player speed, and for the Text UI game objects
	public float speed;

	private float movementX;

	private Rigidbody rb;
	[SerializeField] UnityEvent collectEvent;
	[SerializeField] UnityEvent dieEvent;


	// At the start of the game..
	void Start()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();


	}

	void FixedUpdate()
	{
		speed += (Time.deltaTime*0.1f);
		speed = Mathf.Clamp(speed, 1, 15);
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		float movement = 1+Mathf.Abs(movementX*speed);

		rb.velocity=(new Vector3(movement,rb.velocity.y,0.0f));
	}

	public void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
	}

	public void MoveEventHandler(InputAction.CallbackContext context)
	{
		//Debug.Log(context.ReadValue<Vector2>());
		//use read value to get the action value of the input
		movementX = context.ReadValue<Vector2>().x;
	}

	public void JumpEventHandler(InputAction.CallbackContext context)
	{
		rb.AddForce(new Vector3(0,context.ReadValue<float>()*5),ForceMode.Impulse);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			collectEvent.Invoke();

		}
	}

    private void Update()
    {
        if (transform.position.y < 0)
        {
			transform.position = new Vector3(0, transform.position.y, transform.position.z);
			dieEvent.Invoke();
        }
    }

}