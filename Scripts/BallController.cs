using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] Slider speedSlider;
    private TouchController touchController;
    public static float Speed { get; private set; } = 1;
    void Start()
    {
        touchController = GameObject.Find("GameController").GetComponent<TouchController>();
    }
    void Update()
    {
        Transform ball;
        if (touchController.GetTouchPosition(out Vector2 position))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                ball = transform.GetChild(i);
                if (ball.gameObject.activeSelf) ball.GetComponent<BaseMove>()?.AddPosition(position);
            }
        }
    }
    public void ChangeSpeed() => Speed = Mathf.Lerp(0.5f, 2f, speedSlider.value);
    public void ChangeCurveBehaviour()
    {
        BaseMove move;
        for (int i = 0; i < transform.childCount; i++)
        {
            move = transform.GetChild(i).GetComponent<BaseMove>();
            if (move) move.SetCurve(!move.MoveByCurve);
        }
    }
    public void ChangeActivityBall(GameObject ball) => ball?.SetActive(!ball.activeSelf);
}
