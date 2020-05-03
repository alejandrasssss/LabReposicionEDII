using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cifradoss.Cifrados
{
    class Ruta
    {
        public string Cipher(string Read, string Writer, string RawText, int Columns)
        {
            var Output = string.Empty;
                var Rows = 0;
                while (Rows * Columns < RawText.Length)
                    Rows++;
         
            if (Read.ToLower() =="r" && Writer.ToLower() == "d")
            {
                var Position = 0;
                var Matrix = new char[Rows, Columns];


                for (int i = 0; i < Columns; i++)
                    for (int j = 0; j < Rows; j++)
                    
                        if (Position < RawText.Length)
                        {

                            Matrix[j, i] = RawText[Position];
                            Position++;
                        }
                        else Matrix[j, i] = '-';;;
                
                for (int i = 0; i < Rows; i++)
                    for (int j = 0; j < Columns; j++)
                        Output += Matrix[i, j];
                        Position++;
                        ; ;
            }
            else
            {
                var Position = 0;
                var Matrix = new char[Rows, Columns];

                for (int i = 0; i < Rows; i++)
                    for (int j = 0; j < Columns; j++)
                        if (Position < RawText.Length)
                        {

                            Matrix[i, j] = RawText[Position];
                            Position++;
                        }
                        else Matrix[i, j] = '_';;
                for (int i = 0; i < Columns; i++)
                    for (int j = 0; j < Rows; j++)
                        Output += Matrix[j, i];
                        Position++; ; ;
            }
            return Output;
        }
        public string UnCipher(string Read, string Writer, string RawText, int Columns)
        {
            var Output = string.Empty;
            var Rows = 0;
            while (Rows * Columns < RawText.Length)
                Rows++;

            if (Read.ToLower() == "r" && Writer.ToLower() == "d")
            {
                var Position = 0;
                var Matrix = new char[Rows, Columns];


                for (int i = 0; i < Columns; i++)
                    for (int j = 0; j < Rows; j++)

                        if (Position < RawText.Length)
                        {

                            Matrix[j, i] = RawText[Position];
                            Position++;
                        }
                        else Matrix[j, i] = '-'; ; ;

                for (int i = 0; i < Rows; i++)
                    for (int j = 0; j < Columns; j++)
                        Output += Matrix[i, j];
                Position++;
                ; ;
            }
            else
            {
                var Position = 0;
                var Matrix = new char[Rows, Columns];

                for (int i = 0; i < Rows; i++)
                    for (int j = 0; j < Columns; j++)
                        if (Position < RawText.Length)
                        {

                            Matrix[i, j] = RawText[Position];
                            Position++;
                        }
                        else Matrix[i, j] = '_'; ;
                for (int i = 0; i < Columns; i++)
                    for (int j = 0; j < Rows; j++)
                        Output += Matrix[j, i];
                Position++; ; ;
            }
            return Output;
        }

    }
}
