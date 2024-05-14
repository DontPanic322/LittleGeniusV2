using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NumberManager : MonoBehaviour
{
    [SerializeField] private List<NumberSlot> _slotPrefabs;
    [SerializeField] private NumberPiece _piecePrefab;
    [SerializeField] private Transform _slotParent, _pieceParent;

    public int gameProgress = 0;

    public GameManager manager;
    public int numberToWin;

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (gameProgress == numberToWin)
        {
            manager.Winning();
            Debug.Log("Уровень пройден!");
        }
    }

    void Spawn()
    {
        var randomSet = _slotPrefabs.OrderBy(s => Random.value).Take(10).ToList();

        for (int i = 0; i < randomSet.Count; i++)
        {
            var spawnedSlot = Instantiate(randomSet[i], _slotParent.GetChild(i).position, Quaternion.identity);

            var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);
            spawnedPiece.Init(spawnedSlot);
        }
    }
        
}

