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
            foreach (var item in mapa.Pontos)
            {
                Console.WriteLine(item.X);
                Console.WriteLine("===========================================================");
                Console.WriteLine(item.Y);
            }

            Console.ReadKey();
        }
    }
}
