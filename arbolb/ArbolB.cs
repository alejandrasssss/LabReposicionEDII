using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETD2LAB1
{
    public class ArbolB<T> where T : IComparable
    {
        public int Grado;
        public int altura = 0;

        public ArbolB(int grado)
        {
            Grado = grado;
        }


        public class Nodo
        {
            public Nodo Padre;
            public int grado;
            public T[] vector;
            public Nodo[] hijo;
            public bool EsHoja;
            public bool EstaLleno;

            public Nodo(int grado)
            {
                vector = new T[grado];
                hijo = new Nodo[grado];
                EstaLleno = false;
                this.grado = grado;
                EstaLleno = false;
            }

            public void Insertar(T valor)
            {

                int i = 0;
                while (i < grado - 1 && EstaLleno == false)
                {
                    if (this.vector[i] == null)
                    {
                        vector[i] = valor;

                        if (i == vector.Length - 1)
                        {
                            EstaLleno = true;
                        }
                    }
                    i++;
                }

            }

            public void Ordenar()
            {

                for (int p = 0; p <= vector.Length - 2; p++)
                {
                    for (int i = 0; i <= vector.Length - 2; i++)
                    {
                        if (vector[i + 1] != null)
                        {


                            if (vector[i].CompareTo(vector[i + 1]) == 1)
                            {
                                var temp = vector[i + 1];
                                vector[i + 1] = vector[i];
                                vector[i] = temp;



                            }

                        }
                    }
                }
            }

            public void BuscarEnNodo(T valor)
            {
                int i = 0;
                T dato = default;
                while (vector[i] != null)
                {
                    if (valor.CompareTo(vector[i]) == 0)
                    {
                        dato = vector[i];

                    }

                }

            }

        }

        Nodo Raiz;
        Nodo Buscar;
        // aqui empieza codigo arbol
        public void InsertarEnHoja(T valor)
        {
            bool detenerciclo = false;

            if (Raiz == null)
            {
                Nodo nuevo = new Nodo(Grado);
                Raiz = nuevo;
                Raiz.EsHoja = true;
                altura = 1;
            }

            BuscarHoja(valor);
            Buscar.Insertar(valor);
            Buscar.Ordenar();
            if (Buscar.Padre != null && Buscar.EstaLleno == true)
            {
                while (detenerciclo == false)
                {
                    int valormedio = Grado / 2;
                    int i = (Grado / 2) + 1;
                    int j = 0;
                    var temp1 = Buscar.vector[valormedio];
                    Buscar.vector[valormedio] = default;
                    Nodo nuevohermano = new Nodo(Grado);
                    while (i < Grado)
                    {
                        nuevohermano.vector[j] = Buscar.vector[i];
                        if (Buscar.EsHoja == false)
                        {
                            nuevohermano.hijo[j] = Buscar.hijo[i];
                        }

                        Buscar.vector[i] = default;
                        Buscar.hijo[i] = null;
                        i++;
                        j++;

                    }
                    Buscar.EstaLleno = false;
                    Buscar = Buscar.Padre;

                    int k = 0;
                    int l = Grado - 1;
                    bool detenerwhile = false;
                    while (detenerwhile == false)
                    {
                        if (temp1.CompareTo(Buscar.vector[k]) == -1)
                        {
                            detenerwhile = true;
                            var temp2 = Buscar.vector[k];
                            Buscar.vector[k] = temp1;
                            while (l > k + 1)
                            {
                                if (Buscar.vector[l - 1] != null)
                                {
                                    Buscar.vector[l] = Buscar.vector[l - 1];
                                    Buscar.hijo[l] = Buscar.hijo[l - 1];


                                }
                                l--;
                            }
                            Buscar.vector[k + 1] = temp2;
                            Buscar.hijo[k + 1] = nuevohermano;
                            nuevohermano.Padre = Buscar;
                            if (nuevohermano.hijo[0] == null)
                            {
                                nuevohermano.EsHoja = true;
                            }
                            else
                            {
                                nuevohermano.EsHoja = false;
                            }


                        }
                        k++;
                    }
                    if (Buscar.vector[Grado - 1] == null || Buscar == Raiz)
                    {
                        detenerciclo = true;
                    }
                }
            }

            if (Buscar.EstaLleno == true && Buscar == Raiz)// CASO SPLIT DOBLE en primera raiz
            {
                int j = (Grado / 2) + 1;
                int i = 0;
                Nodo NuevaRaiz = new Nodo(Grado);
                NuevaRaiz.vector[0] = Raiz.vector[Grado / 2];
                Raiz.vector[Grado / 2] = default;
                Nodo NuevoHermano = new Nodo(Grado);

                while (j < Grado)
                {
                    NuevoHermano.vector[i] = Raiz.vector[j];
                    Raiz.vector[j] = default;
                    if (Raiz.EsHoja == false)
                    {
                        NuevoHermano.hijo[i] = Raiz.hijo[j];
                        Raiz.hijo[j] = null;
                    }

                    j++;
                    i++;
                }

                NuevaRaiz.hijo[0] = Raiz;
                Raiz.Padre = NuevaRaiz;
                if (NuevaRaiz.hijo[0] == null)
                {
                    NuevoHermano.EsHoja = true;
                }
                else
                {
                    NuevoHermano.EsHoja = false;
                }
                NuevaRaiz.EsHoja = false;
                Raiz = NuevaRaiz;
                NuevaRaiz.hijo[1] = NuevoHermano;

            }


        }

        public T BuscarEnArbol(T valor)
        {

            int i = 0;
            int j = 0;
            int k = 0;
            Buscar = Raiz;
            bool encontrado = false;
            T resultado = valor;
            while (Buscar.vector[k] != null)
            {
                if (valor.CompareTo(Buscar.vector[k]) == 0)
                {
                    resultado = Buscar.vector[k];
                    encontrado = true;
                }
                k++;
            }


            while (encontrado == false)
            {
                while (Buscar.vector[j] != null)
                {
                    if (valor.CompareTo(Buscar.vector[j]) == 0)
                    {
                        resultado = Buscar.vector[j];
                        encontrado = true;
                        j = 0;
                    }

                    j++;
                }

                if (Buscar.vector[i].CompareTo(valor) == -1)
                {

                    Buscar = Buscar.hijo[i];
                    i = 0;

                }
                else if (Buscar.vector[i + 1] == null && valor.CompareTo(Buscar.vector[i]) == 1)
                {
                    Buscar = Buscar.hijo[i + 1];
                    i = 0;
                }

                i++;
            }
            return resultado;
        }

        public void BuscarHoja(T valor)
        {
            int i = 0;
            Buscar = Raiz;

            while (Buscar.EsHoja == false)
            {
                //valor.CompareTo(Buscar.vector[i]) == -1

                if (Buscar.vector[i].CompareTo(valor) == -1)
                {

                    Buscar = Buscar.hijo[i];
                    i = 0;

                }
                else if (Buscar.vector[i + 1] == null && valor.CompareTo(Buscar.vector[i]) == 1)
                {
                    Buscar = Buscar.hijo[i + 1];
                    i = 0;
                }

                i++;
            }


        }
    }
}
