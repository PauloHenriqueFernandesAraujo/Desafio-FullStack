using DesafioFULL.tools.mongoConnection.model;
using DesafioFULL.tools.mongoConnection.service;
using System.Threading.Tasks;
using System.Web.Http;

namespace DesafioFULL.tools.mongoConnection
{
    public class MongoGenericController<T> : ApiController where T : class, IMongoGenericModel
    {
        public IMongoGenericService<T> _service;
        public MongoGenericController(IMongoGenericService<T> service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IHttpActionResult> Insert([FromBody] T obj)
        {
            return Ok(await _service.InsertAsync(obj));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IHttpActionResult> Patch([FromBody] T obj)
        {
            return Ok(await _service.UpdateAsync(obj));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IHttpActionResult> Delete([FromUri] string id)
        {
            await _service.DeleteAsync(id);
            return Ok(true);
        }

        [HttpGet]
        [Route("findone/{id}")]
        public async Task<IHttpActionResult> Find([FromUri] string id)
        {
            return Ok(await _service.FindOne(id));
        }

        [HttpGet]
        [Route("findall")]
        public async Task<IHttpActionResult> FindAll()
        {
            return Ok(await _service.FindAll());
        }
    }
}