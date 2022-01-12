using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class Block : MonoBehaviour{

	[SerializeField] private ParticleSystem desrtoyEffects;

	private MeshRenderer meshRenderer;

	private void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
	}

	public event UnityAction<Block> BulletHit;

	public void SetColor(Color color) {
		meshRenderer.material.color = color;
	
	}
	public void Break()	{
		BulletHit?.Invoke(this);

		ParticleSystemRenderer renderer = Instantiate(desrtoyEffects, transform.position, desrtoyEffects.transform.rotation).GetComponent<ParticleSystemRenderer>();
		renderer.material.color = meshRenderer.material.color;
		Destroy(gameObject);
	}
}
