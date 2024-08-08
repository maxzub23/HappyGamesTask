using System.Collections.Generic;
using UnityEngine;

public class BaseMove : MonoBehaviour
{
	[field: SerializeField] public bool MoveByCurve { get; protected set; }
	[SerializeField] protected float curveStrength = 2;
	protected Queue<Vector2> pointers;
	protected virtual void Update()
	{
		if(pointers.TryDequeue(out Vector2 position)) transform.position = position;
	}
	protected virtual void Start() => pointers = new Queue<Vector2>();
	protected virtual void OnDisable()
	{
		transform.position = Vector2.zero;
		pointers.Clear();
	}
	public void SetCurve(bool value) => MoveByCurve = value;
	public virtual void AddPosition(Vector2 position) => pointers.Enqueue(position);
	public static Vector2 CalculateCurvePosition(Vector2 firstPos, Vector2 secondPos, float strength, float section)
	{
		Vector2 curve = firstPos + (secondPos - firstPos) / 2 + Vector2.up * Vector2.Distance(firstPos, secondPos) * strength;
		Vector2 m1 = Vector2.Lerp(firstPos, curve, section);
		Vector2 m2 = Vector2.Lerp(curve, secondPos, section);
		return Vector2.Lerp(m1, m2, section);
	}
}
