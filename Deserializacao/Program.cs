using BibliotecaMapa;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            Mapa mapa = (Mapa)bf.Deserialize(fs);
            // fecha o arquivo
            fs.Close();
            //Aqui é um teste direto nos pontos a partir de calculos que fizemos sem pegar o ponto médio de forma dinâmica
            Console.WriteLine("Cordenadas do ponto médio 10 de uma rua aleatória: " + mapa.Pontos[10].X + " - " + mapa.Pontos[10].Y);
            Console.WriteLine("===================================================================================================");
            Console.WriteLine("Cordenadas do ponto médio 100 de uma rua aleatória: " + mapa.Pontos[100].X + " - " + mapa.Pontos[100].Y);
            Console.WriteLine("===================================================================================================");
            Console.WriteLine("Distância para percorrer do ponto médio 10 até o 100: " + mapa.Ligacoes[10, 100]);
            Console.WriteLine("===================================================================================================");
            Console.WriteLine("Número de potos no mapa: " + mapa.Pontos.Count);
            Console.WriteLine("===================================================================================================");
            //-----------------------------------------------------------------------------------------------------------

            //RUA A

            //-----------------------------------------------------------------------------------------------------------
            //Pegando o index da rua a partir do nome dela
            var indexRuaA = mapa.Ruas.FindIndex(r => r.Nome == "Rua almeida barros");
            Console.WriteLine("Index da Rua A: " + indexRuaA);
            Console.WriteLine("Localizando a Rua A no mapa: " + mapa.Ruas[indexRuaA].Nome);
            //Pegando o ponto médio da rua A
            var round = mapa.Ruas[indexRuaA].Pontos.Count / 2;
            var pontoMedioRuaA = Math.Abs(round);
            Console.WriteLine("Ponto Médio da rua A: " + pontoMedioRuaA);
            //Mostrando o ponto x e y que se refere ao ponto médio da rua, ou seja as cordenadas do ponto médio da rua A
            Console.WriteLine("Cordenadas do ponto médio da rua A: " + mapa.Ruas[indexRuaA].Pontos[pontoMedioRuaA].X + " - " + mapa.Ruas[indexRuaA].Pontos[pontoMedioRuaA].Y);
            //Efetuo uma busca pela adjacência desses pontos
            var adjacenciaA = mapa.Pontos.FindIndex(p => p.X == mapa.Ruas[indexRuaA].Pontos[pontoMedioRuaA].X && p.Y == mapa.Ruas[indexRuaA].Pontos[pontoMedioRuaA].Y);
            //Mostro a Adjacência desses pontos
            Console.WriteLine("Adjacencia A:" + adjacenciaA);
            Console.WriteLine("===================================================================================================");
            //-----------------------------------------------------------------------------------------------------------

            //RUA B

            //-----------------------------------------------------------------------------------------------------------
            //Pegando o index da rua a partir do nome dela
            var indexRuaB = mapa.Ruas.FindIndex(r => r.Nome == "Rua Kakashi");
            Console.WriteLine("Index da Rua B: " + indexRuaB);
            Console.WriteLine("Localizando a Rua B no mapa: " + mapa.Ruas[indexRuaB].Nome);
            //Pegando o ponto médio da rua B
            round = mapa.Ruas[indexRuaB].Pontos.Count / 2;
            var pontoMedioRuaB = Math.Abs(round);
            //Mostrando o ponto x e y que se refere ao ponto médio da rua, ou seja as cordenadas do ponto médio da rua B
            Console.WriteLine("Cordenadas do ponto médio da rua B: " + mapa.Ruas[indexRuaB].Pontos[pontoMedioRuaB].X + " - " + mapa.Ruas[indexRuaB].Pontos[pontoMedioRuaB].Y);
            //Efetuo uma busca pela adjacência desses pontos
            var adjacenciaB = mapa.Pontos.FindIndex(p => p.X == mapa.Ruas[indexRuaB].Pontos[pontoMedioRuaB].X && p.Y == mapa.Ruas[indexRuaB].Pontos[pontoMedioRuaB].Y);
            Console.WriteLine("Adjacencia B:" + adjacenciaB);
            Console.WriteLine("===================================================================================================");
            //Mostrando o caminho mais curto entre as duas ruas
            Console.WriteLine("Resultado da busca na matrix para saber o caminho mais curto: " + mapa.Ligacoes[adjacenciaA, adjacenciaB]);




            Console.ReadKey();
        }
    }
}
