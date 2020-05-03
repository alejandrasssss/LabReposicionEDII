﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REPASO
{
    public class Huffman
    {
        public List<HuffmanNode> ListaHojas = new List<HuffmanNode>();
        HuffmanNode hnRaiz = new HuffmanNode();

        public void GenerarArbol(List<HuffmanNode> ListaCaracteres)
        {

            while (ListaCaracteres.Count > 1)
            {
                ListaCaracteres.Sort();
                HuffmanNode hnDerecho = ListaCaracteres[0];
                ListaCaracteres.RemoveAt(0);
                HuffmanNode hnIzquierdo = ListaCaracteres[0];
                ListaCaracteres.RemoveAt(0);

                HuffmanNode nAux = new HuffmanNode();
                nAux = nAux.CrearNodoPadre(hnDerecho, hnIzquierdo);
                nAux.rightTree.parentNode = nAux;
                nAux.leftTree.parentNode = nAux;

                ListaCaracteres.Add(nAux);
            }

            hnRaiz = AsignarCodigosPrefijo("", ListaCaracteres[0]);
            GenerarListaNodosHoja(hnRaiz);
        }

        private HuffmanNode AsignarCodigosPrefijo(string codigoprefijo, HuffmanNode hnNodoActual)
        {
            if (hnNodoActual == null)
            {
                return null;
            }
            else if (hnNodoActual.leftTree == null && hnNodoActual.rightTree == null)
            {
                hnNodoActual.code = codigoprefijo;
                return hnNodoActual;
            }

            hnNodoActual.leftTree = AsignarCodigosPrefijo(codigoprefijo + "0", hnNodoActual.leftTree);
            hnNodoActual.rightTree = AsignarCodigosPrefijo(codigoprefijo + "1", hnNodoActual.rightTree);

            return hnNodoActual;
        }

        private void GenerarListaNodosHoja(HuffmanNode raiz)
        {
            if (raiz == null)
            {
                return;
            }
            else if (raiz.isLeaf)
            {
                ListaHojas.Add(raiz);
                return;
            }

            GenerarListaNodosHoja(raiz.leftTree);
            GenerarListaNodosHoja(raiz.rightTree);
        }
    }
}
