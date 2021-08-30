using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoPrincipal
{
    public class Iniciador
    {

        [STAThread]
        [LoaderOptimization(LoaderOptimization.MultiDomain)]
        public static void Main(string[] args)
        {
            if (AppDomain.CurrentDomain.IsDefaultAppDomain())
            {
                CarregarNovoAppDomain(args);
            }
            else
            {
                ExecutarAplicacao();
            }


            
        }

        private static void ExecutarAplicacao()
        {
            Log.Gravar("Aplicacao sendo executada em novo app domain.");
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        private static void CarregarNovoAppDomain(string[] args)
        {
            Log.Gravar("Criando novo app domain");

            AppDomainSetup domainSetup = new AppDomainSetup();
            domainSetup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            domainSetup.LoaderOptimization = LoaderOptimization.MultiDomain;

            AppDomain novo = AppDomain.CreateDomain("novo", AppDomain.CurrentDomain.Evidence, domainSetup);
            novo.ExecuteAssembly(Assembly.GetExecutingAssembly().Location, args);
        }
    }
}
