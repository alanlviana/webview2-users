using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Iniciador
{
    class Program
    {
        private const string PARAMETRO_CAMINHO_APLICACAO_PRINCIPAL = "AplicacaoPrincipal.Caminho";
        private const string PARAMETRO_USUARIO_EXECUCAO = "UsuarioExecucao";
        private const string PARAMETRO_SENHA_USUARIO_EXECUCAO = "SenhaUsuarioExecucao";

        static void Main(string[] args)
        {

            var CaminhoAplicacaoPrincipal = ConfigurationManager.AppSettings[PARAMETRO_CAMINHO_APLICACAO_PRINCIPAL];
            var UsuarioExecucao = ConfigurationManager.AppSettings[PARAMETRO_USUARIO_EXECUCAO];
            var SenhaUsuarioExecucao = ConfigurationManager.AppSettings[PARAMETRO_SENHA_USUARIO_EXECUCAO];

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = CaminhoAplicacaoPrincipal;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(CaminhoAplicacaoPrincipal);
            processStartInfo.UseShellExecute = false;
            processStartInfo.UserName = UsuarioExecucao;
            processStartInfo.Password = CriarStringSegura(SenhaUsuarioExecucao);

            Process.Start(processStartInfo);

        }

        private static SecureString CriarStringSegura(string senha)
        {
            SecureString password = new SecureString();
            foreach(var caracter in senha)
            {
                password.AppendChar(caracter);
            }

            return password;
        }
    }
}
