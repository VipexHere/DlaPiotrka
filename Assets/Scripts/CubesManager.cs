using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CubesManager : MonoBehaviour
{
    [SerializeField] private Transform[] shapes;
    [SerializeField] private Material material;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(text.DOFade(0, 0));

        foreach (var shape in shapes)
        {
            sequence.Append(shape.DOScale(Vector3.zero, 0f).SetEase(Ease.InBounce));
        }

        foreach (var shape in shapes)
        {
            sequence.Append(shape.DOScale(Vector3.one, 0.5f).SetEase(Ease.InBounce));
        }

        sequence.Append(material.DOColor(Color.red, 2));

        foreach (var shape in shapes)
        {
            sequence.Append(shape.DOMoveX(8, Random.Range(1f, 2f)));
        }

        sequence.Append(material.DOColor(Color.blue, 2));

        foreach (var shape in shapes)
        {
            sequence.Append(shape.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce));
        }
        
        sequence.Append(text.DOFade(1, 2));
    }
}
