using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float towerSize;
    [SerializeField] private Transform buildPoint;
    [SerializeField] private Block block;

	[SerializeField] private Color[] colors;

	//Использование Структуры Листа
	private List<Block> blocks;
	/*
	private void Start()
	{
		//Build();
	}
	*/
	/// <summary>
	/// Метод для Реализации Строительства 
	/// При этом инициализируентся переменная, создается начальная точка для ПервогоБлока
	/// Далее создается блок, загружается в лист и точка перемещается "выше"
	/// </summary>
	/// <returns></returns>
	public List<Block> Build() {
		blocks = new List<Block>();

		Transform currentpoint = buildPoint;

		for (int i = 0; i < towerSize; i++)
		{
			Block newBlock = BuildBlock(currentpoint);
			newBlock.SetColor(colors[Random.Range(0, colors.Length)]);
			blocks.Add(newBlock);
			currentpoint = newBlock.transform;
		}

		return blocks;
	}
	/// <summary>
	/// Непосредстванное создание нового блока в указанной точке (с поправками)
	/// </summary>
	/// <param name="currentBuildPoint"></param>
	/// <returns></returns>
	private Block BuildBlock(Transform currentBuildPoint) {

		return Instantiate(block, GetBuildPoint(currentBuildPoint), Quaternion.Euler(90,0,0), buildPoint);
	}

	/// <summary>
	/// Определение точки создания нового блока (с поправками)
	/// </summary>
	/// <param name="currentSegment"></param>
	/// <returns></returns>
	private Vector3 GetBuildPoint(Transform currentSegment) {
		return new Vector3(buildPoint.position.x + 3.5f, currentSegment.position.y+ block.transform.localScale.y / 2, buildPoint.position.z);
		//return new Vector3(buildPoint.position.x+3.5f, currentSegment.position.y + currentSegment.localScale.y / 2 + block.transform.localScale.y / 2, buildPoint.position.z); 
	}
}
