using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Models;


namespace Shared
{
    public interface IDocumentDBRepository
    {
        Task<dynamic> CriarDocumentoAsync(dynamic doc, CamposFixos conf);
        Task<dynamic> ConsultarDocumentoAsync(Guid id, string sistema);
        Task DeletarDocumentoAsync(Guid id, string sistema);
    }

    public class DocumentDBRepository : IDocumentDBRepository
    {
        private readonly IConfiguration Configuration;
        private readonly string Endpoint;
        private readonly string Key;
        private readonly string DatabaseId;

        private DocumentClient client;

        public DocumentDBRepository(IConfiguration configuration)
        {
            Configuration = configuration;

            var config = Configuration.GetSection("FormularioValuesConnection");

            Endpoint = config.GetValue<string>("AccountEndpoint");
            Key = config.GetValue<string>("AccountKeys");
            DatabaseId = config.GetValue<string>("Database");

            this.client = new DocumentClient(new Uri(Endpoint), Key);
        }

        public async Task<dynamic> CriarDocumentoAsync(dynamic doc, CamposFixos conf)
        {
            if (conf.CriarSeNaoExistir)
            {
                CreateDatabaseIfNotExistsAsync().Wait();
                CreateCollectionIfNotExistsAsync(conf.Sistema).Wait();
            }
            
            Document document = await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, conf.Sistema), doc, null, true);
            return document.ToString();
        }
        
        public async Task<dynamic> ConsultarDocumentoAsync(Guid id, string sistema)
        {
            try
            {
                Document document = await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, sistema, id.ToString()));

                return document.ToString();
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;
                else
                    throw;
            }
        }

        public async Task DeletarDocumentoAsync(Guid id, string sistema)
        {
            await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, sistema, id.ToString()));
        }

        private async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task CreateCollectionIfNotExistsAsync(string sistema)
        {
            try
            {
                await client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, sistema));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection { Id = sistema },
                        new RequestOptions { OfferThroughput = 1000 });
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
