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
            Point pontoX = new Point(79, 149);
            Point pontoY = new Point(479, 388);
            Console.WriteLine(mapa.Pontos[425].X + "\n" + mapa.Pontos[425].Y);
            Console.WriteLine("==========================================");
            Console.WriteLine(mapa.Pontos[687].X + "\n" + mapa.Pontos[687].Y);
            Console.WriteLine("==========================================");
            Console.WriteLine(mapa.Ligacoes[425, 687]);
            Console.WriteLine("==========================================");
            Console.WriteLine(mapa.Pontos.Count);
            Console.WriteLine("==========================================");
            //-----------------------------------------------------------------------------------------------------------

            //RUA A

            //-----------------------------------------------------------------------------------------------------------
            //Pegando o index da rua a partir do nome dela
            var indexRuaA = mapa.Ruas.FindIndex(r => r.Nome == "Rua Vitor");
            Console.WriteLine("Index da Rua A: " + indexRuaA);
            Console.WriteLine("Localizando a Rua A no mapa: " + mapa.Ruas[indexRuaA].Nome);
            Console.WriteLine("==========================================");
            //Pegando o ponto médio da rua A
            var round = mapa.Ruas[indexRuaA].Pontos.Count / 2;
            var pontoMedioRuaA = Math.Abs(round);
            Console.WriteLine("Ponto Médio da rua a: " + pontoMedioRuaA);
            //Mostrando o ponto x e y que se refere ao ponto médio da rua, ou seja as cordenadas do ponto médio da rua A
            Console.WriteLine("Cordenadas do ponto médio da rua B: " + mapa.Ruas[indexRuaA].Pontos[pontoMedioRuaA].X + " - " + mapa.Ruas[indexRuaA].Pontos[pontoMedioRuaA].Y);
            Console.WriteLine("==========================================");
            //Efetuo uma busca pela adjacência desses pontos
            var adjacenciaA = mapa.Pontos.FindIndex(p => p.X == mapa.Ruas[indexRuaA].Pontos[pontoMedioRuaA].X && p.Y == mapa.Ruas[indexRuaA].Pontos[pontoMedioRuaA].Y);
            //Mostro a Adjacência desses pontos
            Console.WriteLine("Adjacencia A:" + adjacenciaA);
            Console.WriteLine("==========================================");
            //-----------------------------------------------------------------------------------------------------------

            //RUA B

            //-----------------------------------------------------------------------------------------------------------
            //Pegando o index da rua a partir do nome dela
            var indexRuaB = mapa.Ruas.FindIndex(r => r.Nome == "Rua fagundes");
            Console.WriteLine("Index da Rua B: " + indexRuaB);
            Console.WriteLine("Localizando a Rua B no mapa: " + mapa.Ruas[indexRuaB].Nome);
            Console.WriteLine("==========================================");
            //Pegando o ponto médio da rua B
            round = mapa.Ruas[indexRuaB].Pontos.Count / 2;
            var pontoMedioRuaB = Math.Abs(round);
            //Mostrando o ponto x e y que se refere ao ponto médio da rua, ou seja as cordenadas do ponto médio da rua B
            Console.WriteLine("Cordenadas do ponto médio da rua B: " + mapa.Ruas[indexRuaB].Pontos[pontoMedioRuaB].X + " - " + mapa.Ruas[indexRuaB].Pontos[pontoMedioRuaB].Y);
            Console.WriteLine("==========================================");
            //Efetuo uma busca pela adjacência desses pontos
            var adjacenciaB = mapa.Pontos.FindIndex(p => p.X == mapa.Ruas[indexRuaB].Pontos[pontoMedioRuaB].X && p.Y == mapa.Ruas[indexRuaB].Pontos[pontoMedioRuaB].Y);
            Console.WriteLine("Adjacencia B:" + adjacenciaB);
            Console.WriteLine("==========================================");

            Console.WriteLine("Resultado da busca na matrix para saber o caminho mais curto: " + mapa.Ligacoes[adjacenciaA, adjacenciaB]);
            Console.ReadKey();
        }
    }
}
