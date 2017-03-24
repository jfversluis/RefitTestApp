using System.Threading.Tasks;
using Refit;

namespace RefitTestApp
{
    public interface IRestClient
    {
        [Get ("/posts")]
        Task<Foo []> GetPosts ();

        [Get ("/posts/{id}")]
        Task<Foo> GetPost (int id);

        [Post ("/posts")]
        Task AddPost (Foo foo);
    }
}