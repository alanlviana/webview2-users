using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplicacaoPrincipal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string PARAMETRO_WEBVIEW2_RUNTIME = "Webview2.Runtime";
        private const string PARAMETRO_WEBVIEW2_SOURCE = "Webview2.Source";
        private const string PARAMETRO_WEBVIEW2_USERDATA = "Webview2.Userdata";

        public string Webview2Runtime { get; set; }
        public string Webview2Source { get; set; }
        public string Webview2UserData { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Webview2Runtime = ConfigurationManager.AppSettings[PARAMETRO_WEBVIEW2_RUNTIME];
            Webview2UserData = ConfigurationManager.AppSettings[PARAMETRO_WEBVIEW2_USERDATA];
            Webview2Source = ConfigurationManager.AppSettings[PARAMETRO_WEBVIEW2_SOURCE];

            CriarNavegador();


        }

        private async Task CriarNavegador()
        {

            CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions();
            CoreWebView2Environment env = await CoreWebView2Environment.CreateAsync(Webview2Runtime, Webview2UserData);

            WebView2 Navegador = new WebView2();
            Navegador.CoreWebView2InitializationCompleted += Navegador_CoreWebView2InitializationCompleted;
            Container.Children.Add(Navegador);
            await Navegador.EnsureCoreWebView2Async(env);
            Navegador.Source = new Uri(Webview2Source);


        }

        private void Navegador_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                Log.Gravar("Navegador Iniciou com sucesso");
                return;
            }
            
            Log.Gravar("Navegador Iniciou sem sucesso: "+e.InitializationException);
        }
    }
}
