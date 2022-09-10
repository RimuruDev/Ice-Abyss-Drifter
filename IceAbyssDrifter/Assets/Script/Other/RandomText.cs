using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomText : MonoBehaviour
{
    [SerializeField] Text _textRandom;

    private string _randomText;
    [SerializeField] string[] _text;

    private int _randomaizer;

    void Start()
    {
        _randomaizer = Random.Range(0, _text.Length);

        _randomText = _text[_randomaizer];
        _textRandom.text = _randomText;
    }
}
