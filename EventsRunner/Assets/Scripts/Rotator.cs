using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

	// Before rendering each frame..
	public virtual void Update()
	{
		// Rotate the game object that this script is attached to by 15 in the X axis,
		// 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
		// rather than per frame.
		Rotate();
	}

	public void Rotate()
    {
		transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
		Debug.Log("base rotate");
	}
}