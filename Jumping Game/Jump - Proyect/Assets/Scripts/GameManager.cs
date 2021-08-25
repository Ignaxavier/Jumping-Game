using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Player Things
    private         GameObject      player          =       null;

    private         CoinsCollector  pCoins          =       null;

    private         Jumping         pJump           =       null;
    #endregion

    #region Score Floats
    public          float           _maxHeight      =       0f;

    public          float           _timeLive       =       0f;

    public          float           _score          =       0f;
    #endregion

    #region Score Texts
    [SerializeField]
    private         Text            _secondsText    =       null;

    [SerializeField]
    private         Text            _heightText     =       null;

    [SerializeField]
    private         Text            _coinText       =       null;
    #endregion

    [SerializeField]
    [Tooltip("Valor que se multiplica al puntaje")]
    private         float           scoreMultiplyer =       1.5f;

    [SerializeField]
    private         Grayscale[]     grayscaleObjects;

    [HideInInspector]
    public          bool            isSlow          =       false;

    private         bool            isFinish        =       false;

    private void Awake()
    {
        grayscaleObjects = FindObjectsOfType<Grayscale>();

        player = GameObject.FindGameObjectWithTag("Player");

        pJump = player.GetComponent<Jumping>();
        pCoins = player.GetComponent<CoinsCollector>();
    }

    private void Update()
    {
        Grayscale();
        LiveTime();
        UITexts();

        if (pJump.isDead & !isFinish)
        {
            _score = Mathf.Round(((_timeLive + _maxHeight) * pCoins._coins) * scoreMultiplyer);
            
            Debug.Log("Has sobrevivido " + Mathf.Round(_timeLive) + " segundos y has alcanzado los " + _maxHeight + " metros.");
            Debug.Log("Tu puntaje final es de " + _score);
            isFinish = true;
        }
    }

    private void Grayscale()
    {
        if (isSlow)
        {
            for(int i = 0; i < grayscaleObjects.Length; i++)
            {
                grayscaleObjects[i].StartGrayscaleRoutine();
            }
        }
        else if (!isSlow)
        {
            for(int i = 0; i < grayscaleObjects.Length; i++)
            {
                grayscaleObjects[i].ResetGrayscaleRoutine();
            }
        }
    }

    private void LiveTime()
    {
        if(pJump.isStartJump && !pJump.isDead)
        {
            _timeLive += Time.deltaTime;
        }
    }

    private void UITexts()
    {
        _secondsText.text = Mathf.Round(_timeLive).ToString() + "s";
        _heightText.text = _maxHeight.ToString() + "mts";
        _coinText.text = "Coins: " + pCoins.coinsAmount.ToString();
    }
}
