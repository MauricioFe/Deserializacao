using BibliotecaMapa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Deserializacao
{
    class Program
    {
        static void Main(string[] args)
        {
            //alterar caminho do arquivo .Dat para o que eu adicionei no projeto
            FileStream fs = new FileStream(@"C:\Users\mauri\Desktop\Treinamento\ProvasAprovadas\Sessao4SC\Projeto teste\SUGESTÃO SESSÃO 4 SC\DATA FILES\mapeamento.dat", FileMode.Open);
            // Cria um objeto BinaryFormatter para realizar a dessarialização
            BinaryFormatter bf = new BinaryFormatter();
            //É preciso adicionar uma referência da dll BibliotecaMapa para que a desserialização funcione. A dll ta na pasta do projeto
            Mapa mapa =(Mapa)bf.Deserialize(fs);

            // fecha o arquivo
            fs.Close();
            // exibe o objeto desserializada
            //Aqui temos um exeplos para mostrar alguns dados que chegam do arquivo. Pode ser alterado para a exibição de novos dados
            for (int i = 0; i < 1293; i++)
            {
                for (int j = 0; j < 1293; j++)
                {
                    Console.Write(mapa.Ligacoes[i,j] + "\t");
                }
                Console.WriteLine();
            }
            //Tamanho da matriz de ligações = 1.671.849
            //numero de colunas e linhas = 1.293
            //trabalha aparentemente de forma binária. quando eu coloquei um for de tamanho 10 eu consegui identificar 
            //Valores 0 e 5, mas como se trabalha com muitos dados não deu para explorar tudo.
            Console.WriteLine(mapa.Ligacoes.Length);
           

            int[,] bacon = new int [1293,1293];
            Console.WriteLine(bacon.Length);
            Console.ReadKey();
        }
    }
}
