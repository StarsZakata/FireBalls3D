using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text sizeVies;
    [SerializeField] private Tower tower;

	private void OnEnable()
	{
		tower.sizeUpdate += OnSizeUpdated;
	}

	private void OnDisable()
	{
		tower.sizeUpdate -= OnSizeUpdated;
	}

	private void OnSizeUpdated(int size) {
		sizeVies.text = size.ToString();
	}
}
