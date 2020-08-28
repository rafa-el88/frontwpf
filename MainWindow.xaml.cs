using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTeste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:44357/api/");
        }

        private async void Salvar_ClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                var pessoa = new Pessoa()
                {
                    Nome = txtNome.Text,
                    Sobrenome = txtSobrenome.Text,
                    Telefone = txtTelefone.Text
                };
                var response = await client.PostAsJsonAsync(@"https://web-wpfteste.azurewebsites.net/api/User", pessoa);
                //var response = await client.PostAsJsonAsync(@"User", pessoa); 
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Pessoa incluída com sucesso", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao criar o cadastro não foi incluído.");
            }
        } 

        private void Button_Click(object sender, RoutedEventArgs e)
        { 

        }
    }
    
}
