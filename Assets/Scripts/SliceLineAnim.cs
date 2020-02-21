using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceLineAnim : MonoBehaviour
{
	public Material lineRenderMat;

	public Vector3 realPosA;
	public Vector3 realPosB;
	public Vector3 fakePosA;
	public Vector3 fakePosB;

	LineRenderer lr;

	void Start() {
		Destroy(gameObject, .5f);
	}

	void FixedUpdate() {
		fakePosA = Vector3.Lerp(fakePosA, realPosB, 5f * Time.fixedDeltaTime);
		fakePosB = Vector3.Lerp(fakePosB, realPosB, 10f * Time.fixedDeltaTime);
		lr.SetPosition(0, new Vector2(fakePosA.x, fakePosA.y));
		lr.SetPosition(1, new Vector2(fakePosB.x, fakePosB.y));

		if (lr.endWidth > 0f) lr.endWidth = lr.endWidth - (.6f * Time.fixedDeltaTime);
		else lr.endWidth = 0f;
	}

	public void setPos(Vector3 a, Vector3 b) {
		lr = GetComponent<LineRenderer>();
		lr.material = lineRenderMat;
		lr.startWidth = 0f;
		lr.endWidth = .2f;

		realPosA = a;
		realPosB = b;
		fakePosA = a;
		fakePosB = a;
	}
}
