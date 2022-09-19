using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace RimuruDev
{
    [System.Serializable]
    public sealed class AudioForOre
    {
        [SerializeField] public AudioSource _boomAudio;
        [SerializeField] public AudioSource _horneSpound;
        [SerializeField] public AudioSource _goldSpound;
        [SerializeField] public AudioSource _raportMachine;
        [SerializeField] public AudioSource _soldMachine;
        [SerializeField] public AudioSource _terrakotaPickSound;
        [SerializeField] public AudioSource _seniPick;
        [SerializeField] public AudioSource _poop;
        [SerializeField] public AudioSource _thhe;

        public void Sfx()
        {
            _boomAudio.pitch = UnityEngine.Random.Range(0.7f, 1f);
            _boomAudio.Play();
        }
    }

    public sealed class GameDataContainer : MonoBehaviour
    {
        [Header("Audio for ore")]
        public AudioForOre audioForOre;


        [Header("Currency")]
        [SerializeField] private float copperCoin;
        public float CorrerCoin => copperCoin;

        [Header("Player")]
        [SerializeField] private GameObject activePlayer;
        public GameObject GetActivePlayer => activePlayer;

        [Header("Shop")]
        [SerializeField] private float[] prices;
        public float[] Prices { get => prices; set => prices = value; }

        [SerializeField] private string[] oreID;
        public string[] OreID { get => oreID; set => oreID = value; }

        public int SpaceOre;
        public int GoldOre;
        public int HoneyOre;
        public int IronOre;
        public int MoonOre;
        public int CoalOre;
        public int RubyOre;

        public Text SpaceOreText;
        public Text GoldOreText;
        public Text HoneyOreText;
        public Text IronOreText;
        public Text MoonOreText;
        public Text CoalOreText;
        public Text RubyOreText;
        [Space]
        public string[] oreTagPool;
        [Space]
        public Dictionary<string, int> oreDictionary;

        private void Start()
        {
            oreDictionary = new Dictionary<string, int>();

            for (var i = 0; i < oreTagPool.Length; i++)
            {
                oreDictionary.Add(oreTagPool[i], 0);
            }

            Debug.Log(oreDictionary.Count);
        }

        private void OnValidate()
        {
            if (activePlayer == null) activePlayer = GameObject.FindGameObjectWithTag("Player");
        }
    }
}