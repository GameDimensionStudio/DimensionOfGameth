using UnityEngine;
using System.Collections;

public class SwordHeroWalkArea : MonoBehaviour {
	public bool MouseIsOver = false;
	public bool MouseIsDown = false;

	void OnMouseDown() {
		MouseIsDown = true;
		if (HeroSwordGamePlay.SelfClicking != null) {
			HeroSwordGamePlay.SelfClicking = "WalkableArea";
		}

	}
}
