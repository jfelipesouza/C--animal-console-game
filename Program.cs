using System;
using System.Threading;

class Program
{

  static void Main()
  {
    const float initalState = 100; // valor inicial e máximo para cada caracteristica do animal
    string name = ""; // nome do bicho
    string yourName = ""; // nome do jogador
    float satiated = initalState; // fome do animal
    float clean = initalState; // limpeza do animal
    float happy = initalState; // felicidade do animal
    byte character = 0; // id de caracterisca de animal
    bool isContinue = true; // Variavel para saber se continua ou não o jogo
    bool isLiving = true; // Variavel para saber se continua vivo

    Random randomNumbers = new Random(); // instacia para numeros aleatorios
    const byte upStates = 20; // Valor de acrescimo de numeros aleatorios

    string[] talks = new string[29]; // Frases do Animal para o Dono

    talks[0] = "O dia foi incrível, comi muito";
    talks[1] = "Que saudades, passei o dia inteiro pensando em você";
    talks[2] = "Hoje assisti nossa série sem você. Você está bravo?";
    talks[3] = "Você é a pessoa mais importante para mim";
    talks[4] = "Tive um sonho maluco hoje!";
    talks[5] = "Descobri um esconderijo secreto!";
    talks[6] = "Estava pensando em aprender a voar...";
    talks[7] = "Quase fui pego no meio de uma travessura!";
    talks[8] = "Fiz um amigo novo hoje, mas ele era um pouco assustador...";
    talks[9] = "Encontrei um lugar super aconchegante para tirar uma soneca.";
    talks[10] = "Estava brincando e acabei me sujando todo!";
    talks[11] = "Você não vai acreditar na bagunça que fiz...";
    talks[12] = "Senti sua falta quando você não estava por perto.";
    talks[13] = "Hoje encontrei um petisco delicioso!";
    talks[14] = "Tive um dia tranquilo hoje, mas senti sua falta.";
    talks[15] = "Estava explorando e acabei me perdendo um pouco.";
    talks[16] = "Pensei em você quando vi um pássaro voando alto.";
    talks[17] = "Queria poder te contar sobre tudo que vi hoje.";
    talks[18] = "Tive um susto hoje, mas estou bem!";
    talks[19] = "Descobri uma nova brincadeira bem divertida.";
    talks[20] = "Você é meu herói!";
    talks[21] = "Adoro quando me leva para passear!";
    talks[22] = "Fiz um amigo canino hoje, foi bem legal!";
    talks[23] = "Estava ensaiando alguns truques novos.";
    talks[24] = "Hoje vi um gato na janela e quis dizer olá!";
    talks[25] = "Passei o dia pensando em como ser um bom amigo.";
    talks[26] = "Você sempre me alegra quando estou triste.";
    talks[27] = "Fui confundido com um brinquedo hoje!";
    talks[28] = "Sonhei que voava e era incrível!";


    Console.WriteLine("Olá! Seja bem-vindo(a) ao My Digital Animal\n");

    if (yourName == "")
    {
      Console.WriteLine("Qual o seu nome?");
      yourName = Console.ReadLine();
    confirmYourName:
      Console.WriteLine("Digite S para confimar e N para digitar outro nome ");
      string verify = Console.ReadLine();
      Thread.Sleep(500);
      if (verify != null && verify.Trim().ToLower() == "s")
      {
        Console.WriteLine("Seu cadastro foi realizado com sucesso.");
      }
      else
      {
        goto confirmYourName;
      }
    }
    else
    {
      Console.WriteLine("Bem-vindo de volta {0}", yourName);
      Thread.Sleep(500);
    }
    if (name.Trim().ToLower() == "")
    {
      Console.WriteLine("Vejo que é novo por aqui, dê um nome ao seu bichinho.");
      while (true)
      {
        string currentName = Console.ReadLine();

        if (currentName != null && currentName.Length > 0)
        {
          Console.WriteLine("O nome dele será {0}?", currentName);
        confirm:
          try
          {
            Console.WriteLine("Tem certeza? Digite S para confirmar e N para escolher outro");
            char confirmKey = char.Parse(Console.ReadLine().Substring(0).ToLower());
            if (confirmKey == 's')
            {
              Console.Write("Salvando....... ");
              name = currentName;
              Thread.Sleep(1000);
              Console.Write("Salvo com sucesso\n");
              Thread.Sleep(100);
              Console.WriteLine("Pressione enter para continuar");
              Console.ReadKey();
              Console.Clear();
              break;
            }
            else if (confirmKey == 'n')
            {
              Console.WriteLine("Ok! Qual o nome dele então?");
            }
            if (confirmKey != 's' && confirmKey != 'n')
            {
              throw new Exception();
            }
          }
          catch (Exception)
          {
            Console.WriteLine("Escolha inválida");
            goto confirm;
          }
        }
        else
        {
          Console.WriteLine("Digite um nome válido");
        }
      }
    }
    else
    {
      Console.WriteLine("{0}, estava com muita saudade\n", name);
      Thread.Sleep(500);
    }

    while (isContinue)
    {
      character = Convert.ToByte(randomNumbers.Next(3));
      switch (character)
      {
        case 0:
          satiated -= randomNumbers.Next(10);
          break;
        case 1:
          clean -= randomNumbers.Next(10);
          break;
        case 2:
          happy -= randomNumbers.Next(10);
          break;
      }

      Console.Clear();
      // Console.WriteLine("Alimentado: {0}\nLimpo: {1}\nFeliz: {2}", satiated, clean, happy);
      if (satiated > 20 && satiated < 75)
      {
        Console.WriteLine("Estou com fome");
        Console.WriteLine("Nada melhor do que uma comidinha...");

        Thread.Sleep(1000);
        Console.Clear();
      }
      if (clean > 20 && clean < 75)
      {
        Console.WriteLine("Estou tão sujo");
        Console.WriteLine("Que tal um banho?");

        Thread.Sleep(1000);
        Console.Clear();
      }
      if (happy > 20 && happy < 75)
      {
        Console.WriteLine("A vida me parece tão triste");
        Console.WriteLine("Vamos brincar?");

        Thread.Sleep(1000);
        Console.Clear();
      }
      if (happy <= 0 || satiated <= 0 || clean <= 0)
      {
        Console.WriteLine("Você me matou");
        isLiving = false;
        break;
      }
      Console.WriteLine(talks[randomNumbers.Next(talks.Length)]);
      Thread.Sleep(100);
      Console.WriteLine("O que vamos fazer hoje?");
      Console.WriteLine("Brincar: (1), Comer: (2), Tomar banho: (3), Sair: (4)");

    playerSelectAction:
      try
      {
        byte action = Convert.ToByte(Console.ReadLine());
        switch (action)
        {
          case 1:
            happy += upStates;
            if (happy > 100) happy = 100;
            Console.WriteLine("Adoro brincar com você");
            break;
          case 2:
            satiated += upStates;
            Console.WriteLine("Eu adoro essa ração");
            if (satiated > 100) satiated = 100;
            break;
          case 3:
            clean += upStates;
            Console.WriteLine("Me sinto tão limpo");
            if (clean > 100) clean = 100;
            break;
          case 4:
            isContinue = false;
            break;
        }

      }
      catch (Exception)
      {
        goto playerSelectAction;
      }
    }

    if (isLiving)
    {
      Console.WriteLine("Obrigado por cuidar do seu bichinho!");
      Console.WriteLine("Até a proxima");
      Console.ReadKey();
    }
    else
    {
      Console.WriteLine("Você é um monstro");
      Console.ReadKey();
    }


  }
}