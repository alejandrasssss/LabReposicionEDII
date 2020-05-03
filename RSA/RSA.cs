﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class RSA
    {
        private long llavePrivada;
        private long llavePublica;
        private int fi, e, N, P, Q, d;


        public RSA(int P, int Q)
        {
            this.P = P;
            this.Q = Q;
            N = P * Q;
        }

        public RSA()
        {

        }
        /**Metodo que retorna si el numero es primo o no
         *@param n un numero P
         *@return boolean
         */
        public bool comprobarPrimo(int n)
        {
            int contador = 0;
            for (int i = 1; i <= n; i++)
            {
                if ((n % i) == 0)
                {
                    contador++;
                }
            }
            if (contador <= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /**Metodo que retorna fi
         *@return fi
         */
        public int ObtenerFI()
        {
            fi = (P - 1) * (Q - 1);
            return fi;
        }

        /**Metodo un numero e primo
         *@return e
         */
        public int ObtenerE()
        {

            for (int i = 21; i < fi; i++)
            {
                e = i;
                if (comprobarPrimo(i) && ObtenerD() != 0)
                {
                    e = i;
                    return e;
                }
            }
            return 0;
        }

        /**Metodo un numero e primo
         *@return d
         */
        public int ObtenerD()
        {

            for (int i = 2; i < fi; i++)
            {
                if ((e * i) % fi == 1)
                {
                    d = i;
                    return d;
                }
            }
            return 0;
        }

        /**Obtener N
         *@return N
         */
        public int ObtenerN()
        {
            return N;
        }

        public String encriptar(char caracter)
        {
            StringBuilder caracterEncriptado = new StringBuilder();
            int n = caracter;
            long big = (long)Math.Pow(n, e);
            int c = mod(big.ToString(), N);
            caracterEncriptado.Append((char)c);
            return caracterEncriptado.ToString();
        }

        int mod(String num, int a)
        {
            int res = 0;
            char[] number = num.ToCharArray();
            for (int i = 0; i < num.Length; i++)
                res = (res * 10 + (int)number[i] - '0') % a;

            return res;
        }

        public void clavePublica(int n, int e)
        {
            this.N = n;
            this.e = e;
        }

        public void clavePrivada(int n, int d)
        {
            this.N = n;
            this.d = d;
        }

        public String desencriptar(char caracter)
        {
            StringBuilder caracterEncriptado = new StringBuilder();
            int n = caracter;
            long big = (long)Math.Pow(n, e);
            int c = mod(big.ToString(), N);
            caracterEncriptado.Append((char)c);
            return caracterEncriptado.ToString();
        }

    }
}

