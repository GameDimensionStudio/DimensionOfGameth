using UnityEngine;
using System.Collections;

public class BowHeroWalkArea : MonoBehaviour {
	public bool MouseIsOver = false;
	public bool MouseIsDown = false;

	void OnMouseDown() {
		MouseIsDown = true;
		if (HeroBowGamePlay.SelfClicking != null) {
			HeroBowGamePlay.SelfClicking = "WalkableArea";
		}

	}
}
