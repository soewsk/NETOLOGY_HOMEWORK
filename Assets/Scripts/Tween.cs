using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Tween : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _time = 5f;
    [SerializeField] private int _repeat = 4;
    [SerializeField] private Renderer _playerRenderer;
    void Start()
    {
        Material playerMat = _playerRenderer.material;
        Sequence colorSequence = DOTween.Sequence();
        Vector3[] path = new Vector3[_points.Length];
        for(int i = 0; i < _points.Length; i++)
        {
            path[i] = _points[i].position;
        }
        transform.DOPath(path, _time).SetEase(Ease.InOutSine).SetLoops(_repeat, LoopType.Yoyo); //Цикличное движение по точка

        DOTween.To(() => playerMat.color, color => playerMat.color = color, Color.red, _time);
        colorSequence.Append(DOTween.To(() => playerMat.color, color => playerMat.color = color, Color.red, _time)); // меняем цвет в красный
        colorSequence.Append(DOTween.To(() => playerMat.color, color => playerMat.color = color, Color.yellow, _time));// меняем цвет в жёлтый
        colorSequence.Append(DOTween.To(() => playerMat.color, color => playerMat.color = color, Color.green, _time));// меняем цвет в зеленый
        colorSequence.Append(DOTween.To(() => playerMat.color, color => playerMat.color = color, Color.blue, _time));// меняем цвет в синий
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
