using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour
{
	private Camera mainCamera;
	private void Start()
	{
		mainCamera = Camera.main;
		Application.targetFrameRate = 120;
	}
	public bool GetTouchPosition(out Vector2 position)
	{
		if (!EventSystem.current.IsPointerOverGameObject(0))
		{
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
			{
				position = mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
				return true;
			}
		}
		position = Vector2.zero;
		return false;
	}
}
