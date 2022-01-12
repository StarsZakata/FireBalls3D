using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Tank : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Bullet bullettemplate;
    [SerializeField] private float delayBetweenShoots;
	[SerializeField] private float recoilDistance;

	private float timeAfterShoot;

	private void Update()	{
		timeAfterShoot += Time.deltaTime;

		if (Input.GetMouseButton(0)) {
			if (timeAfterShoot > delayBetweenShoots) {
				Shoot();
				transform.DOMoveZ(transform.position.z - recoilDistance, delayBetweenShoots / 2).SetLoops(2, LoopType.Yoyo);
				timeAfterShoot = 0;
			}
		}
	}
	private void Shoot() {
		Instantiate(bullettemplate, shootPoint.position, Quaternion.identity);
	}
}
