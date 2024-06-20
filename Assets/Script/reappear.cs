using UnityEngine;

public class reappear : MonoBehaviour
{
	[SerializeField] float maxDistance = 1;
	Vector3 startingPosition;

	void Awake()
	{
		startingPosition = transform.position;
	}

	void Update()
	{
		float currentDistance = Vector3.Distance(startingPosition, transform.position);
		if (currentDistance > maxDistance)
		{
			transform.position = startingPosition;  
		}
	}
}