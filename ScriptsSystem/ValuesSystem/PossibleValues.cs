using UnityEngine;

public class PossibleValues : MonoBehaviour {

    public static int total_of_points = 0; //GUARDA A PONTUAÇÃO DO JOGADOR
    public static int one_more = 0;    //QUADRA OS +1 QUE O JOGADOR DEIXOU PASSAR
    public static int one_less = 0;    //QUADRA OS -1 QUE O JOGADOR DEIXOU PASSAR
    public static int zero = 0;    //QUADRA OS 0 QUE O JOGADOR DEIXOU PASSAR

    public bool flag_Menu = false; //ATIVADO QUANDO FOR USADO APENAS PARA ESTETICA

    int percentage_one_more = 200;
    int percentage_one_less = 200;

    int cont_one_more = 0;
    int cont_one_less = 0;
    int cont_zero = 0;

    //INIT METODOS
    /// <summary>
    /// RETORNA UM VALOR DA LISTA
    /// </summary>
    /// <returns></returns>
    public string ChooseValue()
    {
        if (!flag_Menu)
        {
            int aux = Random.Range(0, 1000);

            if (aux <= percentage_one_less)
                return "-1";
            else if (aux > percentage_one_less && aux <= percentage_one_less + percentage_one_more)
                return "+1";
            else
                return "0";
        }
        else
            return "";
        
    }
    /// <summary>
    /// COM BASE NO VALOR DE ENTRADA ELE COMPARA COM A LISTA DE POSSIBILIDADES
    /// E ATRIBUI MAIS UM PARA CADA KEY NÃO CLICADA
    /// </summary>
    /// <param name="value"></param>
    public void AccountErrors(string value)
    {
        if (!flag_Menu)
        {
            if (value == "0")
            {
                zero += 1;
            }
            else if (value == "-1")
            {
                one_less += 1;
                //total_of_points += 1;
            }
            else if (value == "+1")
            {
                one_more += 1;
                //if(total_of_points > 0)
                //    total_of_points -= 1;
            }
            else
                Debug.LogError("Valor atribuido não indentificado nos erros");
        }
    }
    /// <summary>
    /// CONTROLA A PONTUAÇÃO DO JOGADOR USANDO OS VALORES 0, +1, -1 DAS KEYS CLICADAS
    /// </summary>
    /// <param name="value"></param>
    public void Scoring(string value)
    {
        if (!flag_Menu)
        {
            if (value == "-1")
            {
                total_of_points -= 1;
                //INIT AUMENTO DE CHANCE DE 
                ++cont_one_less;
                cont_one_more = 0;
                if (cont_one_less >= 5)
                {
                    cont_one_less = 0;
                    Stopwatch.second -= 2;
                    percentage_one_more -= 2;
                }
                //END AUMENTO DE CHANCE DE 
            }
            else if (value == "+1")
            {
                total_of_points += 1;
                ++cont_one_more;
                if (cont_one_more >= 5)
                {
                    cont_one_more = 0;
                    Stopwatch.second += 2;
                }
            }
            else if (value == "0")
            {
                //INIT AUMENTO DE CHANCE DE +1 APARECER
                ++cont_zero;
                if (cont_zero > 5)
                {
                    cont_zero = 0;
                    percentage_one_more += 2;
                }
                //END AUMENTO DE CHANCE DE +1 APARECER
            }
            else
                Debug.LogError("Valor atribuido não indentificado no escore");
        }
    }
    //END METODOS
    void Start()
    {
        total_of_points = 0;
        one_more = 0;
        one_less = 0;
        zero = 0;
        percentage_one_more = 200;
        percentage_one_less = 200;
    }
}
