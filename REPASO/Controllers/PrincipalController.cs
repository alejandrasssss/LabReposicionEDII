using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace REPASO.Controllers
{
    public class PrincipalController : Controller
    {
        Huffman H = new Huffman();
        LZW lZW = new LZW();
        [HttpPost]
        [Route("Huffman")]
        public ActionResult Insertar([FromBody] string path)
        {
            List<HuffmanNode> nodeList = new List<HuffmanNode>();
            try
            {
                FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                for (int i = 0; i < stream.Length; i++)
                {
                    string read = Convert.ToChar(stream.ReadByte()).ToString();
                    if (nodeList.Exists(x => x.caracter == read))
                        nodeList[nodeList.FindIndex(y => y.caracter == read)].Frecuencia();
                    else
                        nodeList.Add(new HuffmanNode(read));
                }
                nodeList.Sort();
                H.GenerarArbol(nodeList);
            }
            catch (Exception)
            {
                return null;
            }
            return Ok();
        }

        [HttpPost]
        [Route("LZW/Compresio")]
        public ActionResult Insertar_LZW([FromBody] string path)
        {
            lZW.Compresion(path);
            return Ok();
        }

        [HttpPost]
        [Route("LZW/Descompresion")]
        public ActionResult Descompress([FromBody] string path)
        {
            lZW.Descompresion(path);
            return Ok();
        }


    }
}
