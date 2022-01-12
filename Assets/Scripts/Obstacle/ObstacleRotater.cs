using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleRotater : MonoBehaviour
{

	[SerializeField] private float animatronDuration;
	private void Start()
	{
		transform.DORotate(new Vector3(0, 360, 0), animatronDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo); 
	}
}
