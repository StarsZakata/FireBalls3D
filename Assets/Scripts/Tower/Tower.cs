using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour{
    private TowerBuilder towerBuilder;
    private List<Block> blocks;

    public event UnityAction<int> sizeUpdate;
    void Start()    {
        towerBuilder = GetComponent<TowerBuilder>();
        blocks = towerBuilder.Build();

        foreach (var block in blocks) {
            block.BulletHit += OnBulletHit;        }

        sizeUpdate?.Invoke(blocks.Count);
    }


    private void OnBulletHit(Block hitedblock) {
        hitedblock.BulletHit -= OnBulletHit;
        blocks.Remove(hitedblock);
        foreach (var block in blocks) {
            block.transform.position = new Vector3(block.transform.position.x,block.transform.position.y -  0.45f,block.transform.position.z);
        }
        sizeUpdate?.Invoke(blocks.Count);
    }
}
