using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// sempre deve ser usado com objetos do tipo IMAGE do CANVAS.
/// </summary>
public class Key : MonoBehaviour {

    public Color new_color; //COR QUE VAI SER USADA QUANDO KEY ATIVADA
    public Color old_color; //COR QUANDO A KEY ESTA DESATIVADA
    public Text text;
    public bool active_key = false; //INDICADOR SE A KEY ESTA ATIVADA OU DESATIVADA

    float time = 0; //VARIAVEL PARA CRONOMETRO
    int cont = 1;   //VERIFICA SE A KEY COMPLETOU UM CICLO DE ATIVAÇÃO
    string value_key;
    public PossibleValues value;    //RECEBE UM VALOR ENTRE 0, -1, +1.
    
    //INIT METODOS
    /// <summary>
    /// CRONOMETRO PARA DESATIVAR A KEY DEPOIS DE 1.5s
    /// </summary>
    void stopwatch()
    {
        if (!Stopwatch.over_time) {
            if (time > 1f)
            {
                time = 0;
                gameObject.GetComponent<Image>().color = old_color;
                active_key = false;
                value.AccountErrors(value_key);
                //CASO A KEY JÁ TENHA CIDO ATIVADA ELE AQUI CONFIRMA QUE O CICLO DE ATIVAÇÃO FOI CONCLUIDO
                if (cont > 1)
                    cont -= 1; ;
                //END 
            }
            else if (time < 1.5f && active_key == true)
            {
                time += Time.deltaTime;
            }
            else
                time = 0;
        }
    }
    /// <summary>
    /// FUNÇÃO QUE INDENTIFICA O CLICK EM CIMA DA KEY PARA DESATIVAR
    /// </summary>
    /// <param name="key"></param>
    public void ClickedButton(Key key)
    {
        key.active_key = false;
        value.Scoring(value_key);
        value_key = "";
        //CASO A KEY JÁ TENHA CIDO ATIVADA ELE AQUI CONFIRMA QUE O CICLO DE ATIVAÇÃO FOI CONCLUIDO
        if(cont > 1)
            cont -= 1;
    }
    //END METODOS
    void Start()
    {
        if (text != null)
        {
            //VERIFICA SE AS CORES ESTÃO TRANSPARENTES 
            if (new_color.a < 255 || old_color.a < 255)
            {
                Debug.LogWarning("Imagem transparente");
                new_color.a = 255;
                old_color.a = 255;
            }
            //END
        }
    }
    void Update () {
        if (text != null)
        {
            stopwatch();    //CONTA O TEMPO QUE A KEY ESTA ATIVA
                            //ALTERA A COR DA KEY CONFORME A VARIAVEL ACTIVE_KEY
            if (active_key)
            {
                gameObject.GetComponent<Image>().color = new_color;
                //CASO A KEY ESTEJA DESATIVADA ELE PERMITE A ATIVAÇÃO E A MUDANÇA DE VALOR.
                if (cont == 1)
                {
                    cont += 1;
                    value_key = value.ChooseValue();
                    text.text = value_key;
                    //print(value.ChooseValue());
                }
                //END
            }
            else if (!active_key)
            {
                gameObject.GetComponent<Image>().color = old_color;
                text.text = ""; //RESETA O VALOR ANTERIOR
            }
            //END
        }
        else
            Debug.LogError("Variavel text não declarada!");
	}
}
