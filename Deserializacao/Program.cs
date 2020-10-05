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
            FileStream fs = new FileStream(@"C:\Users\mauri\Desktop\Treinamento\ProvasAprovadas\Sessao4SC\Projeto teste\SUGESTÃO SESSÃO 4 SC\DATA FILES\mapeamento.dat", FileMode.Open);
            // Cria um objeto BinaryFormatter para realizar a dessarialização
            BinaryFormatter bf = new BinaryFormatter();
            Mapa mapa =(Mapa)bf.Deserialize(fs);

            // fecha o arquivo
            fs.Close();
            // exibe o objeto desserializada
            foreach (var item in mapa.Pontos)
            {
                Console.WriteLine(item.X);
                Console.WriteLine("===========================================================");
                Console.WriteLine(item.Y);
            }

            Console.WriteLine(mapa.Ligacoes[5,3]);
            Console.ReadKey();
        }
    }
}
