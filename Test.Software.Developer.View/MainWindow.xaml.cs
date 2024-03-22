using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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

namespace Test.Software.Developer.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MessageId.Visibility = Visibility.Hidden;
            MessageName.Visibility = Visibility.Hidden;
            MessageLastName.Visibility = Visibility.Hidden;

            MessageResponse.Visibility = Visibility.Hidden;
            MessageError.Visibility = Visibility.Hidden;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Person person = new Person();

                person.IdInvoice = TextId.Text;
                person.Name = TextName.Text;
                person.LastName = TextLastName.Text;
                person.SecondLastName = TextSecondLastName.Text;

                if (TextId.Text == string.Empty)
                {
                    MessageId.Visibility = Visibility.Visible;
                    MessageId.Content = "No ah ingresado el numero de Identificacion*";
                }

                if (TextName.Text == string.Empty)
                {
                    MessageName.Visibility = Visibility.Visible;
                    MessageName.Content = "No ah ingresado el Nombre*";
                }

                if (TextLastName.Text == string.Empty)
                {
                    MessageLastName.Visibility = Visibility.Visible;
                    MessageLastName.Content = "No ah ingresado el Apellido*";
                }

                if (TextName.Text != string.Empty && TextId.Text != string.Empty && TextLastName.Text != string.Empty)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        JsonContent content = JsonContent.Create(person);
                        var response = await client.PostAsync("http://localhost:5126/api/DirectorioRestService/PostPerson", content);
                        response.EnsureSuccessStatusCode();

                        if (response.IsSuccessStatusCode)
                        {
                            MessageResponse.Visibility = Visibility.Visible;
                            //MessageResponse.Content = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(response.Content);
                            MessageResponse.Content = "Se guardo correctamente";

                            TextId.Text = string.Empty;
                            TextName.Text = string.Empty;
                            TextLastName.Text = string.Empty;
                            TextSecondLastName.Text = string.Empty;
                        }

                        else
                        {
                            MessageError.Visibility = Visibility.Visible;
                            MessageError.Content = $"Server error code {response.StatusCode}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public class Person
        {
            public string IdInvoice { get; set; }

            public string Name { get; set; }

            public string LastName { get; set; }

            public string? SecondLastName { get; set; }
        }

    }
}
