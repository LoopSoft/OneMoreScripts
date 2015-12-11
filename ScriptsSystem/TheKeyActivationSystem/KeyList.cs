using UnityEngine;
using System.Collections.Generic;

public class KeyList : MonoBehaviour {

    public List<Key> key_list;  //LISTA COM KEYS QUE ESTÃO CONTIDAS NESSA COLUNA
    public bool active_key_list = false;  //SINEL PARA SER ENVIADO PARA UMA DAS KEY
    //public bool flag_full = false;  //SINAL INFORMANDO QUE TODAS AS KEYS ESTÃO ATIVAS

    int num;    //CONTADOR
    
    //INIT METODOS
    /// <summary>
    /// VAI VERIFICAR SE TODAS AS KEY DA KEY_LIST ESTÃO TIVAS
    /// </summary>
    void CheckList()
    {}
    /// <summary>
    /// ENVIA O SINAL PARA UMA DAS KEY DA LISTA KEY_LIST
    /// </summary>
    void CheckButton()
    {
        if (active_key_list)
        {
            num = Random.Range(0, key_list.Count); //ESCOLHE ALEATORIAMENTE UMA KEY DA KEY_LIST

            //while (key_list[num].active_key == true)//Verifica se a key esta ativada.
                //num = Random.Range(0, key_list.Count);

            key_list[num].active_key = true;
            active_key_list = false;
        }
        else
        {
            active_key_list = false;
        }
    }
    //END METODOS
    void Update () {
        CheckList();
        CheckButton();
    }
}
