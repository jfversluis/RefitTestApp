using System;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace RefitTestApp
{
    public partial class RefitTestAppPage : ContentPage
    {
        private string _baseApiUrl = "https://jsonplaceholder.typicode.com";
        private readonly RestClient _restClient;

        public RefitTestAppPage ()
        {
            InitializeComponent ();

            _restClient = new RestClient ();
        }

        private async void Handle_Clicked (object sender, System.EventArgs e)
        {
            using (HttpClient client = new HttpClient ()) {
                client.BaseAddress = new Uri (_baseApiUrl);

                var fooString = await client.GetStringAsync ("posts");
                var fooCollection = JsonConvert.DeserializeObject<Foo []> (fooString);

                ResultLabel.Text = $"{fooCollection [0].id} - {fooCollection [0].title}";
            }
        }

        private async void Handle_Clicked_Awesome (object sender, System.EventArgs e)
        {
            var fooCollection = await _restClient.GetPosts ();

            ResultLabel.Text = $"{fooCollection [0].id} - {fooCollection [0].title}";
        }

        private async void Handle_Clicked_Awesome_3 (object sender, System.EventArgs e)
        {
            var foo = await _restClient.GetPost (3);

            ResultLabel.Text = $"{foo.id} - {foo.title}";
        }

        private async void Handle_Clicked_Awesome_Post (object sender, System.EventArgs e)
        {

            var foo = new Foo {
                id = 1337,
                title = "Awesome!",
                body = "Unicorns and rainbows",
                userId = 1
            };

            await _restClient.AddPost (foo);

            ResultLabel.Text = $"Added";
        }
    }
}