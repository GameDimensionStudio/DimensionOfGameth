using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;

public class MouseEvent : MonoBehaviour ,IPointerClickHandler {
	public UnityEvent MEvent;

	public void OnPointerClick(PointerEventData eventData) {
		if (eventData.button.ToString () == "Left") {
			MEvent.Invoke ();
			Debug.Log ("Pointer Click" + eventData.button);
		}
	}
}