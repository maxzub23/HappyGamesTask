using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
	[SerializeField] Color32 colorActive_true = Color.green;
	[SerializeField] Color32 colorActive_false = Color.red;
	public void ChangeButtonActivity(Button button)
	{
		Image image = button?.GetComponent<Image>();
		TextMeshProUGUI text = button?.transform.Find("Text")?.GetComponent<TextMeshProUGUI>();
		if (image && text)
		{
			if (image.color == colorActive_true)
			{
				image.color = colorActive_false;
				text.text = "OFF";
			}
			else
			{
				image.color = colorActive_true;
				text.text = "ON";
			}
		}
	}
	public void HideMenu() => transform.parent.gameObject.SetActive(false);
	public void ShowMenu() => transform.parent.gameObject.SetActive(true);
}
