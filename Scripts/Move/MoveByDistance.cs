using UnityEngine;

public class MoveByDistance : BaseMove
{
	[SerializeField] float baseSpeed = 5;
	[SerializeField] float additionalSpeed = 3;

	private Vector2 firstPos;
	private float progress;

	protected override void Start()
	{
		base.Start();
		firstPos = transform.position;
		progress = 0;
	}
	protected override void Update()
	{
		if (pointers.Count > 0)
		{
			Vector2 peekPos = pointers.Peek();
			float distance = (baseSpeed + additionalSpeed * (pointers.Count - 1)) * BallController.Speed * Time.deltaTime;
			progress += distance / Vector2.Distance(firstPos, peekPos);

			if (MoveByCurve) transform.position = CalculateCurvePosition(firstPos, peekPos, curveStrength, progress);
			else transform.position = Vector2.Lerp(firstPos, peekPos, progress);

			if (progress >= 1)
			{
				pointers.Dequeue();
				firstPos = peekPos;
				progress = 0;
			}
		}
	}
	protected override void OnDisable()
	{
		base.OnDisable();
		firstPos = Vector2.zero;
		progress = 0;
	}
}
