using DesafioFULL.modules.debts.model;
using DesafioFULL.modules.debts.service;
using DesafioFULL.tools.annotations;
using DesafioFULL.tools.mongoConnection;
using System.Threading.Tasks;
using System.Web.Http;

namespace DesafioFULL.modules.debts.controller
{
    [FullRoutePrefix("debts")]
    public class DebtsController : MongoGenericController<Debts>
    {
        private IDebtsService _service;
        public DebtsController(IDebtsService service) : base(service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("table")]
        public async Task<IHttpActionResult> GetTable()
        {
            return Ok(await _service.GetTable());
        }

    }
}