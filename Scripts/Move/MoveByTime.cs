using UnityEngine;
public class MoveByTime : BaseMove
{
	[SerializeField] float timeForMove = 2;
	private Vector2 firstPos;
	private float progress;
	private float timer;
	private float additionSpeed;
	private int pointersPassed;

	protected override void Start()
	{
		base.Start();
		firstPos = transform.position;
		timer = 0;
	}
	protected override void Update()
	{
		if (pointers.Count > 0)
		{
			timer += Time.deltaTime * additionSpeed * BallController.Speed;
			progress = timer / timeForMove;

			Vector2 peekPos = pointers.Peek();
			if (MoveByCurve) transform.position = CalculateCurvePosition(firstPos, peekPos, curveStrength, progress);
			else transform.position = Vector2.Lerp(firstPos, peekPos, progress);

			if (progress >= 1)
			{
				pointers.Dequeue();
				firstPos = peekPos;
				pointersPassed++;
				timer = 0;
			}
		}
	}
	protected override void OnDisable()
	{
		base.OnDisable();
		firstPos = Vector2.zero;
		progress = 0;
	}
	public override void AddPosition(Vector2 position)
	{
		if (pointers.Count == 0) additionSpeed = timer = 0;
		else additionSpeed -= pointersPassed;
		pointersPassed = 0;

		pointers.Enqueue(position);
		additionSpeed++;
	}
}
