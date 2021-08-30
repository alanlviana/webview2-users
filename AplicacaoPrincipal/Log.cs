using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoPrincipal
{
    class Log
    {
        private static readonly string CAMINHO_LOG = @"C:\Webview2UserData\log.txt";

        public static void Gravar(string mensagem)
        {
            try
            {
                var entrada = Environment.NewLine;
                entrada += DateTime.Now.ToString();
                entrada += Environment.NewLine;
                entrada += mensagem;

                File.AppendAllText(CAMINHO_LOG, entrada);
            }catch(Exception e)
            {

            }

        }
    }
}
