using UnityEngine;
using System.Collections.Generic;

public class KeysManager : MonoBehaviour {

    public List<KeyList> carriers;  //LISTA DE KEYLIST
    public bool end_game = false;   //SINAL PARA CONFIRMA QUE TODOS OS ESPAÇOS FORAM PREENCHIDOS
    public float delay = 1.5f;    //DELAY DE ATIVAÇÃO
    float time = 0; //TIME PARA A ATIVAÇÃO

    bool flag = false; //SINAL DA ATIVAÇÃO
    int num;    //POSIÇÃO DA KEYLIST

    //INIT METODOS
    /// <summary>
    /// VERIFICA SE TODAS KEYLIST DE CARRIERS ESTÃO ATIVAS
    /// </summary>
    void CheckList()
    {}
    /// <summary>
    /// CRONOMETRO PARA ATIVAR UMA NOVA KEY
    /// </summary>
    void stopwatch()
    {
        if (time > delay && flag == false)
        {
            flag = true;
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
            flag = false;
        }
    }
    /// <summary>
    /// DIMINUI O DELAY CONFORMA O NUMERO DE KEYS ESTÃO SENDO ATIVADAS
    /// </summary>
    void ShortenTime()
    {
        if(flag == true && delay > 0.3f)
        {
            delay -= 0.15f;
        }
    }
    //END METODOS
    void Start()
    {
        time = delay;
        Stopwatch.over_time = false;
    }
    void Update () {
        if (!Stopwatch.over_time)
        {
            ShortenTime();
            //VERIFICA SE A FLAG TA ATIVA PARA ENVIAR O SINAL PARA KEYLIST
            if (flag)
            {
                num = Random.Range(0, carriers.Count); //ESCOLHE UMA KEYLIST DE CARRIERS

                /*while (carriers[num].flag_full == true)
                {
                    if (!end_game)
                        num = Random.Range(0, carriers.Count);
                    else
                        break;
                }*/

                carriers[num].active_key_list = true;
                flag = false;
            }
            else if (!flag)
                stopwatch();
        }
	}
}
