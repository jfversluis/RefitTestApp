using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RefitTestApp
{
    public class RestClient
    {
        private readonly IRestClient _restClient;

        public RestClient ()
        {
            _restClient = RestService.For<IRestClient> ("https://jsonplaceholder.typicode.com");
        }

        public async Task<Foo []> GetPosts ()
        {
            return await _restClient.GetPosts ();
        }

        public async Task<Foo> GetPost (int id)
        {
            return await _restClient.GetPost (id);
        }

        public async Task AddPost (Foo foo)
        {
            await _restClient.AddPost (foo);
        }
    }
}