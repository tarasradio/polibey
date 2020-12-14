using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 

namespace polibey
{
    class Program
    {
        private static char[,] PolybiusMatrix = 
        {
            {'А','Б','В','Г','Д', 'Е'},
            {'Ж','З','И','Й','К', 'Л'},
            {'М','Н','О','П','Р', 'С'},
            {'Т','У','Ф','Х','Ц', 'Ч'},
            {'Ш','Щ','Ъ','Ы','Ь', 'Э'},
            {'Ю','Я','.',',',' ', '?'}
        };

        private static int matrixWidth = 6;
        private static int matrixHeigth = 6;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите собщение (используйте прописные символы):");

            string message = Console.ReadLine();

            message = message.ToUpper();

            Console.WriteLine("Что вы хотите сделать? (E - зашифровать, D - расшифровать)");
            string modeStr = Console.ReadLine().ToUpper();

            if (modeStr[0] == 'E')
            {
                string encryptedMessage = string.Empty;
                // Шифрование
                foreach (var symbol in message)
                {
                    encryptedMessage += getCryptoStr(symbol);
                }

                Console.WriteLine($"Зашифрованное сообщение: {encryptedMessage}");
            }
            else if (modeStr[0] == 'D')
            {
                // Дешифрование
                if (message.Length % 2 == 1)
                {
                    Console.WriteLine("Неверная длинна зашифрованного сообщения. Длинна должна быть кратна 2-м.");
                }
                else
                {
                    string decryptedMessage = string.Empty;
                    for(int i = 0; i < message.Length; i += 2)
                    {
                        decryptedMessage += getEncryptoChar(message.Substring(i, 2));
                    }

                    Console.WriteLine($"Расшифрованное сообщение: {decryptedMessage}");
                }
            }
        }


        private static string getCryptoStr(char Char)
        {
            for (int i = 0; i < matrixHeigth; i++)
            {
                for (int j = 0; j < matrixWidth; j++)
                {
                    if (Char == PolybiusMatrix[i, j])
                    {
                        string Result = PolybiusMatrix[0, i].ToString() +
                        PolybiusMatrix[0, j].ToString();
                        return Result;
                    }
                }
            }
            return "EE";
        }

        private static char getEncryptoChar(string Str)
        {
            //Имеем 2 символа на входе
            char chH = Str[0]; char chW = Str[1]; int indexH = 5, indexW = 5;
            //Ищем где расположен исходный символ
            for (int i = 0; i < matrixWidth; i++)
            {
                if (chH == PolybiusMatrix[0, i]) indexH = i;
                if (chW == PolybiusMatrix[0, i]) indexW = i;
            }
            return PolybiusMatrix[indexH, indexW];
        }
    }
}